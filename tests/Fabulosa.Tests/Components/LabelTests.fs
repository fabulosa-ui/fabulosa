﻿module LabelTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props

[<Tests>]
let tests =
    testList "Label tests" [

        // test "Label default" {
        //     let props = Label.defaults
        //     let label = Label.ƒ props
        //     label |> hasClasses ["form-label"]
        // }

        // test "Label size small" {
        //     let props = { Label.defaults with Size = Label.Size.Small }
        //     let label = Label.ƒ props
        //     label |> hasClasses ["form-label"; "label-sm"]
        // }

        // test "Label size large" {
        //     let props = { Label.defaults with Size = Label.Size.Large }
        //     let label = Label.ƒ props
        //     label |> hasClasses ["form-label"; "label-lg"]
        // }

        // test "Label text" {
        //     let props = { Label.defaults with Text = "custom" }
        //     let label = Label.ƒ props
        //     label |> hasClasses ["form-label"]
        //     label |> hasDescendent (R.str "custom")
        // }

        // test "Label html props" {
        //     let props = { Label.defaults with HTMLProps = [ClassName "custom"] }
        //     let label = Label.ƒ props
        //     label |> hasClasses ["form-label"; "custom"]
        // }

    ]