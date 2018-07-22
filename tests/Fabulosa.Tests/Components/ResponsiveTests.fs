module ResponsiveTests

open Responsive
open Expecto
open ReactNode
open Fable.Helpers.React.Props
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Responsive tests" [

        test "Responsive props should map to classes" {
            let responsiveProps = [ResponsiveHide ResponsiveXS; ResponsiveShow ResponsiveLG]
            let subject = List.map hideOrShowClasses responsiveProps
            Expect.containsAll subject ["hide-xs"; "show-lg"] "Should contain show and hide class"
        }

        test "Responsive without should be a react html node" {
            let node = R.Node ("div", [ClassName "responsive"], [])
            let subject = responsive [] R.div [] []
            compareNode subject node
        }

        test "Responsive with props should be a react html node" {
            let custom _ props _ = R.div props []
            let node = R.Node ("div", [ClassName "responsive"], [])
            let subject = responsiveP [] custom [] [] []
            compareNode subject node
        }

    ]