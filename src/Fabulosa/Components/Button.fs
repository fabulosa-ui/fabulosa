namespace Fabulosa

[<RequireQualifiedAccess>]
module Button =

    open ClassNames
    module R = Fable.Helpers.React

    type Kind =
    | Default
    | Primary
    | Link

    type Color =
    | Success
    | Error

    type Size =
    | Small
    | Large

    type State =
    | Disabled
    | Active
    | Loading

    type Format =
    | SquaredAction
    | RoundAction

    type Prop =
    | Kind of Kind
    | Color of Color
    | Size of Size
    | State of State
    | Format of Format

    let propToClass =
        function
        | Kind Default -> "btn-default"
        | Kind Primary -> "btn-primary"
        | Kind Link -> "btn-link"
        | Color Success -> "btn-success"
        | Color Error -> "btn-error"
        | Size Small -> "btn-sm"
        | Size Large -> "btn-lg"
        | State Disabled -> "disabled"
        | State Loading -> "loading"
        | Format SquaredAction -> "btn-action"
        | Format RoundAction -> "btn-action circle"
        | _ -> ""

    let create props =
        ["btn"] @ List.map propToClass props
        |> addClassesToProps
        >> R.button

    let button text =
        create [] [] [R.str text]

module Anchor =

    open ClassNames
    module R = Fable.Helpers.React

    let create props =
        ["btn"] @ List.map Button.propToClass props
        |> addClassesToProps
        >> R.a

    let a text =
        create [] [] [R.str text]