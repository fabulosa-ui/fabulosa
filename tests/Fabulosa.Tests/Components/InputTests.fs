module InputTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fabulosa.Tests.Extensions.TestNodeExtensions

[<Tests>]
let tests =
    testList "Input tests" [

        test "Input default" {
            let props = Input.defaults
            let input = Input.ƒ props
            input |> hasClasses ["form-input"]
        }

        test "Input size small" {
            let props = { Input.defaults with Size = Input.Size.Small }
            let input = Input.ƒ props
            input |> hasClasses ["form-input"; "input-sm"]
        }

        test "Input size large" {
            let props = { Input.defaults with Size = Input.Size.Large }
            let input = Input.ƒ props
            input |> hasClasses ["form-input"; "input-lg"]
        }

        test "Input html props" {
            let props = { Input.defaults with HTMLProps = [ClassName "custom"] }
            let input = Input.ƒ props
            input |> hasClasses ["form-input"; "custom"]
        }

        test "IconInput default" {
            let props = IconInput.defaults
            let inputIcon = IconInput.ƒ props
            let icon = Icon.ƒ { Icon.defaults with HTMLProps = [ClassName "form-icon"] } []
            let input = Input.ƒ Input.defaults
            inputIcon |> hasClasses ["has-icon-left"]
            inputIcon |> hasDescendent icon
            inputIcon |> hasDescendent input
        }

    ]