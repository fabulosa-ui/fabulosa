namespace Fabulosa

module Textarea =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    type Textarea = HTMLProps * FabulosaText

    let textarea ((opt, (Text txt)): Textarea) =
        Unmerged opt
        |> addProp (ClassName "form-input")
        |> merge
        |> R.textarea <| [ R.str txt ]
