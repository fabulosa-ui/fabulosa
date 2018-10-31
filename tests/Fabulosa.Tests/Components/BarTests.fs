module BarTests

open Expecto
open Fabulosa
open Fabulosa.Bar
module R = Fable.Helpers.React
module P = R.Props
open Expect


[<Tests>]
let tests =
    testList "Bar tests" [

        test "Bar default" {
            let item = ([], Value 10)
            bar ([], [ Item item ])
            |> ReactNode.unit
            |>! hasUniqueClass "bar"
            |>! hasChild 1 (barItem item |> ReactNode.unit)
            |> hasDescendentClass "bar-item"
        }

        test "Bar multiple" {
            let item1 = ([], Value 25)
            let item2 = ([], Value 20)
            bar ([], [ Item item1; Item item2 ])
            |> ReactNode.unit
            |>! hasUniqueClass "bar"
            |>! hasChild 1
                (barItem item1 |> ReactNode.unit)
            |>! hasChild 1
                (barItem item2 |> ReactNode.unit)
            |> hasOrderedDescendentClass 2 "bar-item"
        }

        test "Bar small" {
            bar ([ Small ], [])
            |> ReactNode.unit
            |> hasClass "bar bar-sm"
        }

        test "Bar html props" {
            bar ([ P.ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "bar custom"
        }

        test "Bar item default" {
            barItem ([], Value 10)
            |> ReactNode.unit
            |> hasUniqueClass "bar-item"
        }

        test "Bar item html props" {
            barItem ([ P.ClassName "custom" ], Value 10)
            |> ReactNode.unit
            |> hasClass "bar-item custom"
        }

        test "Bar item percentage" {
            barItem ([], Value 25)
            |> ReactNode.unit
            |> hasProp (P.Style [ P.CSSProp.Width "25%" ])
        }

        test "Bar item tooltip" {
            barItem ([ Tooltip ], Value 25)
            |> ReactNode.unit
            |>! hasClass "bar-item tooltip"
            |>! hasProp (P.Style [ P.CSSProp.Width "25%" ])
            |> hasProp (P.Data ("tooltip", "25%"))
        }

        //test "Bar slider default" {
        //    let but =
        //        button
        //            ([ P.ClassName "bar-slider-btn" ], [])
        //    Bar.Slider.ƒ ([], [ ([], []) ])
        //    |> ReactNode.unit
        //    |>! hasClass "bar bar-slider"
        //    |>! hasChild 1 (barItem ([], [ but ]) |> ReactNode.unit)
        //    |> hasDescendentClass "bar-item bar-slider-btn"
        //}

        //test "Bar slider multiple" {
        //    let but =
        //        button
        //            ([ P.ClassName "bar-slider-btn" ], [] )
        //    let item1 = ([], Value 25}, [ but ])
        //    let item2 = ([], Value 20}, [ but])
        //    Bar.Slider.ƒ (Bar.Slider.props, [item1; item2])
        //    |> ReactNode.unit
        //    |>! hasClass "bar bar-slider"
        //    |>! hasChild 1
        //        (barItem item1 |> ReactNode.unit)
        //    |>! hasChild 1
        //        (barItem item2 |> ReactNode.unit)
        //    |> hasOrderedDescendentClass 2 "bar-item bar-slider-btn"
        //}
    ]