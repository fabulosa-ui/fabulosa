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

    open Fable.Helpers
    open Fable.Import.React
    open ClassNames
    module R = Fable.Helpers.React
    open Fable.Helpers.React.Props

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
        let second = children.[1]
        let icon: ReactElement = ReactAPIExtensions.cloneElement second { className = "what" } []
        Fable.Import.Browser.console.log(ReactAPIExtensions.cloneElement)
        let newProps = List.map propToClass props |> addClassesToProps <| htmlProps
        R.div newProps [
            children.[0]
            icon
        ]
