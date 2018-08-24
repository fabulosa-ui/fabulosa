namespace Fabulosa

[<RequireQualifiedAccess>]
module Button =

    open ClassNames
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Kind =
    | Default
    | Primary
    | Link
    | Unset

    [<RequireQualifiedAccess>]
    type Color =
    | Success
    | Error
    | Unset

    [<RequireQualifiedAccess>]
    type Size =
    | Small
    | Large
    | Unset

    [<RequireQualifiedAccess>]
    type State =
    | Disabled
    | Active
    | Loading
    | Unset

    [<RequireQualifiedAccess>]
    type Format =
    | SquaredAction
    | RoundAction
    | Unset

    [<RequireQualifiedAccess>]
    type Props = {
        Kind: Kind
        Color: Color
        Size: Size
        State: State
        Format: Format
        HTMLProps: IHTMLProp list
    }

    let kind =
        function
        | Kind.Default -> "btn-default"
        | Kind.Primary -> "btn-primary"
        | Kind.Link -> "btn-link"
        | Kind.Unset -> ""

    let color =
        function
        | Color.Success -> "btn-success"
        | Color.Error -> "btn-error"
        | Color.Unset -> ""

    let size =
        function
        | Size.Small -> "btn-sm"
        | Size.Large -> "btn-lg"
        | Size.Unset -> ""

    let state =
        function
        | State.Disabled -> "disabled"
        | State.Loading -> "loading"
        | State.Active -> "active"
        | State.Unset -> ""

    let format =
        function
        | Format.SquaredAction -> "btn-action"
        | Format.RoundAction -> "btn-action circle"
        | Format.Unset -> ""

    let defaults = {
        Props.Kind = Kind.Unset
        Props.Color = Color.Unset
        Props.Size = Size.Unset
        Props.State = State.Unset
        Props.Format = Format.Unset
        Props.HTMLProps = []
    }

    let ƒ (props: Props) =
        props.HTMLProps
        |> combineProps [
            "btn"
            kind props.Kind
            color props.Color
            size props.Size
            state props.State
            format props.Format ]
        |> R.button

    let render = ƒ

[<RequireQualifiedAccess>]
module Anchor =

    open ClassNames
    module R = Fable.Helpers.React
    open R.Props

    type Props = {
        props: Button.Props list
        HTMLProps: IHTMLProp list
    }

    let defaults = Button.defaults

    let ƒ (props: Button.Props) =
        props.HTMLProps
        |> combineProps [
            "btn"
            Button.kind props.Kind
            Button.color props.Color
            Button.size props.Size
            Button.state props.State
            Button.format props.Format ]
        |> R.a

    let render = ƒ

module ButtonGroup =

    module R = Fable.Helpers.React
    open R.Props
    open ClassNames

    type Block = bool

    type Props = {
        Block: Block
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Block = false
        HTMLProps = []
    }

    let block =
        function
        | true -> "btn-group-block"
        | false -> ""
        

    let ƒ (props: Props) =
        props.HTMLProps
        |> combineProps ["btn-group"]
        |> R.div