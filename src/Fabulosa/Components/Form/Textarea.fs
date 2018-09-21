namespace Fabulosa

[<RequireQualifiedAccess>]
module Textarea =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type T = Props * ReactElement list

    let defaults =
        { Props.HTMLProps = [] }

    let ƒ (textarea: T) =
        let props, children = textarea
        props.HTMLProps
        |> addProp (ClassName "form-input")
        |> R.textarea <| children

    let render = ƒ