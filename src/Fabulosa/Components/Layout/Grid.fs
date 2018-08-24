namespace Fabulosa

[<RequireQualifiedAccess>]
module Grid =

    module R = Fable.Helpers.React
    open R.Props
    open ClassNames

    type Props = {
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        HTMLProps = []
    }

    let ƒ props =
        props.HTMLProps
        |> combineProps ["container"]
        |> R.div

    let render = ƒ

    [<RequireQualifiedAccess>]
    module Row =

        [<RequireQualifiedAccess>]
        type Gapless = bool

        [<RequireQualifiedAccess>]
        type OneLine = bool

        [<RequireQualifiedAccess>]
        type Props = {
            Gapless: Gapless
            OneLine: OneLine
            HTMLProps: IHTMLProp list
        }

        let defaults = {
            Props.Gapless = false
            Props.OneLine = false
            Props.HTMLProps = []
        }

        let gapless =
            function
            | true -> "col-gapless"
            | false -> ""

        let oneLine =
            function
            | true -> "col-oneline"
            | false -> ""

        let ƒ (props: Props) =
            props.HTMLProps
            |> combineProps [
                "columns"
                gapless props.Gapless
                oneLine props.OneLine ]
            |> R.div

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Column =

        [<RequireQualifiedAccess>]
        type Kind =
        | MLAuto
        | MRAuto
        | MXAuto
        | Unset

        [<RequireQualifiedAccess>]
        type ColSize = int

        [<RequireQualifiedAccess>]
        type XSSize = int

        [<RequireQualifiedAccess>]
        type SMSize = ColSize

        [<RequireQualifiedAccess>]
        type MDSize = ColSize

        [<RequireQualifiedAccess>]
        type LGSize = ColSize

        [<RequireQualifiedAccess>]
        type XLSize = ColSize

        [<RequireQualifiedAccess>]
        type Props = {
            Kind: Kind
            Size: ColSize
            XSSize: ColSize
            SMSize: ColSize
            MDSize: ColSize
            LGSize: ColSize
            XLSize: ColSize
            HTMLProps: IHTMLProp list
        }

        let kind =
            function
            | Kind.MLAuto -> "col-ml-auto"
            | Kind.MRAuto -> "col-mr-auto"
            | Kind.MXAuto -> "col-mx-auto"
            | Kind.Unset -> ""

        let size: ColSize -> string =
            function
            | n -> "col-" + string n

        let xsSize: XSSize -> string =
            function
            | n -> "col-xs-" + string n

        let smSize: SMSize -> string =
            function
            | n -> "col-sm-" + string n

        let mdSize: MDSize -> string =
            function
            | n -> "col-md-" + string n

        let lgSize: LGSize -> string =
            function
            | n -> "col-lg-" + string n

        let xlSize: LGSize -> string =
             function
             | n -> "col-lg-" + string n

        let defaults = {
            Props.Kind = Kind.Unset
            Props.Size = 12
            Props.XSSize = 0
            Props.SMSize = 0
            Props.MDSize = 0
            Props.LGSize = 0
            Props.XLSize = 0
            Props.HTMLProps = []
        }

        let ƒ (props: Props) =
            props.HTMLProps
            |> combineProps [
                "column"
                kind props.Kind
                size props.Size
                xsSize props.XSSize
                smSize props.SMSize
                mdSize props.MDSize
                lgSize props.LGSize
                xlSize props.XLSize ]
            |> R.div

        let render = ƒ