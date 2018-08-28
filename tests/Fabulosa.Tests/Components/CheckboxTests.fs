﻿module CheckboxTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props

[<Tests>]
let tests =
    testList "Checkbox tests" [

        // test "Checkbox default" {
        //     let props = Checkbox.defaults
        //     let checkbox = Checkbox.ƒ props
        //     checkbox |> hasClasses ["form-checkbox"]
        //     checkbox |> hasDescendent (R.input [Type "checkbox"])
        //     checkbox |> hasDescendent (R.i [ClassName "form-icon"] [])
        //     checkbox |> hasDescendent (R.str "Label")
        // }

        // test "Checkbox inline" {
        //     let props = { Checkbox.defaults with Inline = true }
        //     let checkbox = Checkbox.ƒ props
        //     checkbox |> hasClasses ["form-checkbox"; "form-inline"]
        // }

        // test "Checkbox text" {
        //     let props = { Checkbox.defaults with Text = "custom" }
        //     let checkbox = Checkbox.ƒ props
        //     checkbox |> hasClasses ["form-checkbox"]
        //     checkbox |> hasDescendent (R.str "custom")
        // }

        // test "Checkbox html props" {
        //     let props = { Checkbox.defaults with HTMLProps = [ClassName "custom"] }
        //     let checkbox = Checkbox.ƒ props
        //     checkbox |> hasClasses ["form-checkbox"]
        //     checkbox |> hasDescendent (R.input [ClassName "custom"])
        // }

    ]