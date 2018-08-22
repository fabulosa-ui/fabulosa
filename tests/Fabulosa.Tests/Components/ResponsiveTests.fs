module ResponsiveTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fabulosa.Tests.Extensions.TestNodeExtensions

[<Tests>]
let tests =
    testList "Responsive tests" [

        test "Responsive default" {
            let props = Responsive.defaults
            let child = Button.ƒ Button.defaults [R.str "text"]
            let responsive = Responsive.ƒ props [child]
            responsive |> hasClasses ["responsive"]
            responsive |> hasDescendent child
        }

        test "Responsive hide small" {
            let props = { Responsive.defaults with Hide = Responsive.Size.SM }
            let child = Button.ƒ Button.defaults [R.str "text"]
            let responsive = Responsive.ƒ props [child]
            responsive |> hasClasses ["responsive"; "hide-sm"]
            responsive |> hasDescendent child
        }

        test "Responsive show large" {
            let props = { Responsive.defaults with Show = Responsive.Size.LG }
            let child = Button.ƒ Button.defaults [R.str "text"]
            let responsive = Responsive.ƒ props [child]
            responsive |> hasClasses ["responsive"; "show-lg"]
            responsive |> hasDescendent child
        }

        test "Responsive children with name" {
            let props = Responsive.defaults
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            let responsive = Responsive.ƒ props [child]
            responsive |> hasDescendent child
            responsive |> hasDescendent grandChild
        }

        test "Responsive children with class" {
            let props = Responsive.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let responsive = Responsive.ƒ props [child]
            responsive |> hasDescendent child
            responsive |> hasDescendent grandChild
        }

    ]