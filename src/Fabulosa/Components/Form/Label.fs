namespace Fabulosa

[<RequireQualifiedAccess>]
module Label =

    open ClassNames
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Size =
    | Small
    | Large
    | Unset

    [<RequireQualifiedAccess>]
    type Props = {
        Size: Size
        Text: string
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.Size = Size.Unset
        Props.Text = "Checkbox"
        Props.HTMLProps = []
    }

    let size =
        function
        | Size.Small -> "label-sm"
        | Size.Large -> "label-lg"
        | Size.Unset -> ""

    let ƒ (props: Props) =
        props.HTMLProps
        |> combineProps[
            "form-label"
            size props.Size ]
        |> R.label
        <| [R.str props.Text]

    let render = ƒ
    