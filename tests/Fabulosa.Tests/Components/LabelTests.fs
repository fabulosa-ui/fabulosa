module LabelTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Label tests" [

        //test "Label default" {
        //    Label.ƒ (Label.props, "Label")
        //    |> ReactNode.unit
        //    |>! hasUniqueClass "form-label"
        //    |> hasText "Label"
        //}

        //test "Label size small" {
        //    Label.ƒ
        //        ({ Label.props with
        //             Size = Label.Size.Small },
        //         "Label")
        //    |> ReactNode.unit
        //    |> hasClass "label-sm"
        //}

        //test "Label size large" {
        //    Label.ƒ
        //        ({ Label.props with
        //             Size = Label.Size.Large },
        //         "Label")
        //    |> ReactNode.unit
        //    |> hasClass "label-lg"
        //}
       
        //test "Label html props" {
        //    Label.ƒ
        //        ({ Label.props with
        //             HTMLProps =
        //               [ ClassName "custom" ] },
        //         "Label")
        //    |> ReactNode.unit
        //    |> hasClass "form-label custom"
        //}

    ]