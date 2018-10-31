module NavTests

open Expecto
open Fabulosa
open Fabulosa.Nav
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Nav tests" [

        test "Nav default" {
            nav ([], [])
            |> ReactNode.unit
            |> hasUniqueClass "nav"
        }

        test "Nav html props" {
            nav ([ ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Nav item text" {
            let text = "Item"
            nav ([], [ Item ([], Text text) ])
            |> ReactNode.unit
            |> hasText text
        }

        test "Nav item html props" {
            let href = "https://google.com"
            nav ([], [ Item ([ Href href ], Text "Text") ])
            |> ReactNode.unit
            |> hasDescendentProp (Href href)
        }

        test "Nav multiple items" {
            let text1 = "Item 1"
            let href1 = "https://google.com"
            let text2 = "Item 2"
            let href2 = "https://bing.com"
            nav ([],
                [ Item ([ Href href1 ], Text text1)
                  Item ([ Href href2 ], Text text2) ])
            |> ReactNode.unit
            |>! hasOrderedDescendentClass 2 "nav-item"
            |>! hasDescendentProp (Href href1)
            |>! hasDescendentProp (Href href2)
            |> hasText (String.concat " " [ text1; text2 ])
        }

        test "Nav multiple nested items" {
            let text1 = "Item 1"
            let href1 = "https://google.com"
            let text2 = "Item 2"
            let href2 = "https://bing.com"
            let text3 = "Item 3"
            let href3 = "https://yahoo.com"
            nav ([],
                [ Item ([ Href href1 ], Text text1)
                  Nav ([], [ Item ([ Href href3], Text text3) ])
                  Item ([ Href href2 ], Text text2) ])
            |> ReactNode.unit
            |>! hasOrderedDescendentClass 3 "nav-item"
            |>! hasDescendentProp (Href href1)
            |>! hasDescendentProp (Href href2)
            |>! hasDescendentProp (Href href3)
            |> hasText (String.concat " " [ text1; text3; text2 ])
        }

    ]