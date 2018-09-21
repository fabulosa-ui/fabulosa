module AccordionTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Accordion tests" [

        test "Accordion default" {
            Accordion.ƒ
                ( Accordion.defaults,
                  [ { Header = "Header One"
                      Body =
                        [ R.a [] [R.str "Item One"]
                          R.a [] [R.str "Item Two"] ] }
                    { Header = "Header Two"
                      Body =
                        [ R.a [] [R.str "Item One"]
                          R.a [] [R.str "Item Two"] ] } ] )
            |> ReactNode.unit
            |> hasOrderedDescendentClass 2 "accordion accordion-header accordion-body"
        }

        test "Accordion custom icon" {
            let iconProps =
                { Icon.defaults with
                    Kind = Icon.Kind.Forward }
            let icon =
                Icon.ƒ
                    { iconProps with
                        HTMLProps = [ ClassName "mr-1" ] }
                |> ReactNode.unit
            Accordion.ƒ
                ( { Accordion.defaults with
                      CustomIcon = iconProps },
                  [ { Header = "Header One"
                      Body =
                        [ R.a [] [R.str "Item One"]
                          R.a [] [R.str "Item Two"] ] }
                    { Header = "Header Two"
                      Body =
                        [ R.a [] [R.str "Item One"]
                          R.a [] [R.str "Item Two"] ] } ] )
            |> ReactNode.unit
            |> hasChild 2 icon
        }

    ]