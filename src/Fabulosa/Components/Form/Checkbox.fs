namespace Fabulosa

[<RequireQualifiedAccess>]
module Checkbox =

    module R = Fable.Helpers.React
    open R.Props
    open ClassNames

    [<RequireQualifiedAccess>]
    type Inline = bool

    [<RequireQualifiedAccess>]
    type Props = {
        Inline: Inline
        Text: string
        HTMLProps: IHTMLProp list
    }

    let inlineCheckbox =
        function
        | true -> "form-inline"
        | false -> ""

    let defaults = {
        Props.Inline = false
        Props.Text = "Label"
        Props.HTMLProps = []
    }

    let ƒ (props: Props) =
        let containerClasses = [
            "form-checkbox"
            inlineCheckbox props.Inline ] |> concatStrings
        R.label [ClassName containerClasses] [
            R.input <| props.HTMLProps @ [Type "checkbox"]
            R.i [ClassName "form-icon"] []
            R.str props.Text
        ]

    let render = ƒ