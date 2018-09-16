module MenuTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Menu tests" [

        //test "Menu default" {
        //    Menu.ƒ
        //        Menu.defaults 
        //        []
        //    |> ReactNode.unit
        //    |> hasUniqueClass "menu"
        //}

        //test "Menu html props" {
        //    Menu.ƒ
        //        { Menu.defaults with 
        //            HTMLProps = [ClassName "custom"] }
        //        []
        //    |> ReactNode.unit
        //    |> hasClass "menu custom"
        //}

        //test "Menu with single item" {
        //    let link =
        //        R.a
        //            [ ClassName "custom" ]
        //            [ R.str "link" ]
        //    Menu.ƒ
        //        Menu.defaults
        //        [ Menu.Child.Item [ link ] ]
        //    |> ReactNode.unit
        //    |>! hasChild 1 (link |> ReactNode.unit)
        //    |> hasDescendentClass "menu-item"
        //}

        //test "Menu with item and empty divider" {
        //    let link =
        //        R.a
        //            [ ClassName "custom" ]
        //            [ R.str "link" ]
        //    Menu.ƒ
        //        Menu.defaults
        //        [ Menu.Child.Item [ link ]
        //          Menu.Child.Divider Menu.Divider.Empty ]
        //    |> ReactNode.unit
        //    |>! hasChild 1 (link |> ReactNode.unit)
        //    |>! hasDescendentClass "menu-item"
        //    |> hasDescendentClass "divider"
        //}

        //test "Menu with item and text divider" {
        //    let link =
        //        R.a
        //            [ ClassName "custom" ]
        //            [ R.str "link" ]
        //    Menu.ƒ
        //        Menu.defaults
        //        [ Menu.Child.Item [ link ]
        //          Menu.Child.Divider <| Menu.Divider.Text "text" ]
        //    |> ReactNode.unit
        //    |>! hasChild 1 (link |> ReactNode.unit)
        //    |>! hasDescendentClass "menu-item"
        //    |>! hasDescendentClass "divider"
        //    |> hasDescendentProp (Data ("content", "text"))
        //}

        //test "Menu with multiple items and dividers" {
        //    let link1 =
        //        R.a
        //            [ ClassName "link1" ]
        //            [ R.str "link1" ]
        //    let link2 =
        //        R.span
        //            [ ClassName "link2" ]
        //            [ R.str "link2" ]
        //    Menu.ƒ
        //        Menu.defaults
        //        [ Menu.Child.Item [ link1 ]
        //          Menu.Child.Divider <| Menu.Divider.Text "text"
        //          Menu.Child.Item [ link2 ]
        //          Menu.Child.Divider Menu.Divider.Empty ]
        //    |> ReactNode.unit
        //    |>! hasChild 1 (link1 |> ReactNode.unit)
        //    |>! hasChild 1 (link2 |>  ReactNode.unit)
        //    |>! hasOrderedDescendentClass 2 "menu-item divider"
        //    |>! hasText "link1 link2"
        //    |> hasDescendentProp (Data ("content", "text"))
        //}
    ]