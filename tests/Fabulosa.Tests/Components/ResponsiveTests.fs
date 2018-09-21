module ResponsiveTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Responsive tests" [
         test "Responsive default" {
            let child = R.str "text"
            let props = Responsive.defaults
            Responsive.ƒ ( props, [ child ] )
            |> ReactNode.unit
            |>! hasClass "responsive"
            |> hasChild 1 (child |> ReactNode.unit)
         }

         test "Responsive hide small" {
            let child = Button.ƒ ( Button.defaults, [R.str "text"] )
            let props = { Responsive.defaults with Hide = Responsive.Size.SM }
            Responsive.ƒ ( props, [ child ] )
            |> ReactNode.unit
            |>! hasClass "responsive hide-sm"
            |> hasChild 1 (child |> ReactNode.unit)
         }

         test "Responsive show large" {
            let child = Button.ƒ ( Button.defaults, [R.str "text"] )
            let props = { Responsive.defaults with Show = Responsive.Size.LG }
            Responsive.ƒ ( props, [ child ] )
            |> ReactNode.unit
            |>! hasClass "responsive show-lg"
            |> hasChild 1 (child |> ReactNode.unit)
         }

         test "Responsive children with name" {
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            let props = Responsive.defaults
            Responsive.ƒ ( props, [ child ] )
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
         }

         test "Responsive children with class" {
            let props = Responsive.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            Responsive.ƒ ( props, [ child ] )
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
         }
    ]