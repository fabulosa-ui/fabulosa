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
            Bar.ƒ Bar.defaults [Bar.Item.defaults]
            |> ReactNode.unit
            |>! hasUniqueClass "bar"
            |>! hasChild 1
                (Bar.Item.ƒ Bar.Item.defaults [] |> ReactNode.unit)
            |> hasDescendentClass "bar-item"
        }

        test "Bar multiple" {
            let item1 = {Bar.Item.defaults with Value = 25}
            let item2 = {Bar.Item.defaults with Value = 20}
            Bar.ƒ Bar.defaults [item1; item2]
            |> ReactNode.unit
            |>! hasUniqueClass "bar"
            |>! hasChild 1
                (Bar.Item.ƒ item1 [] |> ReactNode.unit)
            |>! hasChild 1
                (Bar.Item.ƒ item2 [] |> ReactNode.unit)
            |> hasOrderedDescendentClass 2 "bar-item"
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
            Bar.Item.ƒ Bar.Item.defaults []
            |> ReactNode.unit
            |> hasUniqueClass "bar-item"
        }

        test "Bar item html props" {
            Bar.Item.ƒ {
                Bar.Item.defaults with
                    HTMLProps = [ClassName "custom"]
            } []
            |> ReactNode.unit
            |> hasClass "bar-item custom"
        }

        test "Bar item percentage" {
            Bar.Item.ƒ {
                Bar.Item.defaults with
                    Value = 25
            } []
            |> ReactNode.unit
            |> hasProp (Style [Width "25%"])
        }

        test "Bar item tooltip" {
            Bar.Item.ƒ {
                Bar.Item.defaults with
                    Value = 25
                    Tooltip = true
            } []
            |> ReactNode.unit
            |>! hasClass "bar-item tooltip"
            |>! hasProp (Style [Width "25%"])
            |> hasProp (Data ("tooltip", "25%"))
        }

        test "Bar slider default" {
            let button =
                Button.ƒ
                    ( { Button.defaults with
                          HTMLProps = [ ClassName "bar-slider-btn" ] },
                      [] )
            Bar.Slider.ƒ Bar.defaults [Bar.Item.defaults]
            |> ReactNode.unit
            |>! hasClass "bar bar-slider"
            |>! hasChild 1
                (Bar.Item.ƒ Bar.Item.defaults [button] |> ReactNode.unit)
            |> hasDescendentClass "bar-item bar-slider-btn"
        }

        test "Bar slider multiple" {
            let button =
                Button.ƒ
                    ( { Button.defaults with
                          HTMLProps = [ ClassName "bar-slider-btn" ] },
                      [] )
            let item1 = {Bar.Item.defaults with Value = 25}
            let item2 = {Bar.Item.defaults with Value = 20}
            Bar.Slider.ƒ Bar.Slider.defaults [item1; item2]
            |> ReactNode.unit
            |>! hasClass "bar bar-slider"
            |>! hasChild 1
                (Bar.Item.ƒ item1 [button] |> ReactNode.unit)
            |>! hasChild 1
                (Bar.Item.ƒ item2 [button] |> ReactNode.unit)
            |> hasOrderedDescendentClass 2 "bar-item bar-slider-btn"
        }
    ]