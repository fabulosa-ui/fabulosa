namespace Fabulosa

[<RequireQualifiedAccess>]
module Input =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Size =
    | Small
    | Large
    | Unset

    [<RequireQualifiedAccess>]
    type Props =
        { Size: Size
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type T = Props

    let props =
        { Props.Size = Size.Unset
          Props.HTMLProps = [] }

    let private size =
        function
        | Size.Small -> "input-sm"
        | Size.Large -> "input-lg"
        | Size.Unset -> ""

    let ƒ (input: T) =
        input.HTMLProps
        |> addProps
            [ ClassName "form-input"
              ClassName <| size input.Size ]
        |> R.input

    let render = ƒ

[<RequireQualifiedAccess>]
module IconInput =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Position =
    | Left
    | Right

    [<RequireQualifiedAccess>]
    type Props =
        { Position: Position
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type Children =
        { Input: Input.T
          Icon: Icon.T }

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.Position = Position.Left
          Props.HTMLProps = [] }

    let private position =
        function
        | Position.Left -> "has-icon-left"
        | Position.Right -> "has-icon-right"

    let build (iconInput: T) =
        let props, children = iconInput
        let containerClasses =
            [ position props.Position ]
            |> String.concat " "
        let icon =
            { children.Icon with
                HTMLProps = children.Icon.HTMLProps
                |> addProp (ClassName "form-icon") }
        R.div [ClassName containerClasses]
            [ Input.ƒ children.Input
              Icon.ƒ icon ]

    let ƒ = build

[<RequireQualifiedAccess>]
module InputGroup =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    module GroupButton =

        [<RequireQualifiedAccess>]
        type T = Button.T

        let ƒ (groupButton: T) =
            let props, children = groupButton
            Button.ƒ
                ({ props with
                     HTMLProps =
                       props.HTMLProps
                       |> addProp (ClassName "input-group-btn") },
                  children)

    [<RequireQualifiedAccess>]
    type AddonRight<'Button> =
    | Button of 'Button
    | Unset

    [<RequireQualifiedAccess>]
    type AddonLeft =
    | Text of string
    | Unset

    [<RequireQualifiedAccess>]
    type Props<'Button> =
        { AddonRight: AddonRight<'Button>
          AddonLeft: AddonLeft
          Inline: bool
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type Child<'Input, 'Select> =
        | Input of 'Input
        | Select of 'Select

    [<RequireQualifiedAccess>]
    type Children<'Input, 'Select> =
        Child<'Input, 'Select> list

    [<RequireQualifiedAccess>]
    type T<'Input, 'Select, 'Button> =
        Props<'Button> * Children<'Input, 'Select>

    let props =
        { Props.AddonRight = AddonRight.Unset
          Props.AddonLeft = AddonLeft.Unset
          Props.Inline = false
          Props.HTMLProps = [] }

    let private button buttonƒ =
        function
        | AddonRight.Button button ->
            buttonƒ button
            |> Some
        | AddonRight.Unset -> None

    let private text =
        function
        | AddonLeft.Text text ->
            R.span
                [ ClassName "input-group-addon" ]
                [ R.str text ]
            |> Some
        | AddonLeft.Unset -> None

    let private groupInline =
        function
        | true -> "input-inline"
        | false -> ""
        >> ClassName

    let build
        inputƒ
        selectƒ
        buttonƒ
        (inputGroup: T<'Input, 'Select, 'Button>) =
        let props, children = inputGroup
        let containerProps =
            props.HTMLProps
            |> addProps
                [ ClassName "input-group"
                  groupInline props.Inline ]
        R.div containerProps
            [ text props.AddonLeft |> R.ofOption
              R.fragment
                []
                (Seq.map
                    (function
                     | Child.Input input -> inputƒ input
                     | Child.Select select -> selectƒ select)
                     children)
              button buttonƒ props.AddonRight |> R.ofOption ]

    let ƒ = build Input.ƒ Select.ƒ GroupButton.ƒ