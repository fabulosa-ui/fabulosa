namespace Fabulosa

[<RequireQualifiedAccess>]
module Checkbox =

    module R = Fable.Helpers.React
    open R.Props

    type Prop =
    | Inline

    let propToClass =
        function
        | Inline -> "form-inline"

    let create props htmlProps label =
        let containerProps =
            ["form-checkbox"]
            @ List.map propToClass props
            |> String.concat " "
        let inputProps: IHTMLProp list = [Type "checkbox"] @ htmlProps
        R.label [ClassName containerProps] [
            R.input inputProps
            R.i [ClassName "form-icon"] []
            R.str label
        ]

    let checkbox label =
        create [] [] label