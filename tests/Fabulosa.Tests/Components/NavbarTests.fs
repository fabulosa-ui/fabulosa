module NavbarTests

open Expecto
open Fabulosa
open Fabulosa.Tests.Extensions.TestNodeExtensions

[<Tests>]
let tests =
    testList "Navbar tests" [

        test "Navbar header default" {
            let header = Navbar.Header.ƒ Navbar.defaults []
            header |> hasClasses ["navbar"]
        }

        test "Navbar section default" {
            let section = Navbar.Section.ƒ Navbar.defaults []
            section |> hasClasses ["navbar-section"]
        }

        test "Navbar center default" {
            let center = Navbar.Center.ƒ Navbar.defaults []
            center |> hasClasses ["navbar-center"]
        }

        test "Navbar brand default" {
            let brand = Navbar.Brand.ƒ Navbar.defaults []
            brand |> hasClasses ["navbar-brand"]
        }

    ]