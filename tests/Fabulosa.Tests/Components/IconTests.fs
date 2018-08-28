module IconTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Icon tests" [

        test "Icon default" {
            let props = Icon.defaults
            let icon = Icon.ƒ props []

            icon
            |> ReactNode.unit
            |> hasUniqueClass "icon"
        }

        test "Icon size x2" {
            let props = { Icon.defaults with Size = Icon.Size.X2 }
            let icon = Icon.ƒ props []

            icon
            |> ReactNode.unit
            |> hasClass "icon-2x"
        }

        test "Icon size x3" {
            let props = { Icon.defaults with Size = Icon.Size.X3 }
            let icon = Icon.ƒ props []

            icon
            |> ReactNode.unit
            |> hasClass "icon-3x"
        }

        test "Icon size x4" {
            let props = { Icon.defaults with Size = Icon.Size.X4 }
            let icon = Icon.ƒ props []

            icon
            |> ReactNode.unit
            |> hasClass "icon-4x"
        }

        test "Icon kind" {
            let props = { Icon.defaults with Kind = Icon.Kind.Apps }
            let icon = Icon.ƒ props []

            icon
            |> ReactNode.unit
            |> hasClass "icon-apps"
        }

        test "Icon html props" {
            let props = { Icon.defaults with HTMLProps = [ClassName "custom"] }
            let icon = Icon.ƒ props []

            icon
            |> ReactNode.unit
            |> hasClass "custom"
        }

    ]