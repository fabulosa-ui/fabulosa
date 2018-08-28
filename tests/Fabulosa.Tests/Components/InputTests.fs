﻿module InputTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Input tests" [

        test "Input default" {
            let props = Input.defaults
            let input = Input.ƒ props

            input
            |> ReactNode.unit
            |> hasUniqueClass "form-input"
        }

        test "Input size small" {
            let props = { Input.defaults with Size = Input.Size.Small }
            let input = Input.ƒ props

            input
            |> ReactNode.unit
            |> containsClassName "input-sm"
        }

        test "Input size large" {
            let props = { Input.defaults with Size = Input.Size.Large }
            let input = Input.ƒ props
            
            input
            |> ReactNode.unit
            |> containsClassName "input-lg"
        }

        test "Input html props" {
            let props = { Input.defaults with HTMLProps = [ClassName "custom"] }
            let input = Input.ƒ props

            input
            |> ReactNode.unit
            |> containsClassName "custom"
        }

        test "IconInput default" {
            let props = IconInput.defaults
            let inputIcon = IconInput.ƒ props
            let icon =
                Icon.ƒ {
                    Icon.defaults with
                        HTMLProps = [ClassName "form-icon"]
                } [] |> ReactNode.unit
            let input =
                Input.ƒ Input.defaults
                |> ReactNode.unit

            inputIcon
            |> ReactNode.unit
            >>= containsClassName "has-icon-left"
            >>= containsChild 1 icon
            |> containsChild 1 input
        }

        test "IconInput with icon kind" {
            let inputIcon =
                IconInput.ƒ {
                    IconInput.defaults with
                        IconProps = {
                            Icon.defaults  with
                                Kind = Icon.Kind.ArrowDown
                        }
                }
            let icon =
                Icon.ƒ {
                    Icon.defaults  with
                        Kind = Icon.Kind.ArrowDown
                        HTMLProps = [ClassName "form-icon"]
                } [] |> ReactNode.unit
            let input =
                Input.ƒ Input.defaults
                |> ReactNode.unit

            inputIcon
            |> ReactNode.unit
            >>= containsClassName "has-icon-left"
            >>= containsChild 1 icon
            |> containsChild 1 input
        }

        test "IconInput with icon size" {
            let inputIcon =
                IconInput.ƒ {
                    IconInput.defaults with
                        IconProps = {
                            Icon.defaults  with
                                Size = Icon.Size.X2
                        }
                }
            let icon =
                Icon.ƒ {
                    Icon.defaults  with
                        Size = Icon.Size.X2
                        HTMLProps = [ClassName "form-icon"]
                } [] |> ReactNode.unit
            let input =
                Input.ƒ Input.defaults
                |> ReactNode.unit
            
            inputIcon
            |> ReactNode.unit
            >>= containsClassName "has-icon-left"
            >>= containsChild 1 icon
            |> containsChild 1 input
        }

        test "IconInput with input size" {
            let inputProps = {
                Input.defaults  with
                    Size = Input.Size.Large
                    HTMLProps = [ClassName "custom-class"]
            }
            let props = {
                IconInput.defaults with
                    InputProps = inputProps
            }
            let inputIcon = IconInput.ƒ props
            let icon =
                Icon.ƒ {
                    Icon.defaults with
                        HTMLProps = [ClassName "form-icon"]
                } [] |> ReactNode.unit
            let input =
                Input.ƒ inputProps
                |> ReactNode.unit
            
            inputIcon
            |> ReactNode.unit
            >>= containsClassName "has-icon-left"
            >>= containsChild 1 icon
            |> containsChild 1 input
        }

        test "InputGroup default" {
            let input = Input.ƒ Input.defaults
            let inputGroup =
                InputGroup.ƒ
                    InputGroup.defaults
                    [input]

            inputGroup
            |> ReactNode.unit
            >>= containsClassName "input-group"
            |> containsChild 1 (input |> ReactNode.unit)
        }

        test "InputGroup left addon" {
            let input = Input.ƒ Input.defaults
            let inputGroup =
                InputGroup.ƒ {
                    InputGroup.defaults with
                        AddonLeft = InputGroup.AddonLeft.Text "text"
                } [input]

            inputGroup
            |> ReactNode.unit
            >>= containsClassName "input-group"
            >>= containsDescedentClassName "input-group-addon"
            |> containsChild 1 (input |> ReactNode.unit)
        }

        test "InputGroup right addon" {
            let input = Input.ƒ Input.defaults
            let buttonProps = Button.defaults
            let buttonChildren = []
            let inputGroup =
                InputGroup.ƒ {
                    InputGroup.defaults with
                        AddonRight = InputGroup.AddonRight.Button
                            (buttonProps, buttonChildren)
                } [input]
            let button =
                Button.ƒ {
                    buttonProps with
                        HTMLProps = [ClassName "input-group-btn"]
                } buttonChildren |> ReactNode.unit

            inputGroup
            |> ReactNode.unit
            >>= containsClassName "input-group"
            >>= containsDescedentClassName "input-group-btn"
            >>= containsChild 1 button
            |> containsChild 1 (input |> ReactNode.unit)
        }

        test "InputGroup left and right addon" {
            let input = Input.ƒ Input.defaults
            let buttonProps = Button.defaults
            let buttonChildren = []
            let inputGroup =
                InputGroup.ƒ {
                    InputGroup.defaults with
                        AddonLeft = InputGroup.AddonLeft.Text "text"
                        AddonRight = InputGroup.AddonRight.Button
                            (buttonProps, buttonChildren)
                } [input]
            let button =
                Button.ƒ {
                    buttonProps with
                        HTMLProps = [ClassName "input-group-btn"]
                } buttonChildren |> ReactNode.unit

            inputGroup
            |> ReactNode.unit
            >>= containsClassName "input-group"
            >>= containsDescedentClassName "input-group-addon"
            >>= containsDescedentClassName "input-group-btn"
            >>= containsChild 1 button
            |> containsChild 1 (input |> ReactNode.unit)
        }

    ]