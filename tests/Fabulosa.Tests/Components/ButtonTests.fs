module ButtonTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fabulosa.Tests.Extensions.TestNodeExtensions

[<Tests>]
let tests =
    testList "Button tests" [

        test "Button default" {
            let props = Button.defaults
            let child = R.str "text"
            let button = Button.ƒ props [child]
            button |> hasClasses ["btn"]
            button |> hasDescendent child
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