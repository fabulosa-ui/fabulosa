namespace Fabulosa

[<RequireQualifiedAccess>]
module Radio =

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Inline = bool

    [<RequireQualifiedAccess>]
    type Props = {
        Inline: Inline
        Text: string
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.Inline = false
        Props.Text = "Label"
        Props.HTMLProps = []
    }

    let inlineRadio =
        function
        | true -> "form-inline"
        | false -> ""

    let ƒ (props: Props) =
        let containerClass = [
            "form-radio"
            inlineRadio props.Inline] |> String.concat " "
        R.label [ClassName containerClass] [
            R.input <| [Type "radio"] @ props.HTMLProps
            R.i [ClassName "form-icon"] []
            R.str props.Text
        ]

    let render = ƒ