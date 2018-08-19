module TagTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open Fabulosa.Tests.Extensions

[<Tests>]
let tests =
    testList "Tag tests" [
        test "Tag should be a react html node when defaults are provided" {
            let rootNode = Tag.ƒ Tag.defaults [R.str "Ronaldo 9"] |> TestNode
            Expect.equal (rootNode.Classes()) "label" "Root should have only class label"
            Expect.equal (rootNode.Text()) "Ronaldo 9" """Root should have chillren as "Ronaldo 9" """
        }
        
        test "Tag should be rounded" {
            let rootNode = Tag.ƒ { Tag.defaults with Rounded = true } [R.str "Ronaldo 9"] |> TestNode
            Expect.stringContains (rootNode.Classes()) "label" "Root should contain class label"
            Expect.stringContains (rootNode.Classes()) "label-rounded" "Root should contain class label-rounded"
            Expect.equal (rootNode.Text()) "Ronaldo 9" """Root should have chillren as "Ronaldo 9" """
        }
       
        test "Tag should not have any label-specfic color class when tag color is default" {
            let rootNode = Tag.ƒ { Tag.defaults with Color = Tag.Color.Default} [R.str "Ronaldo 9"] |> TestNode
            Expect.equal (rootNode.Classes()) "label" "Root should have only class label"
            Expect.equal (rootNode.Text()) "Ronaldo 9" """Root should have chillren as "Ronaldo 9" """
        }
        
        test "Tag should have color labels" {
            let rootNode = Tag.ƒ { Tag.defaults with Color = Tag.Color.Primary} [R.str "Ronaldo 9"] |> TestNode
            Expect.stringContains (rootNode.Classes()) "label" "Root should contain class label"
            Expect.stringContains (rootNode.Classes()) "label-primary" "Root should contain class label-secondary"
            Expect.equal (rootNode.Text()) "Ronaldo 9" """Root should have chillren as "Ronaldo 9" """
             
            let rootNode = Tag.ƒ { Tag.defaults with Color = Tag.Color.Secondary} [R.str "Ronaldo 9"] |> TestNode
            Expect.stringContains (rootNode.Classes()) "label" "Root should contain class label"
            Expect.stringContains (rootNode.Classes()) "label-secondary" "Root should contain class label-secondary"
            Expect.equal (rootNode.Text()) "Ronaldo 9" """Root should have chillren as "Ronaldo 9" """
            
            let rootNode = Tag.ƒ { Tag.defaults with Color = Tag.Color.Success} [R.str "Ronaldo 9"] |> TestNode
            Expect.stringContains (rootNode.Classes()) "label" "Root should contain class label"
            Expect.stringContains (rootNode.Classes()) "label-success" "Root should contain class label-success"
            Expect.equal (rootNode.Text()) "Ronaldo 9" """Root should have chillren as "Ronaldo 9" """
            
            let rootNode = Tag.ƒ { Tag.defaults with Color = Tag.Color.Warning} [R.str "Ronaldo 9"] |> TestNode
            Expect.stringContains (rootNode.Classes()) "label" "Root should contain class label"
            Expect.stringContains (rootNode.Classes()) "label-warning" "Root should contain class label-warning"
            Expect.equal (rootNode.Text()) "Ronaldo 9" """Root should have chillren as "Ronaldo 9" """
            
            let rootNode = Tag.ƒ { Tag.defaults with Color = Tag.Color.Error} [R.str "Ronaldo 9"] |> TestNode
            Expect.stringContains (rootNode.Classes()) "label" "Root should contain class label"
            Expect.stringContains (rootNode.Classes()) "label-error" "Root should contain class label-error"
            Expect.equal (rootNode.Text()) "Ronaldo 9" """Root should have chillren as "Ronaldo 9" """
        }
    ]
    