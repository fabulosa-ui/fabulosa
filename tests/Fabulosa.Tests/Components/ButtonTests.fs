module ButtonTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open Fabulosa.Tests.Extensions.TestNodeExtensions

[<Tests>]
let tests =
    testList "Button tests" [

        test "Button default" {
            let props = Button.defaults
            let children = [R.str "text"]
            let button = Button.ƒ props children
            button |> containsClasses ["btn"]
            button |> containsChildren children
        }

        test "Button kind primary" {
            let props = { Button.defaults with Kind = Button.Kind.Primary }
            let children = [R.str "text"]
            let button = Button.ƒ props children
            button |> containsClasses ["btn"; "btn-primary"]
            button |> containsChildren children
        }

        test "Button kind link" {
            let props = { Button.defaults with Kind = Button.Kind.Link }
            let children = [R.str "text"]
            let button = Button.ƒ props children
            button |> containsClasses ["btn"; "btn-link"]
            button |> containsChildren children
        }

        test "Button color success" {
            let props = { Button.defaults with Color = Button.Color.Success }
            let children = [R.str "text"]
            let button = Button.ƒ props children
            button |> containsClasses ["btn"; "btn-success"]
            button |> containsChildren children
        }

        test "Button color error" {
            let props = { Button.defaults with Color = Button.Color.Error }
            let children = [R.str "text"]
            let button = Button.ƒ props children
            button |> containsClasses ["btn"; "btn-error"]
            button |> containsChildren children
        }

    ]