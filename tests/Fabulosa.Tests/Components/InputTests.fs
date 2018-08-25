module InputTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fabulosa.Tests.Extensions.TestNodeExtensions
open Fabulosa.Tests.Extensions.ReactNode

[<Tests>]
let tests =
    testList "Input tests" [

        test "Input default" {
            let props = Input.defaults
            let input = Input.ƒ props
            input |> hasClasses ["form-input"]
        }

        test "Input size small" {
            let props = { Input.defaults with Size = Input.Size.Small }
            let input = Input.ƒ props
            input |> hasClasses ["form-input"; "input-sm"]
        }

        test "Input size large" {
            let props = { Input.defaults with Size = Input.Size.Large }
            let input = Input.ƒ props
            input |> hasClasses ["form-input"; "input-lg"]
        }

        test "Input html props" {
            let props = { Input.defaults with HTMLProps = [ClassName "custom"] }
            let input = Input.ƒ props
            input |> hasClasses ["form-input"; "custom"]
        }

        test "IconInput default" {
            let props = IconInput.defaults
            let inputIcon = IconInput.ƒ props
            let icon = Icon.ƒ { Icon.defaults with HTMLProps = [ClassName "form-icon"] } []
            let input = Input.ƒ Input.defaults
            inputIcon |> hasClasses ["has-icon-left"]
            inputIcon |> hasDescendent icon
            inputIcon |> hasDescendent input
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
                } []
            let input = Input.ƒ Input.defaults
            inputIcon |> hasClasses ["has-icon-left"]
            inputIcon |> found icon
            inputIcon |> found input
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
                } []
            let input = Input.ƒ Input.defaults
            inputIcon |> hasClasses ["has-icon-left"]
            inputIcon |> found icon
            inputIcon |> found input
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
            let icon = Icon.ƒ { Icon.defaults with HTMLProps = [ClassName "form-icon"] } []
            let input = Input.ƒ inputProps
            inputIcon |> hasClasses ["has-icon-left"]
            inputIcon |> hasDescendent icon
            inputIcon |> hasDescendent input
        }

        test "InputGroup default" {
            let input = Input.ƒ Input.defaults
            let inputGroup =
                InputGroup.ƒ
                    InputGroup.defaults
                    [input]
            inputGroup |> hasClasses ["input-group"]
            inputGroup |> hasDescendent input
        }

        test "InputGroup left addon" {
            let input = Input.ƒ Input.defaults
            let inputGroup =
                InputGroup.ƒ {
                    InputGroup.defaults with
                        AddonLeft = InputGroup.AddonLeft.Text "text"
                } [input]
            inputGroup |> hasClasses ["input-group"]
            inputGroup |> hasDescendentClass "input-group-addon"
            inputGroup |> hasDescendent input
        }

        test "find returns a subnode one level deep" {
            let root = R.div [] [
               R.span [] [
                   R.p [] [
                       R.p [] []
                   ]
               ]
               R.p [] []
            ]
            root |> found (R.p [] [])
        }

        // test "InputGroup right addon" {
        //     let input = Input.ƒ Input.defaults
        //     let buttonProps = Button.defaults
        //     let buttonChildren = []
        //     let button = Button.ƒ buttonProps buttonChildren
        //     let inputGroup =
        //         InputGroup.ƒ {
        //             InputGroup.defaults with
        //                 AddonRight = InputGroup.AddonRight.Button
        //                     (buttonProps, buttonChildren)
        //         } [input]
        //     inputGroup |> hasClasses ["input-group"]
        //     inputGroup |> hasDescendentClass "input-group-btn"
        //     inputGroup |> hasDescendent button
        //     inputGroup |> hasDescendent input
        // }

        // test "InputGroup left and right addon" {
        //     let input = Input.ƒ Input.defaults
        //     let buttonProps = Button.defaults
        //     let buttonChildren = []
        //     let button = Button.ƒ buttonProps buttonChildren
        //     let inputGroup =
        //         InputGroup.ƒ {
        //             InputGroup.defaults with
        //                 AddonLeft = InputGroup.AddonLeft.Text "text"
        //                 AddonRight = InputGroup.AddonRight.Button
        //                     (buttonProps, buttonChildren)
        //         } [input]
        //     inputGroup |> hasClasses ["input-group"]
        //     inputGroup |> hasDescendentClass "input-group-addon"
        //     inputGroup |> hasDescendentClass "input-group-btn"
        //     inputGroup |> hasDescendent button
        //     inputGroup |> hasDescendent input
        // }

    ]