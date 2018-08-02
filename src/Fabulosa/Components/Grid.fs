namespace Fabulosa

[<RequireQualifiedAccess>]
module Grid =

    module R = Fable.Helpers.React

    open ClassNames

    let grid =
        ["container"]
        |> combineProps
        >> R.div

    [<RequireQualifiedAccess>]
    module Row =

        type Kind =
        | Gapless
        | OneLine

        type Props =
        | Kind of Kind

        let propToClass =
            function
            | Kind Gapless -> "col-gapless"
            | Kind OneLine -> "col-oneline"

    let row props =
        ["columns"] @ List.map Row.propToClass props
        |> combineProps
        >> R.div

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

        let propToClass =
            function
            | Kind MLAuto -> "col-ml-auto"
            | Kind MRAuto -> "col-mr-auto"
            | Kind MXAuto -> "col-mx-auto"
            | Size n -> "col-" + n.ToString()
            | SmallSize n -> "col-sm-" + n.ToString() 
            | MediumSize n -> "col-md-" + n.ToString() 
            | LargeSize n -> "col-lg-" + n.ToString() 

    let column props =
        ["column"] @ List.map Column.propToClass props
        |> combineProps
        >> R.div 