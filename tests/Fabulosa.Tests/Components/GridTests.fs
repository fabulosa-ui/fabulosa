module GridTests

open Expecto
open Fable.Helpers.React.Props
open Fabulosa
open Expect
module R = Fable.Helpers.React


[<Tests>]
let tests =
    testList "Grid tests" [

        test "Grid default" {
            Grid.ƒ Grid.defaults []
            |> ReactNode.unit
            |> hasUniqueClass "container"
        }

        test "Grid html props" {
            Grid.ƒ
                { Grid.defaults with
                    HTMLProps = [ ClassName "custom" ] }
                []
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Grid row" {
            let props = Grid.Row.defaults
            let children = []
            let row = Grid.Row.ƒ props children
            Grid.ƒ
                Grid.defaults
                [ props, children ]
            |> ReactNode.unit
            |> hasChild 1 (row |> ReactNode.unit)
        }

        test "Grid row html props" {
            let props =
                { Grid.Row.defaults with
                    HTMLProps = [ClassName "custom"] }
            let children = []
            let row = Grid.Row.ƒ props children
            Grid.ƒ
                Grid.defaults
                [ props, children ]
            |> ReactNode.unit
            |> hasChild 1 (row |> ReactNode.unit)
        }

        // test "Row default" {
        //     let row = Grid.Row.ƒ Grid.Row.defaults []

        //     row
        //     |> ReactNode.unit
        //     |> hasUniqueClass "columns"
        // }

        // test "Row children with name" {
        //     let props = Grid.Row.defaults
        //     let grandChild = R.span [] []
        //     let child = R.div [] [grandChild]
        //     let row = Grid.Row.ƒ props [child]
            
        //     row
        //     |> ReactNode.unit
        //     |>! hasChild 1 (child |> ReactNode.unit)
        //     |> hasChild 1 (grandChild |> ReactNode.unit)
        // }

        // test "Row children with class" {
        //     let props = Grid.Row.defaults
        //     let grandChild = R.span [ClassName "grand-child"] []
        //     let child = R.div [ClassName "child"] [grandChild]
        //     let row = Grid.Row.ƒ props [child]

        //     row
        //     |> ReactNode.unit
        //     |>! hasChild 1 (child |> ReactNode.unit)
        //     |> hasChild 1 (grandChild |> ReactNode.unit)
        // }

        // test "Row gapless" {
        //     let row =
        //         Grid.Row.ƒ {
        //             Grid.Row.defaults with
        //                 Gapless = true
        //         } []
            
        //     row
        //     |> ReactNode.unit
        //     |> hasClass "columns col-gapless"
        // }

        // test "Row one line" {
        //     let row =
        //         Grid.Row.ƒ {
        //             Grid.Row.defaults with
        //                 OneLine = true
        //         } []

        //     row
        //     |> ReactNode.unit
        //     |> hasClass "columns col-oneline"
        // }

        // test "Column default" {
        //     let column = Grid.Column.ƒ Grid.Column.defaults []

        //     column
        //     |> ReactNode.unit
        //     |> hasClass "column col-12 col-xs-0 col-sm-0 col-md-0 col-lg-0 col-xl-0"
        // }

        // test "Column size" {
        //     let column =
        //         Grid.Column.ƒ {
        //             Grid.Column.defaults with
        //                 Size = 4
        //         } []

        //     column
        //     |> ReactNode.unit
        //     |> hasClass "col-4"
        // }

        // test "Column medium size" {
        //     let column =
        //         Grid.Column.ƒ {
        //             Grid.Column.defaults with
        //                 MDSize = 4
        //         } []

        //     column
        //     |> ReactNode.unit
        //     |> hasClass "col-md-4"
        // }

        // test "Column kind" {
        //     let column =
        //         Grid.Column.ƒ {
        //             Grid.Column.defaults with
        //                 Kind = Grid.Column.Kind.MLAuto
        //         } []

        //     column
        //     |> ReactNode.unit
        //     |> hasClass "col-ml-auto"
        // }

        // test "Column children with name" {
        //     let props = Grid.Column.defaults
        //     let grandChild = R.span [] []
        //     let child = R.div [] [grandChild]
        //     let column = Grid.Column.ƒ props [child]

        //     column
        //     |> ReactNode.unit
        //     |>! hasChild 1 (child |> ReactNode.unit)
        //     |> hasChild 1 (grandChild |> ReactNode.unit)
        // }

        // test "Column children with class" {
        //     let props = Grid.Column.defaults
        //     let grandChild = R.span [ClassName "grand-child"] []
        //     let child = R.div [ClassName "child"] [grandChild]
        //     let column = Grid.Column.ƒ props [child]

        //     column
        //     |> ReactNode.unit
        //     |>! hasChild 1 (child |> ReactNode.unit)
        //     |> hasChild 1 (grandChild |> ReactNode.unit)
        // }

    ]