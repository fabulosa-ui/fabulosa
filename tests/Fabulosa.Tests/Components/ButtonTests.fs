module ButtonTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fabulosa.Tests.Extensions.TestNodeExtensions
open Fabulosa.Tests.Extensions.ReactNode

[<Tests>]
let tests =
    testList "Button tests" [

        test "Button default" {
            let props = Button.defaults
            let child = R.div [ClassName "custom"] [R.str "text"]
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"]
            button |> found child
        }

        test "Button kind primary" {
            let props = { Button.defaults with Kind = Button.Kind.Primary }
            let child = R.str "text"
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"; "btn-primary"]
            button |> hasDescendent child
        }

        test "Button kind link" {
            let props = { Button.defaults with Kind = Button.Kind.Link }
            let child = R.str "text"
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"; "btn-link"]
            button |> hasDescendent child
        }

        test "Button color success" {
            let props = { Button.defaults with Color = Button.Color.Success }
            let child = R.str "text"
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"; "btn-success"]
            button |> hasDescendent child
        }

        test "Button color error" {
            let props = { Button.defaults with Color = Button.Color.Error }
            let child = R.str "text"
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"; "btn-error"]
            button |> hasDescendent child
        }

        test "Button size small" {
            let props = { Button.defaults with Size = Button.Size.Small }
            let child = R.str "text"
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"; "btn-sm"]
            button |> hasDescendent child
        }

        test "Button size large" {
            let props = { Button.defaults with Size = Button.Size.Large }
            let child = R.str "text"
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"; "btn-lg"]
            button |> hasDescendent child
        }

        test "Button state disabled" {
            let props = { Button.defaults with State = Button.State.Disabled }
            let child = R.str "text"
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"; "disabled"]
            button |> hasDescendent child
        }

        test "Button state active" {
            let props = { Button.defaults with State = Button.State.Active }
            let child = R.str "text"
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"; "active"]
            button |> hasDescendent child
        }

        test "Button state loading" {
            let props = { Button.defaults with State = Button.State.Loading }
            let child = R.str "text"
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"; "loading"]
            button |> hasDescendent child
        }

        test "Button format squared action" {
            let props = { Button.defaults with Format = Button.Format.SquaredAction }
            let child = R.str "text"
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"; "btn-action"]
            button |> hasDescendent child
        }

        test "Button format round action" {
            let props = { Button.defaults with Format = Button.Format.RoundAction }
            let child = R.str "text"
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"; "btn-action"; "circle"]
            button |> hasDescendent child
        }

        test "Button children with name" {
            let props = Button.defaults
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            let button = Button.ƒ props [child]
            button |> hasDescendent child
            button |> hasDescendent grandChild
        }

        test "Button children with class" {
            let props = Button.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let button = Button.ƒ props [child]
            button |> hasDescendent child
            button |> hasDescendent grandChild
        }

    ]