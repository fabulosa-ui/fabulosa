#r "paket: groupref netcorebuild //"
#load @".fake/build.fsx/intellisense.fsx"
#if !FAKE
#r "Facades/netstandard"
#r "netstandard"
#r "Facades/netcoreapp"
#r "netcoreapp"
#endif

#nowarn "52"

open System
open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.IO.FileSystemOperators
open Fake.Tools.Git
open Fake.JavaScript
open Fake.DotNet
open System.IO

let runFable args =
    let result =
        DotNet.exec
            (DotNet.Options.withWorkingDirectory __SOURCE_DIRECTORY__)
            "fable" args
    if not result.OK then
        failwithf "dotnet fable failed with code %i" result.ExitCode

let run (cmd:string) dir args  =
    if Process.execSimple (fun info ->
        { info with
            FileName = cmd
            WorkingDirectory =
                if not (String.isNullOrWhiteSpace dir) then dir else info.WorkingDirectory
            Arguments = args
        }
    ) System.TimeSpan.MaxValue <> 0 then
        failwithf "Error while running '%s' with args: %s " cmd args

Target.create "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    ++ "docs/**/bin"
    ++ "docs/**/obj"
    ++ "tests/**/bin"
    ++ "tests/**/obj"
    ++ "output"
    |> Shell.cleanDirs 
)

Target.create "DotnetRestore" (fun _ ->
    DotNet.restore
        (DotNet.Options.withWorkingDirectory __SOURCE_DIRECTORY__)
        "Fabulosa.sln"
)

Target.create "Build" (fun _ ->
    !! "src/**/*.*proj"
    |> Seq.iter (DotNet.build id)
)

Target.create "GenerateDocPages" (fun _ ->
    let source = __SOURCE_DIRECTORY__
    if Environment.isWindows then
        let fsiExe = "\"C:\Program Files (x86)\\Microsoft SDKs\\F#\\10.1\\Framework\\v4.0\\fsi.exe\""
        run fsiExe source <| Path.Combine (source, "docs/Fabulosa.Docs/Generate.fsx")
    else run "fsharpi" source <| Path.Combine (source, "docs/Fabulosa.Docs/Generate.fsx")
)

Target.create "BuildDocs" (fun _ ->
    runFable "webpack-cli"
)

Target.create "YarnInstall" (fun _ ->
    Yarn.install id
)

Target.create "Watch" (fun _ ->
    runFable "webpack-dev-server"
)

Target.create "BuildTests" (fun _ ->
    !! "tests/**/*.*proj"
    |> Seq.iter (DotNet.build id)
)
let opts (def:DotNet.Options) = def

Target.create "Test" (fun _ ->
    !! "tests/**/*.*proj"
    |> Seq.iter (fun proj -> DotNet.exec opts ("run --project " + proj) "" |> ignore)
)

// Where to push generated documentation
let githubLink = "git@github.com:tmonte/fabulosa.git"
let publishBranch = "gh-pages"
let fableRoot   = __SOURCE_DIRECTORY__
let temp        = fableRoot </> "temp"
let docsOuput = fableRoot </> "output"

// --------------------------------------------------------------------------------------
// Release Scripts
Target.create "PublishDocs" (fun _ ->
    Shell.cleanDir temp
    Repository.cloneSingleBranch "" githubLink publishBranch temp

    Shell.copyRecursive docsOuput temp true |> Trace.logfn "%A"
    Staging.stageAll temp
    Commit.exec temp (sprintf "Update site (%s)" (DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
    Branches.push temp
)

// // Build order
"Clean"
    ==> "DotnetRestore"
    ==> "GenerateDocPages"
    ==> "YarnInstall"
    ==> "Build"
    ==> "BuildTests"
    ==> "Test"
    ==> "BuildDocs"

"YarnInstall"
    ==> "Watch"

"Build"
    ==> "Test"
    ==> "PublishDocs"

// start build
Target.runOrDefault "BuildDocs"