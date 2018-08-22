module SelectTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fabulosa.Tests.Extensions.TestNodeExtensions

[<Tests>]
let tests =
    testList "Select tests" [

        test "Select default" {
            let props = Select.defaults
            let select = Select.ƒ props []
            select |> hasClasses ["form-select"]
        }

        test "Select size small" {
            let props = { Select.defaults with Size = Select.Size.Small }
            let select = Select.ƒ props []
            select |> hasClasses ["form-select"; "select-sm"]
        }

        test "Select size large" {
            let props = { Select.defaults with Size = Select.Size.Large }
            let select = Select.ƒ props []
            select |> hasClasses ["form-select"; "select-lg"]
        }

        test "Select html props" {
            let props = { Select.defaults with HTMLProps = [ClassName "custom"] }
            let select = Select.ƒ props []
            select |> hasClasses ["form-select"; "custom"]
        }

        test "Select children with name" {
            let props = Select.defaults
            let grandChild = R.RawText "Value"
            let child = Select.Option.ƒ Select.Option.defaults [grandChild]
            let select = Select.ƒ props [child]
            select |> hasDescendent child
            select |> hasDescendent grandChild
        }

        test "Select children with class" {
            let props = Select.defaults
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let select = Select.ƒ props [child]
            select |> hasDescendent child
            select |> hasDescendent grandChild
        }

        test "Option default" {
            let props = Select.Option.defaults
            let child = R.RawText "Value"
            let option = Select.Option.ƒ props [child]
            option |> hasDescendent child
        }

        test "Option html props" {
            let props = { Select.Option.defaults with HTMLProps = [ClassName "custom"] }
            let option = Select.Option.ƒ props []
            option |> hasClasses ["custom"]
        }

        test "Option children with name" {
            let props = Select.Option.defaults
            let grandChild = R.RawText "Value"
            let child = R.span [] [grandChild]
            let option = Select.Option.ƒ props [child]
            option |> hasDescendent child
            option |> hasDescendent grandChild
        }

        test "Option children with class" {
            let props = Select.Option.defaults
            let grandChild = R.RawText "Value"
            let child = R.span [ClassName "custom"] [grandChild]
            let option = Select.Option.ƒ props [child]
            option |> hasDescendent child
            option |> hasDescendent grandChild
        }

        test "Option group default" {
            let props = Select.OptionGroup.defaults
            let child = Select.Option.ƒ Select.Option.defaults []
            let optionGroup = Select.OptionGroup.ƒ props [child]
            optionGroup |> hasDescendent child
        }

        test "Option group html props" {
            let props = { Select.OptionGroup.defaults with HTMLProps = [ClassName "custom"] }
            let optionGroup = Select.OptionGroup.ƒ props []
            optionGroup |> hasClasses ["custom"]
        }

        test "Option group children with name" {
            let props = Select.OptionGroup.defaults
            let grandChild = R.RawText "Value"
            let child = Select.Option.ƒ Select.Option.defaults [grandChild]
            let optionGroup = Select.OptionGroup.ƒ props [child]
            optionGroup |> hasDescendent child
            optionGroup |> hasDescendent grandChild
        }

        test "Option group children with class" {
            let props = Select.OptionGroup.defaults
            let grandChild = R.RawText "Value"
            let child =
                Select.Option.ƒ {
                    Select.Option.defaults with
                        HTMLProps = [ClassName "custom"]
                } [grandChild]
            let optionGroup = Select.OptionGroup.ƒ props [child]
            optionGroup |> hasDescendent child
            optionGroup |> hasDescendent grandChild
        }

    ]