namespace Fabulosa

module Label =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    module P = R.Props

    type Size =
        | Small
        | Large

    type LabelOptional =
        | Size of Size
        interface P.IHTMLProp

    type LabelChildren =
        Text of string

    type Label = P.HTMLProps * LabelChildren

    let private propToClassName (prop: P.IHTMLProp) =
        match prop with
        | :? LabelOptional as opt ->
            match opt with
            | Size Small -> "label-sm"
            | Size Large -> "label-lg"
            |> P.className
        | _ -> prop

    let label ((opt, (Text txt)): Label) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "form-label")
        |> P.map propToClassName
        |> P.merge
        |> R.label
        <| [ R.str txt ]
