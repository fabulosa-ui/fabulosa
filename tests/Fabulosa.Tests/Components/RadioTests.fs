module RadioTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fabulosa.Tests.Extensions.TestNodeExtensions

[<Tests>]
let tests =
    testList "Radio tests" [

        test "Radio default" {
            let props = Radio.defaults
            let radio = Radio.ƒ props
            radio |> hasClasses ["form-radio"]
            radio |> hasDescendent (R.input [Type "radio"])
            radio |> hasDescendent (R.i [ClassName "form-icon"] [])
            radio |> hasDescendent (R.str "Label")
        }

        test "Radio inline" {
            let props = { Radio.defaults with Inline = true }
            let radio = Radio.ƒ props
            radio |> hasClasses ["form-radio"; "form-inline"]
        }

        test "Radio text" {
            let props = { Radio.defaults with Text = "custom" }
            let radio = Radio.ƒ props
            radio |> hasClasses ["form-radio"]
            radio |> hasDescendent (R.str "custom")
        }

        test "Radio html props" {
            let props = { Radio.defaults with HTMLProps = [ClassName "custom"] }
            let radio = Radio.ƒ props
            radio |> hasClasses ["form-radio"]
            radio |> hasDescendent (R.input [ClassName "custom"])
        }

    ]