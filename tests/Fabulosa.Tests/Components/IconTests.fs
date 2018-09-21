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
            Icon.ƒ Icon.defaults
            |> ReactNode.unit
            |> hasUniqueClass "icon"
        }

        test "Icon size x2" {
            Icon.ƒ
                { Icon.defaults with
                    Size = Icon.Size.X2 }
            |> ReactNode.unit
            |> hasClass "icon-2x"
        }

        test "Icon size x3" {
            Icon.ƒ
                { Icon.defaults with
                    Size = Icon.Size.X3 }
            |> ReactNode.unit
            |> hasClass "icon-3x"
        }

        test "Icon size x4" {
            Icon.ƒ
                { Icon.defaults with
                    Size = Icon.Size.X4 }
            |> ReactNode.unit
            |> hasClass "icon-4x"
        }

        test "Icon kind" {
            Icon.ƒ
                { Icon.defaults with
                    Kind = Icon.Kind.Apps }
            |> ReactNode.unit
            |> hasClass "icon-apps"
        }

        test "Icon html props" {
            Icon.ƒ
                { Icon.defaults with
                    HTMLProps = [ClassName "custom"] }
            |> ReactNode.unit
            |> hasClass "custom"
        }

    ]