namespace Fabulosa
open Fable.Import.Browser
open Fable.Helpers
open Fable.Import.React
open Fable.Core
open Fable.Core.JsInterop

[<RequireQualifiedAccess>]
module Button =

    open ClassNames
    module R = Fable.Helpers.React
    open R.Props
    open ReactAPIExtensions

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

    let button props =
        ["btn"] @ List.map propToClass props
        |> addClassesToProps
        >> R.button

    let textButton text =
        button [] [] [R.str text]

    let anchor props =
        ["btn"] @ List.map propToClass props
        |> addClassesToProps
        >> R.a

    let map f c = f c

    let sizeTransformer (element: ReactElement) (size: Size) =
        let (t, props, children) = extract element
        let c =
            match props.className  with
            | Some c -> Some <| c + propToClass (Size size)
            | None -> Some <| propToClass (Size size)
        let result = React.ofFunction (fun _ -> React.domEl t [] []) ({props with className = c}:> obj) children
        result

    let test =
        let smallButton =  textButton "text" |> map sizeTransformer <| Small
        console.log(smallButton)