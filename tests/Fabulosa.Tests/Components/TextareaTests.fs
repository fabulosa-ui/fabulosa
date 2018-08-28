module TextareaTests

open Expecto
open Expect
open Fabulosa
module R = Fable.Helpers.React
open R.Props

[<Tests>]
let tests =
    testList "Textarea tests" [

        test "Textarea default" {
            let props = Textarea.defaults
            let textarea = Textarea.ƒ props []
            
            textarea
            |> ReactNode.unit
            |> hasUniqueClass "form-input"
        }

        test "Textarea html props" {
            let props = { Textarea.defaults with HTMLProps = [ClassName "custom"] }
            let textarea = Textarea.ƒ props []
            
            textarea
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Textarea children with name" {
            let props = Textarea.defaults
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            let textarea = Textarea.ƒ props [child]
            
            textarea
            |> ReactNode.unit
            >>= hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

        test "Textarea children with class" {
            let props = Textarea.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let textarea = Textarea.ƒ props [child]
            
            textarea
            |> ReactNode.unit
            >>= hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

    ]