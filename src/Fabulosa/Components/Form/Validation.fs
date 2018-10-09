namespace Fabulosa

[<RequireQualifiedAccess>]
module Validation =

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Kind =
    | Error of string
    | Success of string

    [<RequireQualifiedAccess>]
    type Children<'Checkbox, 'Input, 'Radio, 'Select, 'Switch> =
        | Checkbox of 'Checkbox
        | Input of 'Input
        | Radio of 'Radio
        | Select of 'Select
        | Switch of 'Switch

    [<RequireQualifiedAccess>]
    type T<'Checkbox, 'Input, 'Radio, 'Select, 'Switch> =
        Kind * Children<'Checkbox, 'Input, 'Radio, 'Select, 'Switch>

    let private message =
        function
        | Kind.Success message -> message 
        | Kind.Error message -> message

    let private kind =
        function
        | Kind.Success _ -> "has-success"
        | Kind.Error _ -> "has-error"

    let build
        checkboxƒ
        inputƒ
        radioƒ
        selectƒ
        switchƒ
        (validation: T<'Checkbox, 'Input, 'Radio, 'Select, 'Switch>) =
        let props, children = validation
        R.span
            [ ClassName <| kind props ]
            [ (match children with
               | Children.Checkbox checkbox -> checkboxƒ checkbox
               | Children.Input input -> inputƒ input
               | Children.Radio radio -> radioƒ radio
               | Children.Select select -> selectƒ select
               | Children.Switch switch -> switchƒ switch)
              R.p [ ClassName "form-input-hint" ] [ R.str <| message props ] ]

    let ƒ =
        build
            Checkbox.ƒ
            Input.ƒ
            Radio.ƒ
            Select.ƒ
            Switch.ƒ