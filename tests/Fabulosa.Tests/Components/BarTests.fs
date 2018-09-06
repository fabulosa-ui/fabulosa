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
            Bar.ƒ Bar.defaults [item]
            |> ReactNode.unit
            |>! hasUniqueClass "bar"
            |>! hasChild 1 (item |> ReactNode.unit)
            |> hasDescendentClass "bar-item"
        }

        test "Bar small" {
            Bar.ƒ { 
                Bar.defaults with
                    Small = true
            } []
            |> ReactNode.unit
            |> hasClass "bar bar-sm"
        }

        test "Bar html props" {
            Bar.ƒ {
                Bar.defaults with 
                    HTMLProps = [ClassName "custom"]
            } []
            |> ReactNode.unit
            |> hasClass "bar custom"
        }

        test "Bar item default" {
            Bar.Item.ƒ Bar.Item.defaults
            |> ReactNode.unit
            |> hasUniqueClass "bar-item"
        }

        test "Bar item html props" {
            Bar.Item.ƒ {
                Bar.Item.defaults with
                    HTMLProps = [ClassName "custom"]
            }
            |> ReactNode.unit
            |> hasClass "bar-item custom"
        }

        test "Bar item percentage" {
            Bar.Item.ƒ {
                Bar.Item.defaults with
                    Value = 25
            }
            |> ReactNode.unit
            |> hasProp (Style [Width "25%"])
        }

        test "Bar item tooltip" {
            Bar.Item.ƒ {
                Bar.Item.defaults with
                    Value = 25
                    Tooltip = true
            }
            |> ReactNode.unit
            |>! hasClass "bar-item tooltip"
            |>! hasProp (Style [Width "25%"])
            |> hasProp (Data ("tooltip", "25%"))
        }
    ]