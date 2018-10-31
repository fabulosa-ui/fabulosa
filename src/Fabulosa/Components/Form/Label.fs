namespace Fabulosa

module Label =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    module P = R.Props

    type Label = P.HTMLProps * FabulosaText

    let private propToClassName (prop: P.IHTMLProp) =
        match prop with
        | :? FabulosaFormSize as opt ->
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
