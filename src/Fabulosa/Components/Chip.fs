namespace Fabulosa

open Fable.Import.React
[<RequireQualifiedAccess>]
module Chip =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Children = ReactElement list

    [<RequireQualifiedAccess>]
    type OnRemove = MouseEvent -> unit

    [<RequireQualifiedAccess>]
    type Removable = bool

    [<RequireQualifiedAccess>]
    type Props = {
        Removable: Removable
        OnRemove: OnRemove
        HTMLProps: HTMLProps
    }

    let defaults = {
        Props.Removable = false
        Props.OnRemove = (fun _ -> ())
        Props.HTMLProps = []
    }

    let renderRemove removable onRemove =
        match removable, onRemove with
        | true, _ ->
            R.a
                [ ClassName "btn btn-clear"
                  Role "button"
                  OnClick onRemove ]
                []
            |> Some
        | false, _ -> None

    let ƒ (props: Props) (children: Children)=
        props.HTMLProps
        |> addProp (ClassName "chip")
        |> R.div
        <| seq {
            yield! children
            yield R.ofOption (renderRemove props.Removable props.OnRemove)
        }