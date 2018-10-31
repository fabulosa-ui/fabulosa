namespace Fabulosa

module Select =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    module P = R.Props

    type SelectOption = P.HTMLProps * FabulosaText

    let selectOption ((opt, (Text txt)): SelectOption) =
        R.option opt [ R.str txt ]

    type SelectOptionGroupChild =
        | Option of SelectOption

    type SelectOptionGroup =
        P.HTMLProps * SelectOptionGroupChild list

    let selectOptionGroup ((opt, chi): SelectOptionGroup) =
        R.optgroup opt (Seq.map (fun (Option opt) -> selectOption opt) chi)

    type SelectChild =
        | Group of SelectOptionGroup
        | Option of SelectOption

    type Select =
        P.HTMLProps * SelectChild list

    let private propToClassName (prop: P.IHTMLProp) =
        match prop with
        | :? FabulosaFormSize as opt ->
            match opt with
            | Size Small -> "select-sm"
            | Size Large -> "select-lg"
            |> P.className
        | _ -> prop

    let select ((opt, chi): Select) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "form-select")
        |> P.map propToClassName
        |> P.merge
        |> R.select
        <| Seq.map
            (function
             | Group g -> selectOptionGroup g
             | Option o -> selectOption o)
            chi
