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

        let defaults =
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

        let ƒ (item: T) =
            let props, children = item
            props.HTMLProps
            @ tooltipData (props.Tooltip, props.Value)
            @ style props.Value
            |> addProps
                [ ClassName "bar-item"
                  tooltip props.Tooltip ]
            |> R.div <| children

    [<RequireQualifiedAccess>]
    type Small = bool

    [<RequireQualifiedAccess>]
    type Props =
        { Small: Small
          HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children = Item.T list

    [<RequireQualifiedAccess>]
    type T = Props * Children
    
    let defaults =
        { Props.Small = false
          Props.HTMLProps = [] }

    let private small =
        function
        | true -> "bar-sm"
        | false -> ""
        >> ClassName

    let ƒ (bar: T) =
        let props, children = bar
        props.HTMLProps
        |> addProps
            [ ClassName "bar"
              small props.Small ]
        |> R.div
        <| Seq.map Item.ƒ children

    [<RequireQualifiedAccess>]
    module Slider =

        let defaults = defaults

        let private item (child: Item.T) =
            let props, children = child
            Item.ƒ
                ( props,
                  [ Button.ƒ
                      ( { Button.defaults with
                            HTMLProps = [ClassName "bar-slider-btn"] }, [] ) ] )

        let ƒ (slider: T) =
            let props, children = slider
            props.HTMLProps
            |> addProps
                [ ClassName "bar bar-slider"
                  small props.Small ]
            |> R.div
            <| Seq.map item children