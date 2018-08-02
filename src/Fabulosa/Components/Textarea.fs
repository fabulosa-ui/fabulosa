namespace Fabulosa

[<RequireQualifiedAccess>]
module Textarea =

    open ClassNames

    module R = Fable.Helpers.React

    let textarea =
        ["form-input"]
        |> combineProps
        >> R.textarea