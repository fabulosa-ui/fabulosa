module IconTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fabulosa.Tests.Extensions.TestNodeExtensions

[<Tests>]
let tests =
    testList "Icon tests" [

        test "Icon default" {
            let props = Icon.defaults
            let icon = Icon.ƒ props []
            icon |> hasClasses ["icon"]
        }

        test "Icon size x2" {
            let props = { Icon.defaults with Size = Icon.Size.X2 }
            let icon = Icon.ƒ props []
            icon |> hasClasses ["icon"; "icon-2x"]
        }

        test "Icon size x3" {
            let props = { Icon.defaults with Size = Icon.Size.X3 }
            let icon = Icon.ƒ props []
            icon |> hasClasses ["icon"; "icon-3x"]
        }

        test "Icon size x4" {
            let props = { Icon.defaults with Size = Icon.Size.X4 }
            let icon = Icon.ƒ props []
            icon |> hasClasses ["icon"; "icon-4x"]
        }

        test "Icon kind" {
            let props = { Icon.defaults with Kind = Icon.Kind.Apps }
            let icon = Icon.ƒ props []
            icon |> hasClasses ["icon-apps"]
        }

        test "Icon html props" {
            let props = { Icon.defaults with HTMLProps = [ClassName "custom"] }
            let icon = Icon.ƒ props []
            icon |> hasClasses ["icon"; "custom"]
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