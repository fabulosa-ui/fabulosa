namespace Fabulosa

[<RequireQualifiedAccess>]
module Validation =

    module R = Fable.Helpers.React
    open Fable.Import.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Kind =
    | Error of string
    | Success of string

    let message =
        function
        | Kind.Success message -> message 
        | Kind.Error message -> message

    let className =
        function
        | Kind.Success _ -> "has-success"
        | Kind.Error _ -> "has-error"

    let test = R.div [] [R.str "WHATEVA"]

    let ƒ (elem: ReactElement) (kind: Kind) =
        R.span [ClassName <| className kind] [
            elem
            R.p [ClassName "form-input-hint"] [R.str <| message kind]
        ]