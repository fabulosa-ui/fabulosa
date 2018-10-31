namespace Fabulosa

module Toast =

    open Fabulosa.Extensions
    open Fabulosa.Button
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    type Color =
        | Primary
        | Success
        | Warning
        | Error

    type ToastOptional =
        | Color of Color
        | OnRequestClose of (MouseEvent -> unit)
        interface IHTMLProp

    type Toast = HTMLProps * FabulosaText

    let private color (prop: IHTMLProp) =
        match prop with
        | :? ToastOptional as opt ->
            match opt with
            | Color Primary -> className "toast-primary"
            | Color Success -> className "toast-success"
            | Color Warning -> className "toast-warning"
            | Color Error -> className "toast-error"
            | _ -> prop
        | _ -> prop

    let private onRequestClose (props: HTMLProps) =
        props
        |> List.tryPick
            (function
            | :? ToastOptional as opt ->
                match opt with
                | OnRequestClose fn ->
                    Some (button
                        ([ ClassName "btn-clear float-right"
                           OnClick fn], []))
                | _ -> None
            | _ -> None)
        |> R.ofOption

    let toast (comp: Toast) =
        let opt, (Text txt) = comp
        Unmerged opt
        |> addProp (ClassName "toast")
        |> map color
        |> merge
        |> R.div
        <| [ onRequestClose opt
             R.str txt ]
        |> Portal.ƒ "toast-container"
        