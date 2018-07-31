namespace Fabulosa

module Radio =

    module R = Fable.Helpers.React
    open R.Props

    type Props =
    | Inline

    let propToClass =
        function
        | Inline -> "form-inline"

    let input props htmlProps label =
        let containerClass =
            ["form-checkbox"]
            @ List.map propToClass props
            |> String.concat " "
        let inputProps: IHTMLProp list = [Type "checkbox"] @ htmlProps
        R.label [ClassName containerClass] [
            R.input inputProps
            R.i [ClassName "form-icon"] []
            R.str label
        ]