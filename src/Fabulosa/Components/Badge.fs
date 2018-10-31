namespace Fabulosa

module Badge =

    open Fabulosa.Extensions
    open Fabulosa.Button
    open Fabulosa.Avatar
    open Fable.Import.React
    module R = Fable.Helpers.React
    module P = R.Props

    let private combine props badge =
        P.Unmerged props
        |> P.addProps
            [ P.ClassName "badge"
              P.Data ("badge", badge) ]
        |> P.merge

    type private Element = P.HTMLProps * ReactElement list
    
    type BadgeChildren =
        | Avatar of Avatar
        | Button of Button
        | Anchor of Element
        | Div of Element
        | Span of Element

    type Badge =
        P.HTMLProps * FabulosaValue * BadgeChildren

    let badge ((optional, (Value value), children): Badge) =
        match children with
        | Avatar (opt, children) ->
            avatar (combine opt value, children)
        | Button (opt, req) ->
            button (combine opt value, req)
        | Anchor (anchorProps, children) ->
            R.a (combine anchorProps value) children
        | Div (divProps, children) ->
            R.div (combine divProps value) children
        | Span (spanProps, children) ->
            R.span (combine spanProps value) children