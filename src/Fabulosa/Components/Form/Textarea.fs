namespace Fabulosa

[<RequireQualifiedAccess>]
module Textarea =

    open Fabulosa.Extensions
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
        |> addProp (ClassName "form-input")
        |> R.textarea

    let render = ƒ