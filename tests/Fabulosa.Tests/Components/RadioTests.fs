module RadioTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Radio tests" [

        test "Radio default" {
            let props = Radio.defaults
            let radio = Radio.ƒ props
            let input =
                R.input [Type "radio"]
                |> ReactNode.unit
            let icon =
                R.i [ClassName "form-icon"] []
                |> ReactNode.unit
            let label =
                R.str "Label"
                |> ReactNode.unit
            
            radio
            |> ReactNode.unit
            |>! hasUniqueClass "form-radio"
            |>! hasChild 1 input
            |>! hasChild 1 icon
            |> hasChild 1 label
        }

        test "Radio inline" {
            let props = { Radio.defaults with Inline = true }
            let radio = Radio.ƒ props
            
            radio
            |> ReactNode.unit
            |> hasClass "form-radio form-inline"
        }

        test "Radio text" {
            let props = { Radio.defaults with Text = "custom" }
            let radio = Radio.ƒ props
            let text =
                R.str "custom"
                |> ReactNode.unit
            
            radio
            |> ReactNode.unit
            |>! hasUniqueClass "form-radio"
            |> hasChild 1 text
        }

        test "Radio html props" {
            let props = { Radio.defaults with HTMLProps = [ClassName "custom"] }
            let radio = Radio.ƒ props
            
            radio
            |> ReactNode.unit
            |>! hasUniqueClass "form-radio"
            |> hasDescendentClass "custom"
        }

    ]