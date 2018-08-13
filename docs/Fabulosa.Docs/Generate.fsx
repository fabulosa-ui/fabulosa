// #load "../../.fake/Docs.fsx/intellisense.fsx"
#load "../../.paket/load/net46/FSharp.Formatting.fsx"

open FSharp.Literate
open System.IO

let source = __SOURCE_DIRECTORY__
let template = Path.Combine(source, "template.html")

let script = Path.Combine(source, "index.fsx")
Literate.ProcessScriptFile(script, template)
let pagesDir = Path.Combine(source, "pages");
// Process all files and save results to 'output' directory
Literate.ProcessDirectory
  (pagesDir, template, source, replacements = [])