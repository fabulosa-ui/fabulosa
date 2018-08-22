module MediaTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Fabulosa.Tests.Extensions
open Fabulosa.Tests.Extensions.Props

[<Tests>]
let captionTest =
    testList "Caption tests" [
        test "Caption should be a react html node when defaults are provided" {
            let rootNode = Media.Caption.ƒ Media.Caption.defaults |> TestNode
            Expect.stringContains (rootNode.Classes()) "figure-caption" "Root should have class figure-caption"
            Expect.stringContains (rootNode.Classes()) "text-center" "Root should have class text-center"
            Expect.equal (rootNode.Text()) "" """Root should equal "" """            
        }
        
        test "Caption should have html props" {
            let rootNode = Media.Caption.ƒ { Media.Caption.defaults with HTMLProps = [Id "offside-is-a-crime"]} |> TestNode
            Expect.stringContains (rootNode.Classes()) "figure-caption" "Root should have class figure-caption"
            Expect.stringContains (rootNode.Classes()) "text-center" "Root should have class text-center"
            Expect.contains (rootNode.Props()) (upcast  Id "offside-is-a-crime") """Root should contain id  Id "offside-is-a-crime" """            
            Expect.equal (rootNode.Text()) "" """Root should equal "" """            
        }
        
        test "Caption should have text alignment set to input" {
            let rootNode = Media.Caption.ƒ { Media.Caption.defaults with TextDirection = Media.Caption.Center} |> TestNode
            Expect.stringContains (rootNode.Classes()) "text-center" "Root should have class text-center"
            
            let rootNode = Media.Caption.ƒ { Media.Caption.defaults with TextDirection = Media.Caption.Left} |> TestNode
            Expect.stringContains (rootNode.Classes()) "text-left" "Root should have class text-left"
            
            let rootNode = Media.Caption.ƒ { Media.Caption.defaults with TextDirection = Media.Caption.Right} |> TestNode
            Expect.stringContains (rootNode.Classes()) "text-right" "Root should have class text-right"
        }
        
        test "Caption should display custom text" {
            let rootNode = Media.Caption.ƒ { Media.Caption.defaults with Text = [R.str "Pele is the King!"] } |> TestNode
            Expect.stringContains (rootNode.Text()) "Pele is the King!" ""
            
            let rootNode = Media.Caption.ƒ { Media.Caption.defaults with Text = [R.div [ClassName "figueirense"] [R.str "Figueira!!!"]] } |> TestNode
            let textChildren = rootNode.Find(Class "figueirense")
            Expect.isNonEmpty textChildren "Caption children should be present"
            
            let textChildren = Seq.head textChildren
            Expect.equal (textChildren.Text()) "Figueira!!!" ""
        }
    ] 
 
[<Tests>]
let imageTest =
    testList "Image tests" [
        test "Image should be a react html node when defaults are provided" {
            let rootNode = Media.Image.ƒ Media.Image.defaults |> TestNode
            Expect.equal (rootNode.Classes()) "figure" "Root should have only class figure"
            
            let imageNode = rootNode.Find(Class "img-responsive")
            Expect.isNonEmpty imageNode "There should be a img-responsive found"
        }
         
        test "Image should be respond to different kinds" {
            let rootNode = Media.Image.ƒ { Media.Image.defaults with Kind = Media.Image.Kind.Responsive } |> TestNode
            let imageNode = rootNode.Find(Class "img-responsive")
            Expect.equal (rootNode.Classes()) "figure" "Root should have only class figure"
            Expect.isNonEmpty imageNode "There should be a img-responsive found"
             
            let rootNode = Media.Image.ƒ { Media.Image.defaults with Kind = Media.Image.Kind.Contain } |> TestNode
            let imageNode = rootNode.Find(Class "img-fit-contain")
            Expect.equal (rootNode.Classes()) "figure" "Root should have only class figure"
            Expect.isNonEmpty imageNode "There should be a img-fit-contain found"
            
            let rootNode = Media.Image.ƒ { Media.Image.defaults with Kind = Media.Image.Kind.Cover } |> TestNode
            let imageNode = rootNode.Find(Class "img-fit-cover")
            Expect.equal (rootNode.Classes()) "figure" "Root should have only class figure"
            Expect.isNonEmpty imageNode "There should be a img-fit-cover found"
        }
    ]
    
[<FTests>]
let figureTests =
    testList "Figure tests" [
        test "Figure should display defaults" {
            let rootNode = Media.Figure.ƒ Media.Figure.defaults |> TestNode
            Expect.equal (rootNode.Classes()) "figure" "Root should have only class figure"
            
//            let imageNode = rootNode.Find(Class "img-responsive")
//            Expect.isNonEmpty imageNode "There should be a img-responsive found"
        }
    
        test "Figure should have html props" {
            let rootNode = Media.Figure.ƒ { Media.Figure.defaults with HTMLProps = [Id "messi-argentina.jpg"] } |> TestNode
            Expect.contains (rootNode.Props()) (upcast Id "messi-argentina.jpg") "Figure node should contain id" 
        }
        
        test "Figure does contain caption" {
            let expectedCaptionProps = { Media.Caption.defaults with Text = [R.str "Ronaldo 9"]}
            let rootNode = Media.Figure.ƒ { Media.Figure.defaults with Caption = expectedCaptionProps} |> TestNode
            let foundCaptionNode = rootNode.Find(Class "figure-caption")
            
            Expect.isNonEmpty foundCaptionNode "There should be captionNode"
            
            let foundCaptionNode = Seq.head foundCaptionNode
            let expectedCaptionNode = Media.Caption.ƒ expectedCaptionProps |> TestNode
            
            Expect.nodeEqual expectedCaptionNode foundCaptionNode
        }
    ]


        
//        test "Equal Elements with simple props are equal" {
//            let captionProps = { Media.Caption.defaults with Text = [R.str "Ronaldo 9"]}
//            let rootNode = Media.Figure.ƒ { Media.Figure.defaults with Caption = captionProps} |> TestNode
//            let captionNode = rootNode.Find(Class "figure-caption")
//            Expect.isNonEmpty captionNode "There should be captionNode"
//            
//            let captionNode = Seq.head captionNode
//
//            let captionNd = 
//                Media.Caption.ƒ 
//                    { captionProps with 
//                        Text = [R.str "Ronaldo 9"]
//                        HTMLProps = [Id "hello"]
//                    } |> TestNode
//
//            Expecto.nodeEqual captionNode captionNd
//        }
//        
//        test "Figure does contain caption" {
//            let captionProps = { Media.Caption.defaults with Text = [R.str "Ronaldo 9"]}
//            let rootNode = Media.Figure.ƒ { Media.Figure.defaults with Caption = captionProps} |> TestNode
//            let captionNode = rootNode.Find(Class "figure-caption")
//            Expect.isNonEmpty captionNode "There should be captionNode"
//            
//            let captionNode = Seq.head captionNode
////            Expect.equal (captionNode.Text()) "Ronaldo 9" ""
//
//            let captionNd = 
//                Media.Caption.ƒ 
//                    { captionProps with 
//                        Text = [R.str "Ronaldo 9"]
//                        HTMLProps = [Id "hello"]
//                    } |> TestNode
//
//            Expecto.nodeEqual captionNode captionNd
//        }
        

        
//        
//        test "Media.Image without caption" {
//            let rootNode = Media.Image.ƒ Media.Image.defaults |> TestNode
//            let captionNode = rootNode.Find(Class "figure-caption")
//            Expect.isEmpty captionNode "There should be captionNode"
//        }
    
    
    
    