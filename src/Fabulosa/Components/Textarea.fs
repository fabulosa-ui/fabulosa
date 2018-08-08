namespace Fabulosa

[<RequireQualifiedAccess>]
module Textarea =

    open ClassNames

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props = {
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.HTMLProps = []
    }

    let ƒ (props: Props) =
        props.HTMLProps
        |> combineProps ["form-input"]
        |> R.textarea

    let render = ƒ