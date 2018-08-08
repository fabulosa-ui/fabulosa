namespace Fabulosa

[<RequireQualifiedAccess>]
module Switch =

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props = {
        Text: string
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.Text = "Label"
        Props.HTMLProps = []
    }

    let ƒ (props: Props) =
        R.label [ClassName "form-switch"] [
            R.input <| props.HTMLProps @ [Type "checkbox"]
            R.i [ClassName "form-icon"] []
            R.str props.Text
        ]

    let render = ƒ