namespace Fabulosa

open Fable.Helpers
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

    let input inputProps =
        ["form-input"]
        @ List.map propToClass inputProps
        |> addClassesToProps
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

    let makeIcon icon =
        let (element, classes, children) = extract icon
        React.domEl element [className <| classes + " form-icon"] children
        
    let iconInput props htmlProps (children: ReactElement list) =
        let newProps =
            addClassesToProps
            <| List.map propToClass props
            <| htmlProps
        R.div newProps [
            children.[0]
            makeIcon children.[1]
        ]
