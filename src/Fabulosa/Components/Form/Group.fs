namespace Fabulosa

module Group =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fabulosa.Checkbox
    open Fabulosa.Radio
    open Fabulosa.Label
    open Fabulosa.Switch
    open Fabulosa.Input
    open Fabulosa.Select
    open Fabulosa.InputGroup
    open Fabulosa.Validation
    open Fabulosa.Textarea

    type GroupChild =
        | Checkbox of Checkbox
        | Input of Input
        | InputGroup of InputGroup
        | Label of Label
        | Radio of Radio
        | Select of Select
        | Switch of Switch
        | Textarea of Textarea
        | Validation of Validation

    type Group =
        HTMLProps * GroupChild list

    let group ((opt, chi): Group) =
        Unmerged opt
        |> addProp (ClassName "form-group")
        |> merge
        |> R.div
        <| Seq.map
            (function
             | Checkbox c -> checkbox c
             | Input i -> input i
             | InputGroup i -> inputGroup i
             | Label l -> label l
             | Radio r -> radio r
             | Select s -> select s
             | Switch s -> switch s
             | Textarea t -> textarea t
             | Validation v -> validation v)
             chi
