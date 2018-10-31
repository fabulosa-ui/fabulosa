namespace Fabulosa

module Button =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    module P = R.Props

    type Kind =
        | Default
        | Primary
        | Link

    type Color =
        | Success
        | Error

    type State =
        | Disabled
        | Active
        | Loading

    type Shape =
        | Squared
        | Round

    type ButtonOptional =
        | Kind of Kind
        | Color of Color
        | State of State
        | Shape of Shape
        interface P.IHTMLProp

    type Button =
        P.HTMLProps * ReactElement list

    type Nested =
        Button of Button

    let private propToClassName (prop: P.IHTMLProp) =
        match prop with
        | :? ButtonOptional as opt ->
            match opt with
            | Kind Default -> "btn-default"
            | Kind Primary -> "btn-primary"
            | Kind Link -> "btn-link"
            | Color Success -> "btn-success"
            | Color Error -> "btn-error"
            | State Disabled -> "disabled"
            | State Loading -> "loading"
            | State Active -> "active"
            | Shape Squared -> "btn-action"
            | Shape Round -> "btn-action circle"
            |> P.className
        | :? FabulosaFormSize as opt ->
            match opt with
            | Size Small -> "btn-sm"
            | Size Large -> "btn-lg"
            |> P.className
        | _ -> prop

    let private createButton renderer ((opt, chi): Button) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "btn")
        |> P.map propToClassName
        |> P.merge
        |> renderer <| chi

    let button = createButton R.button

    let anchor = createButton R.a

module ButtonGroup =

    open Fabulosa.Extensions
    open Button
    module R = Fable.Helpers.React
    open R.Props
    
    type ButtonGroupOptional =
        | Block
        interface IHTMLProp

    type ButtonGroupChild =
        Button of Button

    type ButtonGroupChildren = ButtonGroupChild list

    type ButtonGroup = HTMLProps * ButtonGroupChildren

    let private propToClassName (prop: IHTMLProp) =
        match prop with
        | :? ButtonGroupOptional as opt ->
            match opt with
            | Block -> "btn-group-block"
            |> ClassName
            :> IHTMLProp
        | _ -> prop

    let buttonGroup ((opt, chi): ButtonGroup) =
        Unmerged opt
        |> addProp (ClassName "btn-group")
        |> map propToClassName
        |> merge
        |> R.div
        <| Seq.map (fun (Button btn) -> button btn) chi
