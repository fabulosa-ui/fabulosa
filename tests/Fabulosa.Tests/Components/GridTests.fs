module GridTests

open Grid
open Expecto
open ReactNode
open Fable.Helpers.React.Props
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Grid tests" [

        test "Grid should be a react html node" {
            let node = R.Node ("div", [ClassName "container"], [])
            let subject = grid [] []
            compareNode subject node
        }

        test "Columns props should map to classes" {
            let columnsProps = [ColumnsKind ColumnsGapless]
            let subject = List.map columnsClasses columnsProps
            Expect.contains subject "col-gapless" "Should contain columns gapless class"
        }

        test "Columns should be a react html node" {
            let node = R.Node ("div", [ClassName "columns"], [])
            let subject = columns [] [] []
            compareNode subject node
        }

        test "Column props should map to classes" {
            let columnProps = [ColumnKind ColumnMLAuto; ColumnSize 3; ColumnMediumSize 5]
            let subject = List.map columnClasses columnProps
            Expect.containsAll subject ["col-ml-auto"; "col-3"; "col-md-5"] "Should contain column classes"
        }

        test "Column should be a react html node" {
            let node = R.Node ("div", [ClassName "column"], [])
            let subject = column [] [] []
            compareNode subject node
        }

    ]