module ButtonTests

open Button
open Expecto
open ReactNode
open Fable.Helpers.React.Props
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Button tests" [

        test "Button props should map to classes" {
            let buttonProps = [ButtonKind ButtonDefault; ButtonFormat ButtonSquaredAction]
            let subject = List.map buttonClasses buttonProps
            Expect.containsAll subject ["btn-default"; "btn-action"] "Should contain default button class"
        }

        test "Button should be a react html node" {
            let node = R.Node ("button", [ClassName "btn"], [])
            let subject = button [] [] []
            compareNode subject node
        }

    ]