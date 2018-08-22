module SwitchTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fabulosa.Tests.Extensions.TestNodeExtensions

[<Tests>]
let tests =
    testList "Switch tests" [

        test "Switch default" {
            let props = Switch.defaults
            let switch = Switch.ƒ props
            switch |> hasClasses ["form-switch"]
            switch |> hasDescendent (R.input [Type "checkbox"])
            switch |> hasDescendent (R.i [ClassName "form-icon"] [])
            switch |> hasDescendent (R.RawText "Label")
        }

        test "Switch text" {
            let props = { Switch.defaults with Text = "custom" }
            let switch = Switch.ƒ props
            switch |> hasClasses ["form-switch"]
            switch |> hasDescendent (R.RawText "custom")
        }

        test "Switch html props" {
            let props = { Switch.defaults with HTMLProps = [ClassName "custom"] }
            let switch = Switch.ƒ props
            switch |> hasClasses ["form-switch"]
            switch |> hasDescendent (R.input [ClassName "custom"])
        }

    ]