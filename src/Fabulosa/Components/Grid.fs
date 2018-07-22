module Grid

module R = Fable.Helpers.React

open ClassNames

let grid htmlProps children =
    let props = mergeClasses <| htmlProps <| ["container"]
    R.div props children

type ColumnsKind =
| ColumnsGapless
| ColumnsOneLine

type ColumnsProps =
| ColumnsKind of ColumnsKind

let columnsClasses =
    function
    | ColumnsKind ColumnsGapless -> "col-gapless"
    | ColumnsKind ColumnsOneLine -> "col-oneline"

let columns columnsProps htmlProps children =
    let props = mergeClasses <| htmlProps <| ["columns"] @ List.map columnsClasses columnsProps
    R.div props children

type ColumnKind =
| ColumnMLAuto
| ColumnMRAuto
| ColumnMXAuto

type ColumnProp =
| ColumnKind of ColumnKind
| ColumnSize of int
| ColumnSmallSize of int
| ColumnMediumSize of int
| ColumnLargeSize of int

let columnClasses =
    function
    | ColumnKind ColumnMLAuto -> "col-ml-auto"
    | ColumnKind ColumnMRAuto -> "col-mr-auto"
    | ColumnKind ColumnMXAuto -> "col-mx-auto"
    | ColumnSize n -> "col-" + n.ToString()
    | ColumnSmallSize n -> "col-sm-" + n.ToString() 
    | ColumnMediumSize n -> "col-md-" + n.ToString() 
    | ColumnLargeSize n -> "col-lg-" + n.ToString() 

let column columnProps htmlProps children =
    let props = mergeClasses <| htmlProps <| ["column"] @ List.map columnClasses columnProps
    R.div props children