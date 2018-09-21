namespace Fabulosa

[<RequireQualifiedAccess>]
module Form =

    [<RequireQualifiedAccess>]
    module Group =

        open Fable.Import.React
        open Fabulosa.Extensions
        module R = Fable.Helpers.React
        open R.Props

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: IHTMLProp list }

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let defaults =
            { Props.HTMLProps = [] }

        let ƒ (group: T) =
            let props, children = group
            props.HTMLProps
            |> addProp (ClassName "form-group")
            |> R.div <| children

        let render = ƒ