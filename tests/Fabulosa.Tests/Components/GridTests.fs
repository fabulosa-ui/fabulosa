module GridTests

open Expecto
open ReactNode
open Fable.Helpers.React.Props
open Fabulosa
module R = Fable.Helpers.React
open Fabulosa.Tests.Extensions.TestNodeExtensions


[<Tests>]
let tests =
    testList "Grid tests" [

        test "Grid default" {
            let grid = Grid.ƒ Grid.defaults []
            grid |> hasClasses ["container"]
        }

        test "Grid children with name" {
            let props = Grid.defaults
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            let grid = Grid.ƒ props [child]
            grid |> hasDescendent child
            grid |> hasDescendent grandChild
        }

        test "Grid children with class" {
            let props = Grid.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let grid = Grid.ƒ props [child]
            grid |> hasDescendent child
            grid |> hasDescendent grandChild
        }

        test "Row default" {
            let row = Grid.Row.ƒ Grid.Row.defaults []
            row |> hasClasses ["columns"]
        }

        test "Row children with name" {
            let props = Grid.Row.defaults
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            let row = Grid.Row.ƒ props [child]
            row |> hasDescendent child
            row |> hasDescendent grandChild
        }

        test "Row children with class" {
            let props = Grid.Row.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let row = Grid.Row.ƒ props [child]
            row |> hasDescendent child
            row |> hasDescendent grandChild
        }

        test "Row gapless" {
            let row =
                Grid.Row.ƒ {
                    Grid.Row.defaults with
                        Gapless = true
                } []
            row |> hasClasses ["col-gapless"]
        }

        test "Row one line" {
            let row =
                Grid.Row.ƒ {
                    Grid.Row.defaults with
                        OneLine = true
                } []
            row |> hasClasses ["col-oneline"]
        }

        test "Column default" {
            let column = Grid.Column.ƒ Grid.Column.defaults []
            column |> hasClasses ["column"]
        }

        test "Column size" {
            let column =
                Grid.Column.ƒ {
                    Grid.Column.defaults with
                        Size = 4
                } []
            column |> hasClasses ["col-4"]
        }

        test "Column medium size" {
            let column =
                Grid.Column.ƒ {
                    Grid.Column.defaults with
                        MDSize = 4
                } []
            column |> hasClasses ["col-md-4"]
        }

        test "Column kind" {
            let column =
                Grid.Column.ƒ {
                    Grid.Column.defaults with
                        Kind = Grid.Column.Kind.MLAuto
                } []
            column |> hasClasses ["col-ml-auto"]
        }

        test "Column children with name" {
            let props = Grid.Column.defaults
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            let column = Grid.Column.ƒ props [child]
            column |> hasDescendent child
            column |> hasDescendent grandChild
        }

        test "Column children with class" {
            let props = Grid.Column.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let column = Grid.Column.ƒ props [child]
            column |> hasDescendent child
            column |> hasDescendent grandChild
        }

    ]