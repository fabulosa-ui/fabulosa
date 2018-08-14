// #load "../../.fake/Docs.fsx/intellisense.fsx"
#load "../../.paket/load/net46/FSharp.Formatting.fsx"

open FSharp.Literate
open System.IO

let rec deleteFiles srcPath pattern includeSubDirs =
    
    if not <| System.IO.Directory.Exists(srcPath) then
        let msg = System.String.Format("Source directory does not exist or could not be found: {0}", srcPath)
        raise (System.IO.DirectoryNotFoundException(msg))

    for file in System.IO.Directory.EnumerateFiles(srcPath, pattern) do
        let tempPath = System.IO.Path.Combine(srcPath, file)
        System.IO.File.Delete(tempPath)

    if includeSubDirs then
        let srcDir = new System.IO.DirectoryInfo(srcPath)
        for subdir in srcDir.GetDirectories() do
            deleteFiles subdir.FullName pattern includeSubDirs

let source = __SOURCE_DIRECTORY__
let template = Path.Combine(source, "assets/template.html")

deleteFiles source "*.html" false

let script = Path.Combine(source, "index.fsx")
Literate.ProcessScriptFile(script, template)
let pagesDir = Path.Combine(source, "pages");
// Process all files and save results to 'output' directory
Literate.ProcessDirectory
  (pagesDir, template, source, replacements = [])