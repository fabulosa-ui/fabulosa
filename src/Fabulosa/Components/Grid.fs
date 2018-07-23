module Grid

module R = Fable.Helpers.React

open ClassNames

[<RequireQualifiedAccess>]
module Grid =

    let grid htmlProps children =
        let props = mergeClasses <| htmlProps <| ["container"]
        R.div props children

[<RequireQualifiedAccess>]
module Columns =

    type Kind =
    | Gapless
    | OneLine

    type Props =
    | Kind of Kind

    let classes =
        function
        | Kind Gapless -> "col-gapless"
        | Kind OneLine -> "col-oneline"

    let columns columnsProps htmlProps children =
        let props = mergeClasses <| htmlProps <| ["columns"] @ List.map classes columnsProps
        R.div props children

[<RequireQualifiedAccess>]
module Column =

    type Kind =
    | MLAuto
    | MRAuto
    | MXAuto

    type Prop =
    | Kind of Kind
    | Size of int
    | SmallSize of int
    | MediumSize of int
    | LargeSize of int

    let classes =
        function
        | Kind MLAuto -> "col-ml-auto"
        | Kind MRAuto -> "col-mr-auto"
        | Kind MXAuto -> "col-mx-auto"
        | Size n -> "col-" + n.ToString()
        | SmallSize n -> "col-sm-" + n.ToString() 
        | MediumSize n -> "col-md-" + n.ToString() 
        | LargeSize n -> "col-lg-" + n.ToString() 

    let column columnProps htmlProps children =
        let props = mergeClasses <| htmlProps <| ["column"] @ List.map classes columnProps
        R.div props children