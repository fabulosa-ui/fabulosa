module TagTests

open Expecto
open Fabulosa
open Expect
open Fabulosa.Tag
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Tag tests" [
        test "Tag should be a react html node when defaults are provided" {
            tag ([], Text "Ronaldo 9")
            |> ReactNode.unit
            |>! hasUniqueClass "label" 
            |> hasText "Ronaldo 9"
        }
        
        test "Tag should be rounded" {
            tag ([ Rounded ], Text "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label label-rounded" 
            |> hasText "Ronaldo 9"
        }
        
        test "Tag should have color labels" {
            tag ([ Color Primary ], Text "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label label-primary" 
            |> hasText "Ronaldo 9"

            tag ([ Color Secondary ], Text "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label label-secondary" 
            |> hasText "Ronaldo 9"

            tag ([ Color Success ], Text "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label label-success" 
            |> hasText "Ronaldo 9"

            tag ([ Color Warning ], Text "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label label-warning" 
            |> hasText "Ronaldo 9"

            tag ([ Color Error ], Text "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label label-error" 
            |> hasText "Ronaldo 9"
        }
    ]
    