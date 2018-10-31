module InputTests

open Expecto
open Fabulosa
open Fabulosa.Icon
open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Input tests" [

        //test "Input default" {
        //    let props = Input.props
        //    let input = Input.ƒ props

        //    input
        //    |> ReactNode.unit
        //    |> hasUniqueClass "form-input"
        //}

        //test "Input size small" {
        //    let props = { Input.props with Size = Input.Size.Small }
        //    let input = Input.ƒ props

        //    input
        //    |> ReactNode.unit
        //    |> hasClass "input-sm"
        //}

        //test "Input size large" {
        //    let props = { Input.props with Size = Input.Size.Large }
        //    let input = Input.ƒ props
            
        //    input
        //    |> ReactNode.unit
        //    |> hasClass "input-lg"
        //}

        //test "Input html props" {
        //    let props = { Input.props with HTMLProps = [P.ClassName "custom"] }
        //    let input = Input.ƒ props

        //    input
        //    |> ReactNode.unit
        //    |> hasClass "custom"
        //}

        //test "IconInput default" {
        //    let props = IconInput.props
        //    let inputIcon =
        //        IconInput.ƒ
        //            (props,
        //             { Icon = ([], Icon.Kind Download)
        //               Input = Input.props })
        //    let iconElement =
        //        icon ([ P.ClassName "form-icon" ], Icon.Kind Download)
        //        |> ReactNode.unit
        //    let input =
        //        Input.ƒ Input.props
        //        |> ReactNode.unit

        //    inputIcon
        //    |> ReactNode.unit
        //    |>! hasClass "has-icon-left"
        //    |>! hasChild 1 iconElement
        //    |> hasChild 1 input
        //}

        //test "IconInput with icon kind" {
        //    let inputIcon =
        //        IconInput.ƒ
        //            (IconInput.props,
        //             { Icon = ([], Icon.Kind ArrowDown)
        //               Input = Input.props })
        //    let iconElement =
        //        icon ([ P.ClassName "form-icon" ], Icon.Kind ArrowDown)
        //        |> ReactNode.unit
        //    let input =
        //        Input.ƒ Input.props
        //        |> ReactNode.unit

        //    inputIcon
        //    |> ReactNode.unit
        //    |>! hasClass "has-icon-left"
        //    |>! hasChild 1 iconElement
        //    |> hasChild 1 input
        //}

        //test "IconInput with icon size" {
        //    let inputIcon =
        //        IconInput.ƒ
        //            (IconInput.props,
        //             { Icon = ([ Icon.Size X2 ], Icon.Kind Download)
        //               Input = Input.props })
        //    let iconElement =
        //        icon ([ P.ClassName "form-icon"; Icon.Size X2 ], Icon.Kind Download)
        //        |> ReactNode.unit
        //    let input =
        //        Input.ƒ Input.props
        //        |> ReactNode.unit
            
        //    inputIcon
        //    |> ReactNode.unit
        //    |>! hasClass "has-icon-left"
        //    |>! hasChild 1 iconElement
        //    |> hasChild 1 input
        //}

        //test "IconInput with input size" {
        //    let inputT = {
        //        Input.props with
        //            Size = Input.Size.Large
        //            HTMLProps = [P.ClassName "custom-class"]
        //    }
        //    let inputIcon =
        //        IconInput.ƒ
        //            (IconInput.props,
        //             { Icon = ([], Icon.Kind Download)
        //               Input = inputT })
        //    let iconElement =
        //        icon ([ P.ClassName "form-icon"], Icon.Kind Download)
        //        |> ReactNode.unit
        //    let input =
        //        Input.ƒ inputT
        //        |> ReactNode.unit            
        //    inputIcon
        //    |> ReactNode.unit
        //    |>! hasClass "has-icon-left"
        //    |>! hasChild 1 iconElement
        //    |> hasChild 1 input
        //}

        //test "InputGroup default" {
        //    let inputT = Input.props
        //    InputGroup.ƒ
        //        ( InputGroup.props,
        //          [ InputGroup.Child.Input Input.props ] )
        //    |> ReactNode.unit
        //    |>! hasClass "input-group"
        //    |> hasChild 1 (Input.ƒ inputT |> ReactNode.unit)
        //}

        //test "InputGroup left addon" {
        //    let inputT = Input.props
        //    InputGroup.ƒ
        //        ( { InputGroup.props with
        //              AddonLeft = InputGroup.AddonLeft.Text "text" },
        //          [ InputGroup.Child.Input Input.props ] )
        //    |> ReactNode.unit
        //    |>! hasClass "input-group"
        //    |>! hasDescendentClass "input-group-addon"
        //    |> hasChild 1 (Input.ƒ inputT |> ReactNode.unit)
        //}

        //test "InputGroup right addon" {
        //    let inputT = Input.props
        //    let buttonT = [], []
        //    let but =
        //        button ([ P.ClassName "input-group-btn" ], []) |> ReactNode.unit
        //    InputGroup.ƒ
        //        ( { InputGroup.props with
        //              AddonRight = InputGroup.AddonRight.Button
        //                buttonT },
        //          [ InputGroup.Child.Input Input.props ] )
        //    |> ReactNode.unit
        //    |>! hasClass "input-group"
        //    |>! hasDescendentClass "input-group-btn"
        //    |>! hasChild 1 but
        //    |> hasChild 1 (Input.ƒ inputT |> ReactNode.unit)
        //}

        //test "InputGroup left and right addon" {
        //    let inputT = Input.props
        //    let buttonT = [], []
        //    let but =
        //        button ([ P.ClassName "input-group-btn"], [] ) |> ReactNode.unit
        //    InputGroup.ƒ
        //        ( { InputGroup.props with
        //              AddonLeft = InputGroup.AddonLeft.Text "text"
        //              AddonRight = InputGroup.AddonRight.Button
        //                buttonT },
        //          [ InputGroup.Child.Input Input.props ] )
        //    |> ReactNode.unit
        //    |>! hasClass "input-group"
        //    |>! hasDescendentClass "input-group-addon"
        //    |>! hasDescendentClass "input-group-btn"
        //    |>! hasChild 1 but
        //    |> hasChild 1 (Input.ƒ inputT |> ReactNode.unit)
        //}

    ]