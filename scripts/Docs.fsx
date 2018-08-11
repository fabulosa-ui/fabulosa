#load "../.fake/Docs.fsx/intellisense.fsx"
#load "../.paket/load/net46/FSharp.Formatting.fsx"

open FSharp.Literate
open System.IO

let source = __SOURCE_DIRECTORY__
let template = Path.Combine(source, "template.html")

let script = Path.Combine(source, "Script.fsx")
Literate.ProcessScriptFile(script, template)