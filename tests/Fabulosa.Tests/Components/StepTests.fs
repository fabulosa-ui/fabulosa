module StepTests

open Expecto
open Fabulosa
open Fabulosa.Step
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Step tests" [

        test "Step default" {
            step ([], [])
            |> ReactNode.unit
            |> hasUniqueClass "step"
        }

        test "Step html props" {
            step ([ P.ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Step children" {
            let step1 = ([], [ R.str "Step 1" ])
            let step2 = Item ([ Active ], [ R.str "Step 2" ])
            let (Item t2) = step2
            let step3 = ([], [ R.str "Step 3" ])
            step ([],[ Item step1; step2; Item step3 ])
            |> ReactNode.unit
            |>! hasChild 1 (stepItem step1 |> ReactNode.unit)
            |>! hasChild 1 (stepItem t2 |> ReactNode.unit)
            |> hasChild 1 (stepItem step3 |> ReactNode.unit)
        }

        test "Step item defaults" {
            stepItem ([], [ R.str "Step" ])
            |> ReactNode.unit
            |> hasUniqueClass "step-item"
        }

        test "Step item active" {
            stepItem ([ Active ], [ R.str "Step" ])
            |> ReactNode.unit
            |> hasClass "active"
        }
        
    ]