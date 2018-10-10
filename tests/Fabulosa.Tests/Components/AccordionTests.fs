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
                (Accordion.props,
                 [ { Header =
                        { Accordion.Header.children with
                            Text = "Header One"}
                     Body =
                       [ R.a [] [ R.str "Item One" ]
                         R.a [] [ R.str "Item Two" ] ] }
                   { Header =
                        { Accordion.Header.children with
                            Text = "Header Two" }
                     Body =
                       [ R.a [] [ R.str "Item One" ]
                         R.a [] [ R.str "Item Two" ] ] } ])
            |> ReactNode.unit
            |> hasOrderedDescendentClass 2 "accordion accordion-header accordion-body"
        }

        test "Accordion custom icon" {
            let iconT =
                { Icon.props with
                    Kind = Icon.Kind.Forward }
            let icon =
                Icon.ƒ
                    { iconT with
                        HTMLProps = [ ClassName "mr-1" ] }
                |> ReactNode.unit
            Accordion.ƒ
                (Accordion.props,
                 [ { Header =
                        { Icon = iconT
                          Text = "Header One"}
                     Body =
                       [ R.a [] [ R.str "Item One" ]
                         R.a [] [ R.str "Item Two" ] ] }
                   { Header =
                        { Icon = iconT
                          Text = "Header One" }
                     Body =
                       [ R.a [] [ R.str "Item One" ]
                         R.a [] [ R.str "Item Two" ] ] } ])
            |> ReactNode.unit
            |> hasChild 2 icon
        }

    ]