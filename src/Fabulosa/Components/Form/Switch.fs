namespace Fabulosa

[<RequireQualifiedAccess>]
module Switch =

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props =
        { Text: string
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type T = Props

    let defaults =
        { Props.Text = "Label"
          Props.HTMLProps = [] }

    let ƒ (switch: T) =
        R.label [ ClassName "form-switch" ]
            [ R.input <| switch.HTMLProps @ [ Type "checkbox" ]
              R.i [ ClassName "form-icon" ] []
              R.str switch.Text ]

    let render = ƒ