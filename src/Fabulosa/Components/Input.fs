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

    let extract (reactElement: ReactElement) =
        match reactElement :?> R.HTMLNode with
        | R.Node (element, props, children) ->
            (element, Seq.toList <| Seq.cast<IHTMLProp> props, Seq.toList children)
        | _ -> ("", [], [])

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
        let (iconElement, iconProps, iconChildren) = extract children.[1]
        let newIconProps = iconProps @ [ClassName "form-icon"]
        let icon = React.domEl iconElement newIconProps iconChildren
        let newProps = List.map propToClass props |> addClassesToProps <| htmlProps
        R.div newProps [
            children.[0]
            icon
        ]
