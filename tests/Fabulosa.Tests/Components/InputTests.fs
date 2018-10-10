module InputTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Input tests" [

        test "Input default" {
            let props = Input.props
            let input = Input.ƒ props

            input
            |> ReactNode.unit
            |> hasUniqueClass "form-input"
        }

        test "Input size small" {
            let props = { Input.props with Size = Input.Size.Small }
            let input = Input.ƒ props

            input
            |> ReactNode.unit
            |> hasClass "input-sm"
        }

        test "Input size large" {
            let props = { Input.props with Size = Input.Size.Large }
            let input = Input.ƒ props
            
            input
            |> ReactNode.unit
            |> hasClass "input-lg"
        }

        test "Input html props" {
            let props = { Input.props with HTMLProps = [ClassName "custom"] }
            let input = Input.ƒ props

            input
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "IconInput default" {
            let props = IconInput.props
            let inputIcon =
                IconInput.ƒ
                    (props,
                     { Icon = Icon.props
                       Input = Input.props })
            let icon =
                Icon.ƒ {
                    Icon.props with
                        HTMLProps = [ClassName "form-icon"]
                } |> ReactNode.unit
            let input =
                Input.ƒ Input.props
                |> ReactNode.unit

            inputIcon
            |> ReactNode.unit
            |>! hasClass "has-icon-left"
            |>! hasChild 1 icon
            |> hasChild 1 input
        }

        test "IconInput with icon kind" {
            let inputIcon =
                IconInput.ƒ
                    (IconInput.props,
                     { Icon =
                        { Icon.props  with
                            Kind = Icon.Kind.ArrowDown }
                       Input = Input.props })
            let icon =
                Icon.ƒ {
                    Icon.props  with
                        Kind = Icon.Kind.ArrowDown
                        HTMLProps = [ClassName "form-icon"]
                } |> ReactNode.unit
            let input =
                Input.ƒ Input.props
                |> ReactNode.unit

            inputIcon
            |> ReactNode.unit
            |>! hasClass "has-icon-left"
            |>! hasChild 1 icon
            |> hasChild 1 input
        }

        test "IconInput with icon size" {
            let inputIcon =
                IconInput.ƒ
                    (IconInput.props,
                     { Icon =
                        { Icon.props  with
                            Size = Icon.Size.X2 }
                       Input = Input.props })
            let icon =
                Icon.ƒ {
                    Icon.props  with
                        Size = Icon.Size.X2
                        HTMLProps = [ClassName "form-icon"]
                } |> ReactNode.unit
            let input =
                Input.ƒ Input.props
                |> ReactNode.unit
            
            inputIcon
            |> ReactNode.unit
            |>! hasClass "has-icon-left"
            |>! hasChild 1 icon
            |> hasChild 1 input
        }

        test "IconInput with input size" {
            let inputT = {
                Input.props with
                    Size = Input.Size.Large
                    HTMLProps = [ClassName "custom-class"]
            }
            let inputIcon =
                IconInput.ƒ
                    (IconInput.props,
                     { Icon = Icon.props
                       Input = inputT })
            let icon =
                Icon.ƒ
                    { Icon.props with
                        HTMLProps = [ ClassName "form-icon" ] }
                    |> ReactNode.unit
            let input =
                Input.ƒ inputT
                |> ReactNode.unit
            
            inputIcon
            |> ReactNode.unit
            |>! hasClass "has-icon-left"
            |>! hasChild 1 icon
            |> hasChild 1 input
        }

        test "InputGroup default" {
            let inputT = Input.props
            InputGroup.ƒ
                ( InputGroup.props,
                  [ InputGroup.Child.Input Input.props ] )
            |> ReactNode.unit
            |>! hasClass "input-group"
            |> hasChild 1 (Input.ƒ inputT |> ReactNode.unit)
        }

        test "InputGroup left addon" {
            let inputT = Input.props
            InputGroup.ƒ
                ( { InputGroup.props with
                      AddonLeft = InputGroup.AddonLeft.Text "text" },
                  [ InputGroup.Child.Input Input.props ] )
            |> ReactNode.unit
            |>! hasClass "input-group"
            |>! hasDescendentClass "input-group-addon"
            |> hasChild 1 (Input.ƒ inputT |> ReactNode.unit)
        }

        test "InputGroup right addon" {
            let inputT = Input.props
            let buttonT = Button.props, []
            let button =
                Button.ƒ
                    ( { Button.props with
                          HTMLProps = [ ClassName "input-group-btn" ] },
                      [] ) |> ReactNode.unit
            InputGroup.ƒ
                ( { InputGroup.props with
                      AddonRight = InputGroup.AddonRight.Button
                        buttonT },
                  [ InputGroup.Child.Input Input.props ] )
            |> ReactNode.unit
            |>! hasClass "input-group"
            |>! hasDescendentClass "input-group-btn"
            |>! hasChild 1 button
            |> hasChild 1 (Input.ƒ inputT |> ReactNode.unit)
        }

        test "InputGroup left and right addon" {
            let inputT = Input.props
            let buttonT = Button.props, []
            let button =
                Button.ƒ
                    ( { Button.props with
                          HTMLProps = [ClassName "input-group-btn"] },
                      [] ) |> ReactNode.unit
            InputGroup.ƒ
                ( { InputGroup.props with
                      AddonLeft = InputGroup.AddonLeft.Text "text"
                      AddonRight = InputGroup.AddonRight.Button
                        buttonT },
                  [ InputGroup.Child.Input Input.props ] )
            |> ReactNode.unit
            |>! hasClass "input-group"
            |>! hasDescendentClass "input-group-addon"
            |>! hasDescendentClass "input-group-btn"
            |>! hasChild 1 button
            |> hasChild 1 (Input.ƒ inputT |> ReactNode.unit)
        }

    ]