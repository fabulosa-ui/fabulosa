namespace Fabulosa

[<RequireQualifiedAccess>]
module Input =

    open ClassNames
    module R = Fable.Helpers.React

    type Size =
    | Small
    | Large

    type Prop =
    | Size of Size

    let propToClass =
        function
        | Size Small -> "input-sm"
        | Size Large -> "input-lg"

    let input props =
        ["form-input"]
        @ List.map propToClass props
        |> combineProps
        >> R.input

[<RequireQualifiedAccess>]
module IconInput =

    open ClassNames
    open ReactAPIExtensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    
    type Position =
    | Left
    | Right

    type Prop =
    | Position of Position

    let propToClass =
        function
        | Position Left -> "has-icon-left"
        | Position Right -> "has-icon-right"

    let iconPropToClass =
        function
        | _ -> "form-icon"

    let makeIcon =
        transform (fun _ -> "form-icon") [""]

    let iconInput props htmlProps (children: ReactElement list) =
        let newProps =
            combineProps
            <| List.map propToClass props
            <| htmlProps
        R.div newProps [
            children.[0]
            makeIcon children.[1]
        ]
