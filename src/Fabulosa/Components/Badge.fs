namespace Fabulosa

module Badge =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type HTMLProps = IHTMLProp list

    [<RequireQualifiedAccess>]
    type Children = ReactElement list

    [<RequireQualifiedAccess>]
    type Kind =
    | Avatar of Avatar.Props
    | Button of Button.Props * Children
    | Div of HTMLProps * Children
    | Span of HTMLProps * Children

    [<RequireQualifiedAccess>]
    type Badge = int

    [<RequireQualifiedAccess>]
    type Props =
        { Badge: Badge
          Kind: Kind }

    [<RequireQualifiedAccess>]
    type T = Props

    let private combine htmlProps badge =
        ( htmlProps |> addProp (ClassName "badge") )
        @ [Data ("badge", badge)]

    let private create kind badge =
        match kind with
        | Kind.Avatar props ->
            Avatar.ƒ
                { props with
                    HTMLProps = combine props.HTMLProps badge }
        | Kind.Button (props, children) ->
            Button.ƒ
                ( { props with
                      HTMLProps = combine props.HTMLProps badge },
                  children )
        | Kind.Div (props, children) ->
            R.div
                (combine props badge)
                children
        | Kind.Span (props, children) ->
            R.span
                (combine props badge)
                children

    let defaults =
        { Props.Badge = 0
          Props.Kind = Kind.Div ([], []) }

    let ƒ (badge: T) =
        create badge.Kind badge.Badge