namespace Fabulosa

[<RequireQualifiedAccess>]
module Bar =

    module R = Fable.Helpers.React
    open R.Props
    open ClassNames

    [<RequireQualifiedAccess>]
    type Props = {
        Small: bool
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.Small = false
        Props.HTMLProps = []
    }

    let small =
        function
        | true -> "bar-sm"
        | false -> ""

    let ƒ (props: Props) =
        props.HTMLProps
        |> addClasses
            ["bar"
             small props.Small]
        |> R.div

    [<RequireQualifiedAccess>]
    module Item =

        [<RequireQualifiedAccess>]
        type Props = {
            Value: int
            Tooltip: bool
            HTMLProps: IHTMLProp list
        }

        let defaults = {
            Props.Value = 0
            Props.Tooltip = false
            Props.HTMLProps = []
        }

        let private toPercent =
            string >> (+) >> (|>) "%"

        let private tooltip =
            function
            | true -> "tooltip"
            | false -> ""

        let private tooltipData =
            function
            | true, value ->
                [Data ("tooltip", toPercent value)]
            | false, _ -> []
            >> List.cast<IHTMLProp>        

        let private style value =
            [Style [Width (toPercent value)]]
            |> List.cast<IHTMLProp>
           
        let ƒ (props: Props) =
            props.HTMLProps
            @ tooltipData (props.Tooltip, props.Value)
            @ style props.Value
            |> addClasses
                ["bar-item"
                 tooltip props.Tooltip]
            |> R.div <| []