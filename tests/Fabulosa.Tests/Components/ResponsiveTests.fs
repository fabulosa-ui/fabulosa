module ResponsiveTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fabulosa.Tests.Extensions

[<Tests>]
let tests =
    testList "Responsive tests" [
        test "Responsive default" {
            let child = R.str "text"
            let props = Responsive.defaults
            let responsiveElement = Responsive.ƒ props [child]
            
            responsiveElement 
            |> Expect.containsClassNameBind "responsive"
            |> Expect.containsChild 1 child
        }

        test "Responsive hide small" {
            let child = Button.ƒ Button.defaults [R.str "text"]
            let props = { Responsive.defaults with Hide = Responsive.Size.SM }
            let responsiveElement = Responsive.ƒ props [child]
            
            responsiveElement 
            |> Expect.containsClassNameBind "responsive hide-sm"
            |> Expect.containsChild 1 child
        }

        test "Responsive show large" {
            let child = Button.ƒ Button.defaults [R.str "text"]
            let props = { Responsive.defaults with Show = Responsive.Size.LG }
            let responsiveElement = Responsive.ƒ props [child]
            
            responsiveElement 
            |> Expect.containsClassNameBind "responsive show-lg"
            |> Expect.containsChild 1 child
        }

        test "Responsive children with name" {
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            let props = Responsive.defaults
            let responsiveElement = Responsive.ƒ props [child]
            
            responsiveElement 
            |> Expect.containsChildBind 1 child
            |> Expect.containsChild 1 grandChild
        }

        test "Responsive children with class" {
            let props = Responsive.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let responsiveElement = Responsive.ƒ props [child]
            
            responsiveElement 
            |> Expect.containsChildBind 1 child
            |> Expect.containsChild 1 grandChild
        }
    ]