namespace Fabulosa

[<RequireQualifiedAccess>]
module Button =

    open ClassNames
    module R = Fable.Helpers.React
    open R.Props

    type Kind =
    | Default
    | Primary
    | Link
    | KindUnset

    type Color =
    | Success
    | Error
    | ColorUnset

    type Size =
    | Small
    | Large
    | SizeUnset

    type State =
    | Disabled
    | Active
    | Loading
    | StateUnset

    type Format =
    | SquaredAction
    | RoundAction
    | FormatUnset

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
        | Default -> "btn-default"
        | Primary -> "btn-primary"
        | Link -> "btn-link"
        | _ -> ""

    let color =
        function
        | Success -> "btn-success"
        | Error -> "btn-error"
        | _ -> ""

    let size =
        function
        | Small -> "btn-sm"
        | Large -> "btn-lg"
        | _ -> ""

    let state =
        function
        | Disabled -> "disabled"
        | Loading -> "loading"
        | Active -> "active"
        | _ -> ""

    let format =
        function
        | SquaredAction -> "btn-action"
        | RoundAction -> "btn-action circle"
        | _ -> ""

    let Defaults = {
        Kind = KindUnset
        Color = ColorUnset
        Size = SizeUnset
        State = StateUnset
        Format = FormatUnset
        HTMLProps = []
    }

    let button props =
        let buttonProps = [ "btn";
            kind props.Kind;
            color props.Color;
            size props.Size;
            state props.State;
            format props.Format ]
        combineProps buttonProps props.HTMLProps
        |> R.button

module Anchor =

    open ClassNames
    module R = Fable.Helpers.React
    open R.Props

    type Props = {
        props: Button.Props list
        htmlProps: IHTMLProp list
    }

    let Defaults = Button.Defaults

    let anchor (props: Button.Props) =
        let buttonProps = [ Button.kind props.Kind;
            Button.color props.Color;
            Button.size props.Size;
            Button.state props.State;
            Button.format props.Format ]
        combineProps buttonProps props.HTMLProps
        |> R.a