module TagTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open Fabulosa.Tests.Extensions

[<Tests>]
let tests =
    testList "Tag tests" [
        test "Tag should be a react html node when defaults are provided" {
            let tagElement = Tag.ƒ Tag.defaults [R.str "Ronaldo 9"]
            
            tagElement
            |> Expect.containsClassNameBind "label" 
            |> Expect.containsText "Ronaldo 9"
        }
        
        test "Tag should be rounded" {
            let tagElement = Tag.ƒ { Tag.defaults with Rounded = true } [R.str "Ronaldo 9"]
            
            tagElement
            |> Expect.containsClassNameBind "label label-rounded" 
            |> Expect.containsText "Ronaldo 9"
        }
       
        test "Tag should not have any label-specfic color class when tag color is default" {
            let tagElement = Tag.ƒ { Tag.defaults with Color = Tag.Color.Default} [R.str "Ronaldo 9"]
                                    
            tagElement
            |> Expect.hasUniqueClassBind "label" 
            |> Expect.containsText "Ronaldo 9"
        }
        
        test "Tag should have color labels" {
            let tagElement = Tag.ƒ { Tag.defaults with Color = Tag.Color.Primary} [R.str "Ronaldo 9"]
            
            tagElement
            |> Expect.containsClassNameBind "label label-primary" 
            |> Expect.containsText "Ronaldo 9"
             
            let tagElement = Tag.ƒ { Tag.defaults with Color = Tag.Color.Secondary} [R.str "Ronaldo 9"]
            
            tagElement
            |> Expect.containsClassNameBind "label label-secondary" 
            |> Expect.containsText "Ronaldo 9"
                        
            let tagElement = Tag.ƒ { Tag.defaults with Color = Tag.Color.Success} [R.str "Ronaldo 9"]
            
            tagElement
            |> Expect.containsClassNameBind "label label-success" 
            |> Expect.containsText "Ronaldo 9"
            
            let tagElement = Tag.ƒ { Tag.defaults with Color = Tag.Color.Warning} [R.str "Ronaldo 9"]
            
            tagElement
            |> Expect.containsClassNameBind "label label-warning" 
            |> Expect.containsText "Ronaldo 9"
                        
            let tagElement = Tag.ƒ { Tag.defaults with Color = Tag.Color.Error} [R.str "Ronaldo 9"]
            
            tagElement
            |> Expect.containsClassNameBind "label label-error" 
            |> Expect.containsText "Ronaldo 9"
        }
    ]
    