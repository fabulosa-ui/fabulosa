#load ".fake/build.fsx/intellisense.fsx"
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

let testDir  = "./tests/"

Target.create "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    |> Shell.cleanDirs 
)

Target.create "Build" (fun _ ->
    !! "src/**/*.*proj"
    |> Seq.iter (DotNet.build id)
    |> Trace.logItems "Build-Output: "
)

Target.create "BuildTests" (fun _ ->
    !! "tests/**/*.*proj"
    |> Seq.iter (DotNet.build id)
    |> Trace.logItems "BuildTests-Output: "
)

Target.create "Test" (fun _ ->
    !! "tests/**/*.*proj"
    |> Seq.iter (DotNet.run id)
    |> Trace.logItems "Test-Output: "
)

Target.create "All" ignore

"Clean"
  ==> "Build"
  ==> "BuildTest"
  ==> "Test"
  ==> "All"

Target.runOrDefault "All"
