namespace Fabulosa

module Select =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    type SelectOptionChild =
        | Text of string

    type SelectOption = HTMLProps * SelectOptionChild

    let selectOption ((opt, (Text txt)): SelectOption) =
        R.option opt [ R.str txt ]

    type SelectOptionGroupChild =
        | Option of SelectOption

    type SelectOptionGroup =
        HTMLProps * SelectOptionGroupChild list

    let selectOptionGroup ((opt, chi): SelectOptionGroup) =
        R.optgroup opt (Seq.map (fun (Option opt) -> selectOption opt) chi)

    type Size =
        | Small
        | Large

    type SelectOptional =
        | Size of Size
        interface IHTMLProp

    type SelectChild =
    | Group of SelectOptionGroup
    | Option of SelectOption

    type Select =
        HTMLProps * SelectChild list

    let private propToClassName (prop: IHTMLProp) =
        match prop with
        | :? SelectOptional as opt ->
            match opt with
            | Size Small -> "select-sm"
            | Size Large -> "select-lg"
            |> className
        | _ -> prop

    let select ((opt, chi): Select) =
        Unmerged opt
        |> addProp (ClassName "form-select")
        |> map propToClassName
        |> merge
        |> R.select
        <| Seq.map
            (function
             | Group g -> selectOptionGroup g
             | Option o -> selectOption o)
            chi
