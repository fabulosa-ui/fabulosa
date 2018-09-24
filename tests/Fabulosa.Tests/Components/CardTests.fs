﻿module CardTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Card tests" [

        test "Card default" {
            Card.ƒ
                (Card.props, Card.children)
            |> ReactNode.unit
            |> hasUniqueClass "card"
        }

        test "Card html props" {
            Card.ƒ
                ({ Card.props with 
                      HTMLProps = [ ClassName "custom" ] },
                  Card.children)
            |> ReactNode.unit
            |> hasClass "card custom"
        }

        test "Card with children" {
            let body = R.p [] [R.str "Body" ]
            let footer =
                Button.ƒ
                    (Button.props,
                      [ R.str "Footer" ])
            let imageProps =
                { Media.Image.props with
                    HTMLProps =  [ Src "bla.png" ] }
            let image = Media.Image.ƒ imageProps |> ReactNode.unit
            Card.ƒ
                (Card.props,
                  { Header =
                      { Title = "Title" 
                        SubTitle = "Sub title" }
                    Body =
                      [ body ]
                    Footer =
                      [ footer ]
                    Image = imageProps })
            |> ReactNode.unit
            |>! hasOrderedDescendentClass 1 "card-header card-title card-subtitle card-image card-body card-footer"
            |>! hasChild 1 image
            |>! hasChild 1 (body |> ReactNode.unit)
            |> hasChild 1 (footer |> ReactNode.unit)
        }

    ]