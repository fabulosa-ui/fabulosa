module ButtonTests

open Expecto
open ReactNode
open Fable.Helpers.React.Props
open Fabulosa
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Button tests" [

        test "Button should be a react html node" {
            let node = R.Node ("button", [ClassName "btn"], [])
            let subject = Button.ƒ Button.defaults []
            compareNode subject node
        }

    ]