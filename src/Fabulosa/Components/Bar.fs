namespace Fabulosa

module Bar =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    module P = R.Props

    type Color =
        | Primary
        | Secondary
        | Dark
        | Gray
        | Success
        | Warning
        | Error
        | Unset

    type BarItemOptional =
        | Tooltip
        | Color of Color
        interface P.IHTMLProp

    type private BarItem =
        P.HTMLProps * FabulosaValue

    let private toPercent =
        string >> (+) >> (|>) "%"

    let private tooltip value (prop: P.IHTMLProp) =
        match prop with
        | :? BarItemOptional as opt ->
            match opt with
            | Tooltip ->
                P.Unmerged []
                |> P.addProps
                    [ P.ClassName "tooltip"
                      P.Data ("tooltip", toPercent value) ]
                |> P.merge
            | _ -> []
        | _ -> []

    let private style value =
        let width = R.Props.CSSProp.Width (toPercent value)
        Fable.Helpers.React.Props.Style [width]
        :> P.IHTMLProp

    let barItem ((opt, (Value value)): BarItem) =
        P.Unmerged opt
        |> P.addProps
            (P.ClassName "bar-item" :> P.IHTMLProp
            :: style value
            :: (List.collect (tooltip value) opt))
        |> P.merge
        |> R.div <| []

    type BarOptional =
        | Small
        interface P.IHTMLProp

    type BarChild =
        Item of BarItem

    type private BarChildren =
        BarChild list

    type private Bar = P.HTMLProps * BarChildren

    let private small (prop: P.IHTMLProp) =
        match prop with
        | :? BarOptional as opt ->
            match opt with
            | Small -> "bar-sm"
            |> P.className
        | _ -> prop

    let bar ((opt, chi): Bar) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "bar")
        |> P.map small
        |> P.merge
        |> R.div
        <| Seq.map
            (fun (Item item) -> barItem item)
            chi
        
    //[<RequireQualifiedAccess>]
    //module Slider =

        //let props = props

        //let build (slider: T<Item.T>) =
        //    let props, children = slider
        //    props.HTMLProps
        //    |> addProps
        //        [ ClassName "bar bar-slider"
        //          small props.Small ]
        //    |> R.div
        //    <| Seq.map
        //        (fun item ->
        //            let props, children = item
        //            Item.ƒ
        //                (props,
        //                 [ button
        //                     ([ ClassName "bar-slider-btn" ], []) ]))
        //        children

        //let ƒ = build