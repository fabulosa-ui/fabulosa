namespace Fabulosa

[<RequireQualifiedAccess>]
module Form =

    [<RequireQualifiedAccess>]
    module Group =

        open Fabulosa.Extensions
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
            props.HTMLProps
            |> addProp (ClassName "form-group")
            |> R.div

        let render = ƒ