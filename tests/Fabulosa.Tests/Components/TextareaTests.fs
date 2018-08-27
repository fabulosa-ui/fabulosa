﻿module TextareaTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fabulosa.Tests.Extensions

[<Tests>]
let tests =
    testList "Textarea tests" [

        // test "Textarea default" {
        //     let props = Textarea.defaults
        //     let textarea = Textarea.ƒ props []
        //     textarea |> hasClasses ["form-input"]
        // }

        // test "Textarea html props" {
        //     let props = { Textarea.defaults with HTMLProps = [ClassName "custom"] }
        //     let textarea = Textarea.ƒ props []
        //     textarea |> hasClasses ["form-input"; "custom"]
        // }

        // test "Textarea children with name" {
        //     let props = Textarea.defaults
        //     let grandChild = R.span [] []
        //     let child = R.div [] [grandChild]
        //     let textarea = Textarea.ƒ props [child]
        //     textarea |> hasDescendent child
        //     textarea |> hasDescendent grandChild
        // }

        // test "Textarea children with class" {
        //     let props = Textarea.defaults
        //     let grandChild = R.span [ClassName "grand-child"] []
        //     let child = R.div [ClassName "child"] [grandChild]
        //     let textarea = Textarea.ƒ props [child]
        //     textarea |> hasDescendent child
        //     textarea |> hasDescendent grandChild
        // }

    ]