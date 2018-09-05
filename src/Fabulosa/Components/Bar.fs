namespace Fabulosa

[<RequireQualifiedAccess>]
module Bar =

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props = {
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.HTMLProps = []
    }

    let ƒ (props: Props) =
        R.div [ClassName "bar"]

    [<RequireQualifiedAccess>]
    module Item =

        [<RequireQualifiedAccess>]
        type Props = {
            HTMLProps: IHTMLProp list
        }

        let defaults = {
            Props.HTMLProps = []
        }

        let ƒ (props: Props) =
            R.div [ClassName "bar-item"] []