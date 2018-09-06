namespace Fabulosa

[<RequireQualifiedAccess>]
module Navbar =

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

    [<RequireQualifiedAccess>]
    module Header =

        let ƒ (props: Props) =
            props.HTMLProps
            |> addProp (ClassName "navbar")
            |> R.header

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Section =

        let ƒ (props: Props) =
            props.HTMLProps
            |> addProp (ClassName "navbar-section")
            |> R.section

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Center =

        let ƒ (props: Props) =
            props.HTMLProps
            |> addProp (ClassName "navbar-center")
            |> R.section

    let center = Center.ƒ

    [<RequireQualifiedAccess>]
    module Brand =

        let ƒ (props: Props) =
            props.HTMLProps
            |> addProp (ClassName "navbar-brand")
            |> R.a

        let render = ƒ
