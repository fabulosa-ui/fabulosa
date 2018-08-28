module TagTests

open Expecto
open Expect
open Fabulosa
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Tag tests" [
        test "Tag should be a react html node when defaults are provided" {
            let tagElement = Tag.ƒ Tag.defaults [R.str "Ronaldo 9"]
            
            tagElement
            |> ReactNode.unit
            |>! hasClass "label" 
            |> hasText "Ronaldo 9"
        }
        
        test "Tag should be rounded" {
            let tagElement = Tag.ƒ { Tag.defaults with Rounded = true } [R.str "Ronaldo 9"]
            
            tagElement
            |> ReactNode.unit
            |>! hasClass "label label-rounded" 
            |> hasText "Ronaldo 9"
        }
       
        test "Tag should not have any label-specfic color class when tag color is default" {
            let tagElement = Tag.ƒ { Tag.defaults with Color = Tag.Color.Default} [R.str "Ronaldo 9"]
                                    
            tagElement
            |> ReactNode.unit
            |>! hasUniqueClass "label" 
            |> hasText "Ronaldo 9"
        }
        
        test "Tag should have color labels" {
            let tagElement = Tag.ƒ { Tag.defaults with Color = Tag.Color.Primary} [R.str "Ronaldo 9"]
            
            tagElement
            |> ReactNode.unit
            |>! hasClass "label label-primary" 
            |> hasText "Ronaldo 9"
             
            let tagElement = Tag.ƒ { Tag.defaults with Color = Tag.Color.Secondary} [R.str "Ronaldo 9"]
            
            tagElement
            |> ReactNode.unit
            |>! hasClass "label label-secondary" 
            |> hasText "Ronaldo 9"
                        
            let tagElement = Tag.ƒ { Tag.defaults with Color = Tag.Color.Success} [R.str "Ronaldo 9"]
            
            tagElement
            |> ReactNode.unit
            |>! hasClass "label label-success" 
            |> hasText "Ronaldo 9"
            
            let tagElement = Tag.ƒ { Tag.defaults with Color = Tag.Color.Warning} [R.str "Ronaldo 9"]
            
            tagElement
            |> ReactNode.unit
            |>! hasClass "label label-warning" 
            |> hasText "Ronaldo 9"
                        
            let tagElement = Tag.ƒ { Tag.defaults with Color = Tag.Color.Error} [R.str "Ronaldo 9"]
            
            tagElement
            |> ReactNode.unit
            |>! hasClass "label label-error" 
            |> hasText "Ronaldo 9"
        }
    ]
    