namespace Fabulosa

[<RequireQualifiedAccess>]
module Group =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type Child<'Checkbox, 'Input, 'InputGroup, 'Label, 'Radio, 'Select, 'Switch, 'Textarea> =
        | Checkbox of 'Checkbox
        | Input of 'Input
        | InputGroup of 'InputGroup
        | Label of 'Label
        | Radio of 'Radio
        | Select of 'Select
        | Switch of 'Switch
        | Textarea of 'Textarea


    [<RequireQualifiedAccess>]
    type Children<'Checkbox, 'Input, 'InputGroup, 'Label, 'Radio, 'Select, 'Switch, 'Textarea> =
        Child<'Checkbox, 'Input, 'InputGroup, 'Label, 'Radio, 'Select, 'Switch, 'Textarea> list

    [<RequireQualifiedAccess>]
    type T<'Checkbox, 'Input, 'InputGroup, 'Label, 'Radio, 'Select, 'Switch, 'Textarea> =
        Props * Children<'Checkbox, 'Input, 'InputGroup, 'Label, 'Radio, 'Select, 'Switch, 'Textarea>

    let props =
        { Props.HTMLProps = [] }
        
    let build
        checkboxƒ
        inputƒ
        inputGroupƒ
        labelƒ
        radioƒ
        selectƒ
        switchƒ
        textareaƒ
        (group: T<'Checkbox, 'Input, 'InputGroup, 'Label, 'Radio, 'Select, 'Switch, 'Textarea>) =
        let props, children = group
        props.HTMLProps
        |> addProp (ClassName "form-group")
        |> R.div
        <| Seq.map
            (function
             | Child.Checkbox checkbox -> checkboxƒ checkbox
             | Child.Input input -> inputƒ input
             | Child.InputGroup inputGroup -> inputGroupƒ inputGroup
             | Child.Label label -> labelƒ label
             | Child.Radio radio -> radioƒ radio
             | Child.Select select -> selectƒ select
             | Child.Switch switch -> switchƒ switch
             | Child.Textarea textarea -> textareaƒ textarea)
             children

    let ƒ =
        build
            Checkbox.ƒ
            Input.ƒ
            InputGroup.ƒ
            Label.ƒ
            Radio.ƒ
            Select.ƒ
            Switch.ƒ
            Textarea.ƒ