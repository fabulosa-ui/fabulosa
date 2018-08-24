namespace Fabulosa

[<RequireQualifiedAccess>]
module Table =

    open ClassNames
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Kind =
    | Striped
    | Hover
    | Unset

    [<RequireQualifiedAccess>]
    type Props = {
        Kind: Kind
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.Kind = Kind.Unset
        Props.HTMLProps = []
    }

    let kind =
        function
        | Kind.Striped -> "table-striped"
        | Kind.Hover -> "table-hover"
        | Kind.Unset -> ""

    let ƒ (props: Props) =
        props.HTMLProps
        |> combineProps [
            "table"
            kind props.Kind ]
        |> R.table

    let render = ƒ

    [<RequireQualifiedAccess>]
    module Head =

        [<RequireQualifiedAccess>]
        type Props = {
            HTMLProps: IHTMLProp list
        }

        let defaults = {
            Props.HTMLProps = []
        }

        let ƒ (props: Props) =
            props.HTMLProps
            |> R.thead

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Body =

        [<RequireQualifiedAccess>]
        type Props = {
            HTMLProps: IHTMLProp list
        }

        let defaults = {
            Props.HTMLProps = []
        }

        let ƒ (props: Props) =
            props.HTMLProps
            |> R.tbody

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Row =

        [<RequireQualifiedAccess>]
        type Active = bool

        [<RequireQualifiedAccess>]
        type Props = {
            Active: Active
            HTMLProps: IHTMLProp list
        }

        let defaults = {
            Props.Active = false
            Props.HTMLProps = []
        }

        let active =
            function
            | true -> "active"
            | false -> ""

        let ƒ (props: Props) =
            props.HTMLProps
            |> combineProps [active props.Active]
            |> R.tr

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Column =

        [<RequireQualifiedAccess>]
        type Props = {
            HTMLProps: IHTMLProp list
        }

        let defaults = {
            Props.HTMLProps = []
        }

        let ƒ (props: Props) =
            props.HTMLProps
            |> R.td

        let render = ƒ

    [<RequireQualifiedAccess>]
    module TitleColumn =

        [<RequireQualifiedAccess>]
        type Props = {
            HTMLProps: IHTMLProp list
        }

        let defaults = {
            Props.HTMLProps = []
        }

        let ƒ (props: Props) =
            props.HTMLProps
            |> R.th

        let render = ƒ