#r "paket: groupref netcorebuild //"
#load @".fake/build.fsx/intellisense.fsx"
#if !FAKE
#r "Facades/netstandard"
#r "netstandard"
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
open Fake.DotNet.FSFormatting

let runFable args =
    let result =
        DotNet.exec
            (DotNet.Options.withWorkingDirectory __SOURCE_DIRECTORY__)
            "fable" args
    if not result.OK then
        failwithf "dotnet fable failed with code %i" result.ExitCode

Target.create "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    ++ "docs/**/bin"
    ++ "docs/**/obj"
    ++ "tests/**/bin"
    ++ "tests/**/obj"
    ++ "output"
    |> Shell.cleanDirs
    Shell.rm "docs/Fabulosa.Docs/*.html"
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
    let docs = Path.Combine(source, "docs/Fabulosa.Docs")
    FSFormatting.createDocs(fun _ -> {
        FSFormatting.defaultLiterateArguments with
            Source = Path.Combine(docs, "pages")
            Template = Path.Combine(docs, "assets/template.html")
            OutputDirectory = docs
            LayoutRoots = [docs]
            ProjectParameters = [("", "")]
    })
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
    ==> "Build"
    ==> "YarnInstall"
    ==> "GenerateDocPages"
    ==> "BuildTests"
    ==> "Test"
    ==> "BuildDocs"

"GenerateDocPages"
    ==> "Watch"

"Build"
    ==> "Test"
    ==> "PublishDocs"

// start build
Target.runOrDefault "BuildDocs"