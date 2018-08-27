module ButtonTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open Fabulosa.Accordion
open R.Props
open Fabulosa.Tests.Extensions
open Fabulosa.Tests.Extensions.ReactNode
open Fabulosa.Tests.Extensions.TestNodeExtensions

[<Tests>]
let tests =
    testList "Button tests" [

        test "Button default" {
            let childElement = R.div [ClassName "custom"] [R.str "text"]
            let buttonElement = Button.ƒ Button.defaults [childElement]
            
            buttonElement
            |> Expect.hasUniqueClassBind "btn"
            |> Expect.containsChild 1 childElement
        }

        test "Button kind primary" {
            let childElement = R.str "text"
            let buttonElement = Button.ƒ { Button.defaults with Kind = Button.Kind.Primary } [childElement]
            
            buttonElement 
            |> Expect.containsClassNameBind "btn btn-primary"
            |> Expect.containsChild 1 childElement
        }

        test "Button kind link" {
            let child = R.str "text"
            let buttonElement = Button.ƒ { Button.defaults with Kind = Button.Kind.Link } [child]

            buttonElement
            |> Expect.containsClassNameBind "btn btn-link"
            |> Expect.containsChild 1 child
        }

        test "Button color success" {
            let child = R.str "text"
            let buttonElement = Button.ƒ { Button.defaults with Color = Button.Color.Success } [child]

            buttonElement
            |> Expect.containsClassNameBind "btn btn-success"
            |> Expect.containsChild 1 child
        }

        test "Button color error" {
            let child = R.str "text"
            let buttonElement = Button.ƒ { Button.defaults with Color = Button.Color.Error } [child]

            buttonElement
            |> Expect.containsClassNameBind "btn btn-error"
            |> Expect.containsChild 1 child
        }

        test "Button size small" {
            let child = R.str "text"
            let buttonElement = Button.ƒ { Button.defaults with Size = Button.Size.Small } [child]

            buttonElement
            |> Expect.containsClassNameBind "btn btn-sm"
            |> Expect.containsChild 1 child
        }

        test "Button size large" {
            let child = R.str "text"
            let buttonElement = Button.ƒ { Button.defaults with Size = Button.Size.Large } [child]

            buttonElement
            |> Expect.containsClassNameBind "btn btn-lg"
            |> Expect.containsChild 1 child
        }

        test "Button state disabled" {
            let child = R.str "text"
            let buttonElement = Button.ƒ { Button.defaults with State = Button.State.Disabled  } [child]

            buttonElement
            |> Expect.containsClassNameBind "btn disabled"
            |> Expect.containsChild 1 child
        }

        test "Button state active" {
            let child = R.str "text"
            let buttonElement = Button.ƒ { Button.defaults with State = Button.State.Active } [child]

            buttonElement
            |> Expect.containsClassNameBind "btn active"
            |> Expect.containsChild 1 child
        }

        test "Button state loading" {
            let child = R.str "text"
            let buttonElement = Button.ƒ { Button.defaults with State = Button.State.Loading } [child]

            buttonElement
            |> Expect.containsClassNameBind "btn loading"
            |> Expect.containsChild 1 child
        }

        test "Button format squared action" {
            let child = R.str "text"
            let buttonElement = Button.ƒ { Button.defaults with Format = Button.Format.SquaredAction } [child]

            buttonElement
            |> Expect.containsClassNameBind "btn btn-action"
            |> Expect.containsChild 1 child
        }

        test "Button format round action" {
            let child = R.str "text"
            let buttonElement = Button.ƒ { Button.defaults with Format = Button.Format.RoundAction } [child]

            buttonElement
            |> Expect.containsClassNameBind "btn btn-action circle"
            |> Expect.containsChild 1 child
        }

        test "Button children with name" {
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            let buttonElement = Button.ƒ Button.defaults [child]

            buttonElement
            |> Expect.containsClassNameBind "btn"
            |> Expect.containsChildBind 1 child
            |> Expect.containsChild 1 grandChild
        }

        test "Button children with class" {
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let buttonElement = Button.ƒ { Button.defaults with Size = Button.Size.Small } [child]

            buttonElement
            |> Expect.containsClassNameBind "btn btn-sm"
            |> Expect.containsChildBind 1 child
            |> Expect.containsChild 1 grandChild
        }

    ]