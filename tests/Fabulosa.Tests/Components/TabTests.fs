module TabTests

open Expecto
open Fabulosa
open Fabulosa.Tab
module R = Fable.Helpers.React
open R.Props
open Expect


[<Tests>]
let tests =
    testList "Tab tests" [

        test "Tab default" {
           tab ([], [])
            |> ReactNode.unit
            |> hasUniqueClass "tab"
        }

        test "Tab html props" {
            tab ([ ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Tab block" {
           tab ([ Block ], [])
            |> ReactNode.unit
            |> hasClass "tab-block"
        }
       
        test "Tab children" {
            let item = ([], [ R.a [] [ R.str "Tab" ] ])
            tab ([], [ Item item ])
            |> ReactNode.unit
            |> hasChild 1 (tabItem item |> ReactNode.unit)
        }

        test "Tab item defaults" {
            let child = R.a [] [ R.str "Tab" ]
            tabItem ([], [ child ])
            |> ReactNode.unit
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Tab item active" {
            tabItem ([ Active ], [])
            |> ReactNode.unit
            |> hasClass "active"
        }
        
    ]