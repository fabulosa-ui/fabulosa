namespace Fabulosa

module Accordion =

    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props
    open ClassNames

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
        Props.CustomIcon = {
            Icon.defaults with
                Kind = Icon.Kind.ArrowRight
        }
        Props.HTMLProps = []
    }

    let renderItem content =
        R.li [ClassName "menu-item"] [content]

    let renderHeader icon text =
        R.summary [ClassName "accordion-header"] [
            Icon.ƒ icon []
            R.RawText "\n"
            R.str text
        ]

    let renderChildren children icon =
        children |> List.map (fun (child: Child) ->
            let items = child.Content |> List.map renderItem
            R.details [ClassName "accordion"] [
                renderHeader icon child.Header
                R.div [ClassName "accordion-body"] [
                    R.ul [ClassName "menu menu-nav"] items
                ]
            ]
        )

    let ƒ (props: Props) children =
        let iconProps =
            { props.CustomIcon with
                HTMLProps = combineProps ["mr-1"] props.CustomIcon.HTMLProps }
        R.div [] (renderChildren children iconProps)
        