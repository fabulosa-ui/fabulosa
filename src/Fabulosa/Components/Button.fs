namespace Fabulosa

[<RequireQualifiedAccess>]
module Button =

    open Fable.Import.React
    open Fabulosa.Extensions
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
    type Props =
        { Kind: Kind
          Color: Color
          Size: Size
          State: State
          Format: Format
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type Children = ReactElement list

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let kind =
        function
        | Kind.Default -> "btn-default"
        | Kind.Primary -> "btn-primary"
        | Kind.Link -> "btn-link"
        | Kind.Unset -> ""
        >> ClassName

    let color =
        function
        | Color.Success -> "btn-success"
        | Color.Error -> "btn-error"
        | Color.Unset -> ""
        >> ClassName

    let size =
        function
        | Size.Small -> "btn-sm"
        | Size.Large -> "btn-lg"
        | Size.Unset -> ""
        >> ClassName

    let state =
        function
        | State.Disabled -> "disabled"
        | State.Loading -> "loading"
        | State.Active -> "active"
        | State.Unset -> ""
        >> ClassName

    let format =
        function
        | Format.SquaredAction -> "btn-action"
        | Format.RoundAction -> "btn-action circle"
        | Format.Unset -> ""
        >> ClassName

    let defaults =
        { Props.Kind = Kind.Unset
          Props.Color = Color.Unset
          Props.Size = Size.Unset
          Props.State = State.Unset
          Props.Format = Format.Unset
          Props.HTMLProps = [] }

    let ƒ (button: T) =
        let props, children = button
        props.HTMLProps
        |> addProps
            [ ClassName "btn"
              kind props.Kind
              color props.Color
              size props.Size
              state props.State
              format props.Format ]
        |> R.button <| children

    let render = ƒ

[<RequireQualifiedAccess>]
module Anchor =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Children = ReactElement list

    [<RequireQualifiedAccess>]
    type T = Button.T

    let defaults = Button.defaults

    let ƒ (anchor: T) =
        let props, children = anchor
        props.HTMLProps
        |> addProps
            [ ClassName "btn"
              Button.kind props.Kind
              Button.size props.Size
              Button.color props.Color
              Button.state props.State
              Button.format props.Format ]
        |> R.a <| children

    let render = ƒ

module ButtonGroup =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Block = bool

    [<RequireQualifiedAccess>]
    type Props =
        { Block: Block
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type Children = ReactElement list

    [<RequireQualifiedAccess>]
    type T = Props * Button.T list

    let defaults =
        { Props.Block = false
          Props.HTMLProps = [] }

    let private block =
        function
        | true -> "btn-group-block"
        | false -> ""

    let ƒ (buttonGroup: T) =
        let props, children = buttonGroup
        props.HTMLProps
        |> addProp (ClassName "btn-group")
        |> R.div
        <| Seq.map Button.ƒ children