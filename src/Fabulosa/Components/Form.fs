namespace Fabulosa

[<RequireQualifiedAccess>]
module Form =

    open ClassNames

    module R = Fable.Helpers.React

    let group =
        ["form-group"]
        |> combineProps
        >> R.div