module BarTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Bar tests" [

        test "Bar default" {
            let item = Bar.Item.ƒ Bar.Item.defaults
            let bar = Bar.ƒ Bar.defaults [item]
            
            bar
            |> ReactNode.unit
            |>! hasUniqueClass "bar"
            |>! hasChild 1 (item |> ReactNode.unit)
            |> hasDescendentClass "bar-item"
        }

        // test "Button custom class" {
        //     let child = R.div [] [R.str "text"]
        //     let button =
        //         Button.ƒ
        //             { Button.defaults with
        //                 HTMLProps = [ClassName "custom"] }
        //             [child]
            
        //     button
        //     |> ReactNode.unit
        //     |> hasClass "custom"
        // }
    ]