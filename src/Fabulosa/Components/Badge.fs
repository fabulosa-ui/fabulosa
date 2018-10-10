namespace Fabulosa

module Badge =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props
    
    [<RequireQualifiedAccess>]
    type Badge = int

    [<RequireQualifiedAccess>]
    type Props =
        { Badge: Badge }

    [<RequireQualifiedAccess>]
    type Child =
    | Avatar of Avatar.T
    | Button of Button.T
    | Anchor of HTMLProps * ReactElement list
    | Div of HTMLProps * ReactElement list
    | Span of HTMLProps * ReactElement list
        
    [<RequireQualifiedAccess>]
    type T = Props * Child

    let private combine htmlProps badge =
        (htmlProps
         |> addProp (ClassName "badge"))
        @ [ Data ("badge", badge) ]

    let private renderChildren child badge =
        match child with
        | Child.Avatar props ->
            Avatar.ƒ
                { props with
                    HTMLProps = combine props.HTMLProps badge }
        | Child.Button (props, children) ->
            Button.ƒ
                ({ props with
                      HTMLProps = combine props.HTMLProps badge },
                  children)
        | Child.Anchor (props, children) ->
            R.a
                (combine props badge)
                children
        | Child.Div (props, children) ->
            R.div
                (combine props badge)
                children
        | Child.Span (props, children) ->
            R.span
                (combine props badge)
                children

    let props =
        { Props.Badge = 0 }

    let children =
        Child.Div ([], [])

    let ƒ (badge: T) =
        let props, children = badge
        renderChildren children props.Badge