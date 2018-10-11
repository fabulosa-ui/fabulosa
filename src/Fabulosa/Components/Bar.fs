namespace Fabulosa

[<RequireQualifiedAccess>]
module Bar =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    module Item =

        [<RequireQualifiedAccess>]
        type Value = int

        [<RequireQualifiedAccess>]
        type Tooltip = bool

        [<RequireQualifiedAccess>]
        type Color =
        | Primary
        | Secondary
        | Dark
        | Gray
        | Success
        | Warning
        | Error
        | Unset

        [<RequireQualifiedAccess>]
        type Props =
            { Value: Value
              Tooltip: Tooltip
              Color: Color
              HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.Value = 0
              Props.Tooltip = false
              Props.Color = Color.Unset
              Props.HTMLProps = [] }

        let private toPercent =
            string >> (+) >> (|>) "%"

        let private tooltip =
            function
            | true -> "tooltip"
            | false -> ""
            >> ClassName

        let private tooltipData =
            function
            | true, value ->
                [Data ("tooltip", toPercent value)]
            | false, _ -> []
            >> List.cast<IHTMLProp>

        let private style value =
            let width = R.Props.CSSProp.Width (toPercent value)
            let style = Fable.Helpers.React.Props.Style [width]
            [style]
            |> List.cast<IHTMLProp>

        let build (item: T) =
            let props, children = item
            props.HTMLProps
            @ tooltipData (props.Tooltip, props.Value)
            @ style props.Value
            |> addProps
                [ ClassName "bar-item"
                  tooltip props.Tooltip ]
            |> R.div <| children

        let ƒ = build

    [<RequireQualifiedAccess>]
    type Small = bool

    [<RequireQualifiedAccess>]
    type Props =
        { Small: Small
          HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children<'Item> = 'Item list

    [<RequireQualifiedAccess>]
    type T<'Item> = Props * Children<'Item>
    
    let props =
        { Props.Small = false
          Props.HTMLProps = [] }

    let private small =
        function
        | true -> "bar-sm"
        | false -> ""
        >> ClassName

    let build itemƒ (bar: T<'Item>) =
        let props, children = bar
        props.HTMLProps
        |> addProps
            [ ClassName "bar"
              small props.Small ]
        |> R.div
        <| Seq.map itemƒ children

    let ƒ = build Item.ƒ

    [<RequireQualifiedAccess>]
    module Slider =

        let props = props

        let build (slider: T<Item.T>) =
            let props, children = slider
            props.HTMLProps
            |> addProps
                [ ClassName "bar bar-slider"
                  small props.Small ]
            |> R.div
            <| Seq.map
                (fun item ->
                    let props, children = item
                    Item.ƒ
                        (props,
                         [ Button.ƒ
                             ({ Button.props with
                                  HTMLProps = [ ClassName "bar-slider-btn" ] }, []) ]))
                children

        let ƒ = build