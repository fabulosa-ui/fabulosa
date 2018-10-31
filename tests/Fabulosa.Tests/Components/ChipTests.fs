module ChipTests

open Expecto
open Fabulosa
open Fabulosa.Chip
open Fabulosa.Avatar
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Chip tests" [

        test "Chip default" {
            chip ([], Text "Chip")
            |> ReactNode.unit
            |> hasUniqueClass "chip"
        }

        test "Chip html props" {
            chip ([ P.ClassName "custom" ], Text "Chip")
            |> ReactNode.unit
            |> hasClass "chip custom"
        }

        test "Chip removable" {
            let fn = ignore
            chip ([ OnRemove fn ], Text "Chip")
            |> ReactNode.unit
            |> hasDescendentProp (P.OnClick fn)
        }

        test "Chip with children" {
            let av =
                avatar ([ Size Small ], Initial "FA")
                |> ReactNode.unit
            chip ([ Avatar (Initial "FA") ], Text "Text" )
            |> ReactNode.unit
            |>! hasChild 1 av
            |>! hasText "Text"
            |> ignore
        }
    ]