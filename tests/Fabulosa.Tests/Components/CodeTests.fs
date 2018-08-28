module CodeTests

open Expecto
open Expect
open Fabulosa
module R = Fable.Helpers.React
open R.Props


[<Tests>]
let tests =
    testList "Code tests" [
        ptest "Code should be a react html node when defaults are provided" {
            let codeElement = Code.ƒ Code.defaults
            let data = Data ("lang", "F#")
            let innerCodeElement =
                R.code [DangerouslySetInnerHTML {__html = ""}] []
                |> ReactNode.unit
            
            codeElement
            |> ReactNode.unit
            |>! hasUniqueClass "code"
            |>! hasProp data
            |> Expect.hasChild 1 innerCodeElement
        }
    ]
    