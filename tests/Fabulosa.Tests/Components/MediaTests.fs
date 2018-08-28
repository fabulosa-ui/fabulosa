module MediaTests

open Expecto
open Expect
open Fabulosa
module R = Fable.Helpers.React
open R.Props

[<Tests>]
let captionTest =
    testList "Caption tests" [

        test "Caption should be a react html node when defaults are provided" {
            let captionElement = Media.Caption.ƒ Media.Caption.defaults
            
            captionElement
            |> ReactNode.unit
            >>= hasClass "figure-caption text-center"
            |> hasText "" 
        }
       
        test "Caption should have html props" {
            let captionElement =
                Media.Caption.ƒ {
                    Media.Caption.defaults with
                        HTMLProps = [Id "offside-is-a-crime"]
                }
            
            captionElement
            |> ReactNode.unit
            >>= hasClass "figure-caption text-center"
            >>= hasProp (Id "offside-is-a-crime")
            |> hasText ""
        }
       
        test "Caption should have text alignment set to input" {
            let captionElement = Media.Caption.ƒ {
                Media.Caption.defaults with
                    TextDirection = Media.Caption.Center
            }
            
            captionElement
            |> ReactNode.unit
            |> hasClass "figure-caption text-center"
           
            let captionElement =
                Media.Caption.ƒ {
                    Media.Caption.defaults with
                        TextDirection = Media.Caption.Left
                }
            
            captionElement
            |> ReactNode.unit
            |> hasClass "figure-caption text-left"
           
            let captionElement =
                Media.Caption.ƒ {
                    Media.Caption.defaults with
                        TextDirection = Media.Caption.Right
                }
            
            captionElement
            |> ReactNode.unit
            |> hasClass "figure-caption text-right"
        }
       
        test "Caption should display custom text" {
            let text = "Pele is the King!"
            let rootNode =
                Media.Caption.ƒ {
                    Media.Caption.defaults with
                        Text = [R.str text]
                }
            
            rootNode
            |> ReactNode.unit
            |> hasText text
           
            let text = "Figueira!!!"
            let rootNode =
                Media.Caption.ƒ {
                    Media.Caption.defaults with
                        Text = [R.div [ClassName "figueirense"] [R.str text]]
                    }

            rootNode
            |> ReactNode.unit
            >>= hasDescendentClass "figueirense"
            |> hasText text
        }
    ] 

[<Tests>]
let imageTest =
    testList "Image tests" [

        test "Image should be a react html node when defaults are provided" {
            let imageElement = Media.Image.ƒ Media.Image.defaults
            imageElement
            |> ReactNode.unit
            |> hasUniqueClass "img-responsive"
        }
        
        test "Image should be respond to different kinds" {
            let imageElement = 
                Media.Image.ƒ {
                    Media.Image.defaults with
                        Kind = Media.Image.Kind.Responsive
                }
               
            imageElement
            |> ReactNode.unit
            |> hasUniqueClass "img-responsive"
            
            let imageElement = 
                Media.Image.ƒ {
                    Media.Image.defaults with
                        Kind = Media.Image.Kind.Contain
                }

            imageElement
            |> ReactNode.unit
            |> hasUniqueClass "img-fit-contain"
            
            let imageElement = 
                Media.Image.ƒ {
                    Media.Image.defaults with
                        Kind = Media.Image.Kind.Cover
                } 
            
            imageElement
            |> ReactNode.unit
            |> hasUniqueClass "img-fit-cover"
        }
    ]
    
[<Tests>]
let figureTests =
    testList "Figure tests" [
        test "Figure should display defaults" {
            let figure =
                Media.Figure.ƒ
                    Media.Figure.defaults
                |> ReactNode.unit
            let caption =
                Media.Caption.ƒ
                    Media.Caption.defaults
                |> ReactNode.unit
            let image =
                Media.Image.ƒ
                    Media.Image.defaults
                |> ReactNode.unit
            
            figure
            >>= hasUniqueClass "figure"
            >>= hasChild 1 caption 
            |> hasChild 1 image 
        }
   
        test "Figure should have html props" {
            let figure = 
                Media.Figure.ƒ {
                    Media.Figure.defaults with
                        HTMLProps = [Id "messi-argentina.jpg"]
                } |> ReactNode.unit 

            figure
            |> hasProp (Id "messi-argentina.jpg") 
        }
       
        test "Figure does contain props" {
            let expectedCaptionProps = {
                Media.Caption.defaults with
                    Text = [R.str "Ronaldo 9"]
            }
            let expectedImageProps = {
                Media.Image.defaults with
                    Kind = Media.Image.Kind.Cover
            }
            let caption =
                Media.Caption.ƒ
                    expectedCaptionProps
                |> ReactNode.unit
            let image =
                Media.Image.ƒ
                    expectedImageProps
                |> ReactNode.unit
            let figure =
                Media.Figure.ƒ { 
                    Media.Figure.defaults with 
                        Caption = expectedCaptionProps
                        Image = expectedImageProps
                } |> ReactNode.unit
            
            figure
            >>= hasUniqueClass "figure"
            >>= hasChild 1 caption
            |> hasChild 1 image
        }
    ]
    