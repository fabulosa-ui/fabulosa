namespace Fabulosa

module Accordion =

    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type AccordionElement = string * string

    [<RequireQualifiedAccess>]
    type Props = {
        HTMLProps: IHTMLProp list
    }

    [<RequireQualifiedAccess>]
    type Child = {
        Header: ReactElement list
        Content: ReactElement list
    }

    [<RequireQualifiedAccess>]
    type Children = Child list

    let defaults = {
        Props.HTMLProps = []
    }

    let ƒ (props: Props) (children: Children) =
        let elements = seq {
            for child in children ->
                R.details [ClassName "accordion"]
                    [ R.summary [ClassName "accordion-header"] child.Header
                      R.div [ClassName "accordion-body"] child.Content ] }
        R.div [] elements
        