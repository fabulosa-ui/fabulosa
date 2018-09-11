namespace Fabulosa

open Fable.Import.React
[<RequireQualifiedAccess>]
module Chip =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Child = 
    | Text of string
    | Avatar of Avatar.Props

    [<RequireQualifiedAccess>]
    type Children = Child seq

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
        Props.OnRemove = ignore
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
        |> R.ofOption

    let private avatar =
        function
        | Child.Avatar props ->
            Avatar.ƒ
                { props with
                    Size = Avatar.Size.Small }
            |> Some
        | _ -> None
        |> List.tryPick
        >> R.ofOption

    let private text =
        function
        | Child.Text text -> R.str text |> Some
        | _ -> None
        |> List.tryPick
        >> R.ofOption

    let renderChildren children =
        seq {
            yield avatar children
            yield text children
        }

    let ƒ (props: Props) children =
        props.HTMLProps
        |> addProp (ClassName "chip")
        |> R.div
        <| seq {
            yield! renderChildren children
            yield renderRemove props.Removable props.OnRemove
        }