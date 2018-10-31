namespace Fabulosa

module Step =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    type StepItem =
        HTMLProps * ReactElement list

    let private hasActive (prop: IHTMLProp) =
        match prop with
        | :? FabulosaActive as opt ->
            match opt with
            | Active -> true
        | _ -> false

    let private itemPropToClassName (prop: IHTMLProp) =
        match prop with
        | :? FabulosaActive as opt ->
            match opt with
            | Active -> className "active"
        | _ -> prop

    let stepItem ((opt, chi): StepItem) =
        let withActive, withoutActive =
            List.partition hasActive opt
        Unmerged withActive
        |> addProp (ClassName "step-item")
        |> map itemPropToClassName
        |> merge
        |> R.li
        <| [ R.a withoutActive chi ]

    type StepChild =
        Item of StepItem

    type Step =
        HTMLProps * StepChild list

    let step ((opt, chi): Step) =
        Unmerged opt
        |> addProp (ClassName "step")
        |> merge
        |> R.div
        <| Seq.map (fun (Item item) -> stepItem item) chi
