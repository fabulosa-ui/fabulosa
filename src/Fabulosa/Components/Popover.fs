namespace Fabulosa

module Popover =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    module Trigger =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (trigger: T) =
            R.fragment [] trigger

    [<RequireQualifiedAccess>]
    module Content =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (content: T) =
            R.div [ClassName "popover-container"] content

    [<RequireQualifiedAccess>]
    type Position =
        | Top
        | Right
        | Bottom
        | Left

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          Position: Position }

    [<RequireQualifiedAccess>]
    type Children<'Trigger, 'Content> =
        { Trigger: 'Trigger
          Content: 'Content }

    [<RequireQualifiedAccess>]
    type T<'Trigger, 'Content> =
        Props * Children<'Trigger, 'Content>

    let private position =
        function
        | Position.Top -> ""
        | Position.Right -> "popover-right"
        | Position.Bottom -> "popover-bottom"
        | Position.Left -> "popover-left"
        >> ClassName

    let props =
        { Props.HTMLProps = []
          Props.Position = Position.Top }

    let build triggerƒ contentƒ (popover: T<'Trigger, 'Content>) =
        let props, children = popover
        props.HTMLProps
        |> addProps
            [ ClassName "popover"
              position props.Position ]
        |> R.div
        <| [ triggerƒ children.Trigger
             contentƒ children.Content ] 

    let ƒ = build Trigger.ƒ Content.ƒ