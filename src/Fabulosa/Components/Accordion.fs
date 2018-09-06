namespace Fabulosa

module Accordion =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props = {
        CustomIcon: Icon.Props
        HTMLProps: IHTMLProp list
    }

    [<RequireQualifiedAccess>]
    type Child = {
        Header: string
        Content: ReactElement list
    }

    let defaults = {
        Props.CustomIcon =
            { Icon.defaults with
                Kind = Icon.Kind.ArrowRight }
        Props.HTMLProps = []
    }

    let private renderItem content =
        R.li [ClassName "menu-item"] [content]

    let private renderHeader icon text =
        R.summary [ClassName "accordion-header"] [
            Icon.ƒ icon []
            R.RawText "\n"
            R.str text
        ]

    let private renderBody (child: Child) =
        let items = child.Content |> List.map renderItem
        R.div [ClassName "accordion-body"]
            [ R.ul [ClassName "menu menu-nav"] items ]

    let private renderChild icon (child: Child) =
        R.details [ClassName "accordion"]
            [ renderHeader icon child.Header
              renderBody child ]

    let private renderChildren children icon =
        children
        |> List.map (renderChild icon)

    let ƒ (props: Props) children =
        let iconProps =
            { props.CustomIcon with
                HTMLProps = props.CustomIcon.HTMLProps
                |> addProp (ClassName "mr-1") }
        R.div [] (renderChildren children iconProps)
        