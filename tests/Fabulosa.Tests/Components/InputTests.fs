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

    ]