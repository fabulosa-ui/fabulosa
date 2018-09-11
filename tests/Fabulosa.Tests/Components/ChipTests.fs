module ChipTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Chip tests" [

        test "Chip default" {
            Chip.ƒ
                Chip.defaults 
                []
            |> ReactNode.unit
            |> hasUniqueClass "chip"
        }

        test "Chip html props" {
            Chip.ƒ
                { Chip.defaults with 
                    HTMLProps = [ClassName "custom"] }
                []
            |> ReactNode.unit
            |> hasClass "chip custom"
        }

        test "Chip removable" {
            let onRemove = ignore
            Chip.ƒ
                { Chip.defaults with
                    Removable = true
                    OnRemove = onRemove }
                []
            |> ReactNode.unit
            |> hasDescendentProp (OnClick onRemove)
        }

        test "Chip with children" {
            let avatar =
                Avatar.ƒ
                    { Avatar.defaults with
                        Size = Avatar.Size.Small }
                |> ReactNode.unit
            let text =
                R.str "Text"
                |> ReactNode.unit
            Chip.ƒ
                Chip.defaults
                [ Chip.Child.Avatar Avatar.defaults
                  Chip.Child.Text "Text" ]
            |> ReactNode.unit
            |>! hasChild 1 avatar
            |>! hasChild 1 text
            |> ignore
        }
    ]