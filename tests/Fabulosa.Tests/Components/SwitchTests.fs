﻿module SwitchTests

open Expecto
open Fabulosa
open Fabulosa.Switch
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Switch tests" [

        test "Switch default" {
            let input =
                R.input [Type "checkbox"]
                |> ReactNode.unit
            let icon =
                R.i [ClassName "form-icon"] []
                |> ReactNode.unit
            let label =
                R.str "Switch"
                |> ReactNode.unit
 
            switch ([], Text "Switch")
            |> ReactNode.unit
            |>! hasUniqueClass "form-switch"
            |>! hasChild 1 input
            |>! hasChild 1 icon
            |>! hasChild 1 label
            |> hasText "Switch"
        }

        test "Switch html props" {
            let prop = ClassName "custom"
            switch ([ prop ], Text "Switch")
            |> ReactNode.unit
            |>! hasUniqueClass "form-switch"
            |> hasDescendentProp prop
        }

    ]