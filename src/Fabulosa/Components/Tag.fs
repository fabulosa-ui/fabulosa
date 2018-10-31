namespace Fabulosa

module Tag =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    type Color =
        | Primary
        | Secondary
        | Success
        | Warning
        | Error

    type TagOptional =
        | Rounded
        | Color of Color
        interface IHTMLProp

    type Tag = HTMLProps * FabulosaText

    let private propToClassName (prop: IHTMLProp) =
        match prop with
        | :? TagOptional as opt ->
            match opt with
            | Color Primary -> "label-primary"
            | Color Secondary -> "label-secondary"
            | Color Success -> "label-success"
            | Color Warning -> "label-warning"
            | Color Error -> "label-error"
            | Rounded -> "label-rounded"
            |> ClassName
            :> IHTMLProp
        | _ -> prop

    let tag ((opt, (Text txt)): Tag) =
        Unmerged opt
        |> addProp (ClassName "label")
        |> map propToClassName
        |> merge
        |> R.span <| [ R.str txt ]
