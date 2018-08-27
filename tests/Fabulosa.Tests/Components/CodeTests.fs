module CodeTests

open Expecto
open ReactNode
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Fabulosa.Tests.Extensions
open Fabulosa.Tests.Extensions.Props
open System.Reflection


[<Tests>]
let tests =
    testList "Code tests" [
        ptest "Code should be a react html node when defaults are provided" {
            let codeElement = Code.ƒ Code.defaults
            let data = Data ("lang", "F#")
            let innerCodeElement = R.code [DangerouslySetInnerHTML {__html = ""}] []
            
            codeElement
            |> Expect.hasUniqueClassBind "code"
            |> Expect.containsPropBind data
            |> Expect.containsChild 1 innerCodeElement
            |> ignore
        }
    ]
    