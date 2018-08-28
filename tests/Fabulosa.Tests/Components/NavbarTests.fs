module NavbarTests

open Expecto
open Expect
open Fabulosa

[<Tests>]
let tests =
    testList "Navbar tests" [

        test "Navbar header default" {
            let header = Navbar.Header.ƒ Navbar.defaults []
            
            header
            |> ReactNode.unit
            |> hasUniqueClass "navbar"
        }

        test "Navbar section default" {
            let section = Navbar.Section.ƒ Navbar.defaults []
            
            section
            |> ReactNode.unit
            |> hasUniqueClass "navbar-section"
        }

        test "Navbar center default" {
            let center = Navbar.Center.ƒ Navbar.defaults []
            
            center
            |> ReactNode.unit
            |> hasUniqueClass "navbar-center"
        }

        test "Navbar brand default" {
            let brand = Navbar.Brand.ƒ Navbar.defaults []
            
            brand
            |> ReactNode.unit
            |> hasUniqueClass "navbar-brand"
        }

    ]