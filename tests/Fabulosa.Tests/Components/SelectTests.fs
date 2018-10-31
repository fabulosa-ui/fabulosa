module SelectTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Select tests" [

        //test "Select default" {
        //    let props = Select.props
        //    let select = Select.ƒ (props, [])
            
        //    select
        //    |> ReactNode.unit
        //    |> hasUniqueClass "form-select"
        //}

        //test "Select size small" {
        //    let props = { Select.props with Size = Select.Size.Small }
        //    let select = Select.ƒ (props, [])
            
        //    select
        //    |> ReactNode.unit
        //    |> hasClass "select-sm"
        //}

        //test "Select size large" {
        //    let props = { Select.props with Size = Select.Size.Large }
        //    let select = Select.ƒ (props, [])
            
        //    select
        //    |> ReactNode.unit
        //    |> hasClass "select-lg"
        //}

        //test "Select html props" {
        //    let props = { Select.props with HTMLProps = [ClassName "custom"] }
        //    let select = Select.ƒ (props, [])
            
        //    select
        //    |> ReactNode.unit
        //    |> hasClass "custom"
        //}

        //test "Select children with name" {
        //    let optionProps = (Select.Option.props, "Value")
        //    let child = Select.Option.ƒ optionProps
        //    Select.ƒ
        //        (Select.props, [ Select.Child.Option optionProps ])
        //    |> ReactNode.unit
        //    |>! hasChild 1 (child |> ReactNode.unit)
        //    |> hasText "Value"
        //}

        //test "Option default" {
        //    Select.Option.ƒ (Select.Option.props, "Value")
        //    |> ReactNode.unit
        //    |> hasText "Value"
        //}

        //test "Option html props" {
        //    let props =
        //        { Select.Option.props with
        //            HTMLProps = [ ClassName "custom" ] }
        //    Select.Option.ƒ (props, "Value")
        //    |> ReactNode.unit
        //    |> hasClass "custom"
        //}

        //test "Option group default" {
        //    let child =
        //        Select.Option.ƒ
        //            (Select.Option.props, "Value")
        //    Select.OptionGroup.ƒ
        //        (Select.OptionGroup.props,
        //         [ Select.Option.props, "Value" ])
        //    |> ReactNode.unit
        //    |> hasChild 1 (child |> ReactNode.unit)
        //}

        //test "Option group html props" {
        //    let props =
        //        { Select.OptionGroup.props with
        //            HTMLProps = [ ClassName "custom" ] }
        //    Select.OptionGroup.ƒ
        //        ( props, [] )
        //    |> ReactNode.unit
        //    |> hasClass "custom"
        //}

    ]