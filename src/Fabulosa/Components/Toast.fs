namespace Fabulosa

[<RequireQualifiedAccess>]
module Toast =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    type Color =
    | Primary
    | Success
    | Warning
    | Error
    | None

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          Color: Color
          OnRequestClose: (MouseEvent -> unit) option }

    [<RequireQualifiedAccess>]
    type Children = string

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.HTMLProps = []
          Props.Color = Color.None
          Props.OnRequestClose = None }

    let color =
        function
        | Color.Primary -> "toast-primary"
        | Color.Success -> "toast-success"
        | Color.Warning -> "toast-warning"
        | Color.Error -> "toast-error"
        | Color.None -> ""
        >> ClassName

    let onRequestClose =
        function
        | Some fn ->
            Button.ƒ
                ({ Button.props with
                     HTMLProps =
                       [ ClassName "btn-clear float-right"
                         OnClick fn] },
                 [])
        | None -> R.ofOption None


    let build (toast: T) =
        let props, children = toast
        props.HTMLProps
        |> addProps
            [ ClassName "toast"
              color props.Color ]
        |> R.div
        <| [ onRequestClose props.OnRequestClose
             R.str children ]
        |> Portal.ƒ "toast-container"

    let ƒ = build