namespace Fabulosa

[<RequireQualifiedAccess>]
module Switch =

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type Children = string

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.HTMLProps = [] }

    let build (switch: T) =
        let props, children = switch
        R.label [ ClassName "form-switch" ]
            [ R.input <| props.HTMLProps @ [ Type "checkbox" ]
              R.i [ ClassName "form-icon" ] []
              R.str children ]

    let ƒ = build