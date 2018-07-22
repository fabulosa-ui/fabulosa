module NavbarTests

open Navbar
open Expecto
open ReactNode
open Fable.Helpers.React.Props
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Navbar tests" [

        test "Navbar header should be a react html node" {
            let node = R.Node ("header", [ClassName "navbar"], [])
            let subject = navbarHeader [] []
            compareNode subject node
        }

        test "Navbar section should be a react html node" {
            let node = R.Node ("section", [ClassName "navbar-section"], [])
            let subject = navbarSection [] []
            compareNode subject node
        }

        test "Navbar center should be a react html node" {
            let node = R.Node ("section", [ClassName "navbar-center"], [])
            let subject = navbarCenter [] []
            compareNode subject node
        }

        test "Navbar brand should be a react html node" {
            let node = R.Node ("a", [ClassName "navbar-brand"], [])
            let subject = navbarBrand [] []
            compareNode subject node
        }

    ]