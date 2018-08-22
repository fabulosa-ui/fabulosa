module TableTests

open Expecto
open ReactNode
open Fable.Helpers.React.Props
open Fabulosa
module R = Fable.Helpers.React
open Fabulosa.Tests.Extensions.TestNodeExtensions

[<Tests>]
let tests =
    testList "Table tests" [

        test "Table default" {
            let table = Table.ƒ Table.defaults []
            table |> hasClasses ["table"]
        }

        test "Table kind striped" {
            let table =
                Table.ƒ {
                    Table.defaults with
                        Kind = Table.Kind.Striped
                } []
            table |> hasClasses ["table-striped"]
        }

        test "Table kind hover" {
            let table =
                Table.ƒ {
                    Table.defaults with
                        Kind = Table.Kind.Hover
                } []
            table |> hasClasses ["table-hover"]
        }

        test "Table children with name" {
            let props = Table.defaults
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            let table = Table.ƒ props [child]
            table |> hasDescendent child
            table |> hasDescendent grandChild
        }

        test "Table children with class" {
            let props = Table.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let table = Table.ƒ props [child]
            table |> hasDescendent child
            table |> hasDescendent grandChild
        }

        test "Head html props" {
            let head =
                Table.Head.ƒ { 
                    Table.Head.defaults with
                        HTMLProps = [ClassName "custom"]
                } []
            head |> hasClasses ["custom"]
        }

        test "Head children" {
            let props = Table.Head.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let head = Table.Head.ƒ props [child]
            head |> hasDescendent child
            head |> hasDescendent grandChild
        }

        test "Body html props" {
            let body =
                Table.Body.ƒ { 
                    Table.Body.defaults with
                        HTMLProps = [ClassName "custom"]
                } []
            body |> hasClasses ["custom"]
        }

        test "Body children" {
            let props = Table.Body.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let table = Table.Body.ƒ props [child]
            table |> hasDescendent child
            table |> hasDescendent grandChild
        }

        test "Row html props" {
            let row =
                Table.Row.ƒ { 
                    Table.Row.defaults with
                        HTMLProps = [ClassName "custom"]
                } []
            row |> hasClasses ["custom"]
        }

        test "Row children" {
            let props = Table.Row.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let row = Table.Row.ƒ props [child]
            row |> hasDescendent child
            row |> hasDescendent grandChild
        }

        test "Row active" {
            let row =
                Table.Row.ƒ {
                    Table.Row.defaults with
                        Active = true
                } []
            row |> hasClasses ["active"]
        }

        test "Column html props" {
            let column =
                Table.Column.ƒ { 
                    Table.Column.defaults with
                        HTMLProps = [ClassName "custom"]
                } []
            column |> hasClasses ["custom"]
        }

        test "Column children" {
            let props = Table.Column.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let column = Table.Column.ƒ props [child]
            column |> hasDescendent child
            column |> hasDescendent grandChild
        }

        test "Title column html props" {
            let titleColumn =
                Table.TitleColumn.ƒ { 
                    Table.TitleColumn.defaults with
                        HTMLProps = [ClassName "custom"]
                } []
            titleColumn |> hasClasses ["custom"]
        }

        test "Title column children" {
            let props = Table.TitleColumn.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let titleColumn = Table.TitleColumn.ƒ props [child]
            titleColumn |> hasDescendent child
            titleColumn |> hasDescendent grandChild
        }
    ]