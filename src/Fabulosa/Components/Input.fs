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

    let mapsAny mapping =
        List.choose mapping
        >> List.length
        >> (<) 0

    let input inputProps =
        ["form-input"]
        @ List.map propToClass inputProps
        |> addClassesToProps
        >> R.input

[<RequireQualifiedAccess>]
module IconInput =

    open Fable.Import.React
    open ClassNames
    module R = Fable.Helpers.React
    open Fable.Helpers.React.Props
    open Fable.Helpers

    type P = { className: string }
    type T = { props: P }

    let getClasseNames (reactElement: ReactElement) =
        let element = unbox<T> reactElement
        element.props.className

    type Position =
    | Left
    | Right

    type Prop =
    | Position of Position
        
    let propToClass =
        function
        | Position Left -> "has-icon-left"
        | Position Right -> "has-icon-right"
    
    type C = { className: string }
    
    let iconInput (props: Prop list) (htmlProps: IHTMLProp list) (children: ReactElement list) =
        let element = children.[1]
        let classNames = getClasseNames element
        let icon = ReactAPIExtensions.cloneElement element {className = "form-icon " + classNames} []
        let newProps = List.map propToClass props |> addClassesToProps <| htmlProps
        R.div newProps [
            children.[0]
            icon
        ]
