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
        test "Code should be a react html node when defaults are provided" {
            let code = Code.ƒ Code.defaults |> TestNode
            let data = Data ("lang", "F#")
            Expect.equal (code.Classes()) "code" "Root should contain class code"
            Expect.contains (code.Props()) (upcast data : IProp)  "Data does not exist"           
            
            let innerCode = code.Find(Name "code") |> Seq.head
            let innerSetHtml = ({ __html = "" } |> DangerouslySetInnerHTML).ToString()
            
            Expect.containsToString (innerCode.Props()) innerSetHtml "InnerHtml should be found"
        }
    ]
    