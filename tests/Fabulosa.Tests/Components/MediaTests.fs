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
            let captionElement = Media.Caption.ƒ Media.Caption.defaults
            
            captionElement
            |> Expect.containsClassNameBind "figure-caption text-center"
            |> Expect.containsText "" 
        }
       
        test "Caption should have html props" {
            let captionElement = Media.Caption.ƒ { Media.Caption.defaults with HTMLProps = [Id "offside-is-a-crime"]}
            
            captionElement
            |> Expect.containsClassNameBind "figure-caption text-center"
            |> Expect.containsPropBind (Id "offside-is-a-crime")
            |> Expect.containsText ""
        }
       
        test "Caption should have text alignment set to input" {
            let captionElement = Media.Caption.ƒ { Media.Caption.defaults with TextDirection = Media.Caption.Center}
            
            Expect.containsClassName "figure-caption text-center" captionElement
           
            let captionElement = Media.Caption.ƒ { Media.Caption.defaults with TextDirection = Media.Caption.Left}
            
            Expect.containsClassName "figure-caption text-left" captionElement
           
            let captionElement = Media.Caption.ƒ { Media.Caption.defaults with TextDirection = Media.Caption.Right}
            
            Expect.containsClassName "figure-caption text-right" captionElement
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
            let imageElement = Media.Image.ƒ Media.Image.defaults
            Expect.hasUniqueClass "img-responsive" imageElement  
        }
        
        test "Image should be respond to different kinds" {
            let imageElement = 
               Media.Image.ƒ { Media.Image.defaults with Kind = Media.Image.Kind.Responsive } 
               
            Expect.hasUniqueClass "img-responsive" imageElement
            
            let imageElement = 
               Media.Image.ƒ { Media.Image.defaults with Kind = Media.Image.Kind.Contain } 
            Expect.hasUniqueClass "img-fit-contain" imageElement
            
            let imageElement = 
               Media.Image.ƒ { Media.Image.defaults with Kind = Media.Image.Kind.Cover } 
            Expect.hasUniqueClass "img-fit-cover" imageElement
        }
    ]
    
[<Tests>]
let figureTests =
    testList "Figure tests" [
        test "Figure should display defaults" {
            let figureElement = Media.Figure.ƒ Media.Figure.defaults
            let captionElement = Media.Caption.ƒ Media.Caption.defaults
            let imageElement = Media.Image.ƒ Media.Image.defaults
            
            figureElement
            |> Expect.hasUniqueClassBind "figure"
            |> Expect.containsChildBind 1 captionElement 
            |> Expect.containsChild 1 imageElement 
        }
   
        test "Figure should have html props" {
            let figureElement = 
                Media.Figure.ƒ { Media.Figure.defaults with HTMLProps = [Id "messi-argentina.jpg"] } 

            Expect.containsProp (Id "messi-argentina.jpg") figureElement
        }
       
        test "Figure does contain props" {
            let expectedCaptionProps = { Media.Caption.defaults with Text = [R.str "Ronaldo 9"]}
            let expectedImageProps = { Media.Image.defaults with Kind = Media.Image.Kind.Cover}
            let captionElement = Media.Caption.ƒ expectedCaptionProps
            let imageElement = Media.Image.ƒ expectedImageProps
           
            let figureElement = Media.Figure.ƒ { 
                Media.Figure.defaults with 
                    Caption = expectedCaptionProps
                    Image = expectedImageProps
            }
            
            figureElement 
            |> Expect.hasUniqueClassBind "figure"
            |> Expect.containsChildBind 1 captionElement
            |> Expect.containsChild 1 imageElement
        }
    ]
    