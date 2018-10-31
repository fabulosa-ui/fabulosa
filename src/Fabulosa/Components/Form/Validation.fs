namespace Fabulosa

module Validation =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fabulosa.Checkbox
    open Fabulosa.Input
    open Fabulosa.Radio
    open Fabulosa.Select
    open Fabulosa.Switch

    type ValidationOptional =
        | Error of string
        | Success of string
        interface IHTMLProp

    type ValidationChild =
        | Checkbox of Checkbox
        | Input of Input
        | Radio of Radio
        | Select of Select
        | Switch of Switch

    type Validation =
        HTMLProps * ValidationChild

    let private propToMessage (props: HTMLProps) =
        List.tryPick
            (fun (prop: IHTMLProp) ->
                match prop with
                | :? ValidationOptional as opt ->
                    match opt with
                    | Success message -> [ R.str message ]
                    | Error message -> [ R.str message ]
                    |> R.p [ ClassName "form-input-hint" ]
                    |> Some
                | _ -> None)
            props
        |> R.ofOption

    let private propToClassName (prop: IHTMLProp) =
        match prop with
        | :? ValidationOptional as opt ->
            match opt with
            | Success _ -> "has-success"
            | Error _ -> "has-error"
            |> className
        | _ -> prop

    let validation ((opt, chi): Validation) =
        Unmerged opt
        |> map propToClassName
        |> merge
        |> R.span
        <| [ (match chi with
               | Checkbox c -> checkbox c
               | Input i -> input i
               | Radio r -> radio r
               | Select s -> select s
               | Switch s -> switch s)
             propToMessage opt]
