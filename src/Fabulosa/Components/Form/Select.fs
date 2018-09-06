namespace Fabulosa

[<RequireQualifiedAccess>]
module Select =

    open Fabulosa.Extensions
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
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.Size = Size.Unset
        Props.HTMLProps = []
    }

    let size =
        function
        | Size.Small -> "select-sm"
        | Size.Large -> "select-lg"
        | Size.Unset -> ""
        >> ClassName

    let ƒ (props: Props) =
        let p =
            props.HTMLProps
            |> addProps
                [ ClassName "form-select"
                  size props.Size ]
        p |> R.select

    let render = ƒ

    module Option =

        module R = Fable.Helpers.React

        [<RequireQualifiedAccess>]
        type Props = {
            HTMLProps: IHTMLProp list
        }

        let defaults = {
            Props.HTMLProps = []
        }

        let ƒ (props: Props) =
            props.HTMLProps
            |> R.option

        let render = ƒ

    module OptionGroup =

        module R = Fable.Helpers.React

        [<RequireQualifiedAccess>]
        type Props = {
            HTMLProps: IHTMLProp list
        }

        let defaults = {
            Props.HTMLProps = []
        }

        let ƒ (props: Props) =
            props.HTMLProps
            |> R.optgroup

        let render = ƒ