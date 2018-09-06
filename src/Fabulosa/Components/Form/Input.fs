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
    type Props = {
        Size: Size
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.Size = Size.Unset
        Props.HTMLProps = []
    }

    let size =
        function
        | Size.Small -> "input-sm"
        | Size.Large -> "input-lg"
        | Size.Unset -> ""

    let ƒ (props: Props) =
        props.HTMLProps
        |> addProps
            [ ClassName "form-input"
              ClassName <| size props.Size ]
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
    type Props = {
        Position: Position
        InputProps: Input.Props
        IconProps: Icon.Props
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.Position = Position.Left
        Props.InputProps = Input.defaults
        Props.IconProps = Icon.defaults
        Props.HTMLProps = []
    }

    let position =
        function
        | Position.Left -> "has-icon-left"
        | Position.Right -> "has-icon-right"

    let ƒ (props: Props) =
        let containerClasses =
            [ position props.Position ]
            |> String.concat " "
        let iconProps =
            { props.IconProps with
                HTMLProps = props.IconProps.HTMLProps
                |> addProp (ClassName "form-icon") }
        R.div [ClassName containerClasses]
            [ Input.ƒ props.InputProps
              Icon.ƒ iconProps [] ]

    let render = ƒ

[<RequireQualifiedAccess>]
module InputGroup =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type AddonRight =
    | Button of Button.Props * ReactElement list
    | Unset

    [<RequireQualifiedAccess>]
    type AddonLeft =
    | Text of string
    | Unset

    [<RequireQualifiedAccess>]
    type Props = {
        AddonRight: AddonRight
        AddonLeft: AddonLeft
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.AddonRight = AddonRight.Unset
        Props.AddonLeft = AddonLeft.Unset
        Props.HTMLProps = []
    }

    let button =
        function
        | AddonRight.Button (props, children) ->
            Button.ƒ
                { props with
                    HTMLProps =
                        props.HTMLProps
                        |> addProp (ClassName "input-group-btn") }
                children
            |> Some
        | AddonRight.Unset -> None

    let text =
        function
        | AddonLeft.Text text ->
            R.span
                [ClassName "input-group-addon"]
                [R.str text]
            |> Some
        | AddonLeft.Unset -> None

    let ƒ (props: Props) children =
        let containerProps =
            props.HTMLProps
            |> addProp (ClassName "input-group") 
        R.div containerProps
            [ text props.AddonLeft |> R.ofOption
              R.fragment [] children
              button props.AddonRight |> R.ofOption ]

    let render = ƒ