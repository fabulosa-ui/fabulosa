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
            let accordion =
                Accordion.ƒ
                    Accordion.defaults
                    [ { Header = "Header One"
                        Content =
                            [ R.a [] [R.str "Item One"]
                              R.a [] [R.str "Item Two"] ] }
                      { Header = "Header Two"
                        Content =
                            [ R.a [] [R.str "Item One"]
                              R.a [] [R.str "Item Two"] ] } ]

            accordion
            |> ReactNode.unit
            |> hasOrderedDescendentClass 2 "accordion accordion-header accordion-body"
        }

        test "Accordion custom icon" {
            let iconProps =
                { Icon.defaults with
                    Kind = Icon.Kind.Forward }
            let accordion =
                Accordion.ƒ
                    { Accordion.defaults with
                        CustomIcon = iconProps }
                    [ { Header = "Header One"
                        Content =
                            [ R.a [] [R.str "Item One"]
                              R.a [] [R.str "Item Two"] ] }
                      { Header = "Header Two"
                        Content =
                            [ R.a [] [R.str "Item One"]
                              R.a [] [R.str "Item Two"] ] } ]
            let icon =
                Icon.ƒ {
                    iconProps with
                        HTMLProps = [ClassName "mr-1"]
                } |> ReactNode.unit

            accordion
            |> ReactNode.unit
            |> hasChild 2 icon
        }

    ]