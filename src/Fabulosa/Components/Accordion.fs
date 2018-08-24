namespace Fabulosa

module Accordion =

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

    [<RequireQualifiedAccess>]
    type Children = Child list

    let defaults = {
        Props.CustomIcon = {
            Icon.defaults with
                Kind = Icon.Kind.ArrowRight
                HTMLProps = [ClassName "mr-1"]
        }
        Props.HTMLProps = []
    }

    let elements (children: Children) (icon: Icon.Props) =
        seq {
            for child in children ->
                let content =
                    List.map
                        (fun content -> R.li [ClassName "menu-item"] [content])
                        child.Content
                R.details [ClassName "accordion"] [
                    R.summary [ClassName "accordion-header"] [
                        Icon.ƒ icon []
                        R.RawText "\n"
                        R.str child.Header
                    ]
                    R.div [ClassName "accordion-body"] [
                        R.ul [ClassName "menu menu-nav"] content
                    ]
                ]
        }

    let ƒ (props: Props) (children: Children) =
        R.div [] (elements children props.CustomIcon)
        