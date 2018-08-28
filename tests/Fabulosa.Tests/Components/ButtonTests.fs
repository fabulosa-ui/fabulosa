module ButtonTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Button tests" [

         test "Button default" {
             let child = R.div [ClassName "custom"] [R.str "text"]
             let button = Button.ƒ Button.defaults [child]

             button
             |> ReactNode.unit
             >>= hasUniqueClass "btn"
             |> containsChild 1 (child |> ReactNode.unit)
         }

         test "Button kind primary" {
             let child = R.str "text"
             let button = Button.ƒ { Button.defaults with Kind = Button.Kind.Primary } [child]

             button
             |> ReactNode.unit 
             >>= containsClassName "btn btn-primary"
             |> containsChild 1 (child |> ReactNode.unit)
         }

         test "Button kind link" {
             let child = R.str "text"
             let button = Button.ƒ { Button.defaults with Kind = Button.Kind.Link } [child]

             button
             |> ReactNode.unit
             >>= containsClassName "btn btn-link"
             |> containsChild 1 (child |> ReactNode.unit)
         }

         test "Button color success" {
             let child = R.str "text"
             let button = Button.ƒ { Button.defaults with Color = Button.Color.Success } [child]

             button
             |> ReactNode.unit
             >>= containsClassName "btn btn-success"
             |> containsChild 1 (child |> ReactNode.unit)
         }

         test "Button color error" {
             let child = R.str "text"
             let button = Button.ƒ { Button.defaults with Color = Button.Color.Error } [child]

             button
             |> ReactNode.unit
             >>= containsClassName "btn btn-error"
             |> containsChild 1 (child |> ReactNode.unit)
         }

         test "Button size small" {
             let child = R.str "text"
             let button = Button.ƒ { Button.defaults with Size = Button.Size.Small } [child]

             button
             |> ReactNode.unit
             >>= containsClassName "btn btn-sm"
             |> containsChild 1 (child |> ReactNode.unit)
         }

         test "Button size large" {
             let child = R.str "text"
             let button = Button.ƒ { Button.defaults with Size = Button.Size.Large } [child]

             button
             |> ReactNode.unit
             >>= containsClassName "btn btn-lg"
             |> containsChild 1 (child |> ReactNode.unit)
         }

         test "Button state disabled" {
             let child = R.str "text"
             let button = Button.ƒ { Button.defaults with State = Button.State.Disabled  } [child]

             button
             |> ReactNode.unit
             >>= containsClassName "btn disabled"
             |> containsChild 1 (child |> ReactNode.unit)
         }

         test "Button state active" {
             let child = R.str "text"
             let button = Button.ƒ { Button.defaults with State = Button.State.Active } [child]

             button
             |> ReactNode.unit
             >>= containsClassName "btn active"
             |> containsChild 1 (child |> ReactNode.unit)
         }

         test "Button state loading" {
             let child = R.str "text"
             let button = Button.ƒ { Button.defaults with State = Button.State.Loading } [child]

             button
             |> ReactNode.unit
             >>= containsClassName "btn loading"
             |> containsChild 1 (child |> ReactNode.unit)
         }

         test "Button format squared action" {
             let child = R.str "text"
             let button = Button.ƒ { Button.defaults with Format = Button.Format.SquaredAction } [child]

             button
             |> ReactNode.unit
             >>= containsClassName "btn btn-action"
             |> containsChild 1 (child |> ReactNode.unit)
         }

         test "Button format round action" {
             let child = R.str "text"
             let button = Button.ƒ { Button.defaults with Format = Button.Format.RoundAction } [child]

             button
             |> ReactNode.unit
             >>= containsClassName "btn btn-action circle"
             |> containsChild 1 (child |> ReactNode.unit)
         }

         test "Button children with name" {
             let grandChild = R.span [] []
             let child = R.div [] [grandChild]
             let button = Button.ƒ Button.defaults [child]

             button
             |> ReactNode.unit
             >>= containsClassName "btn"
             >>= containsChild 1 (child |> ReactNode.unit)
             |> containsChild 1 (grandChild |> ReactNode.unit)
         }

         test "Button children with class" {
             let grandChild = R.span [ClassName "grand-child"] []
             let child = R.div [ClassName "child"] [grandChild]
             let button = Button.ƒ { Button.defaults with Size = Button.Size.Small } [child]

             button
             |> ReactNode.unit
             >>= containsClassName "btn btn-sm"
             >>= containsChild 1 (child |> ReactNode.unit)
             |> containsChild 1 (grandChild |> ReactNode.unit)
         }

    ]