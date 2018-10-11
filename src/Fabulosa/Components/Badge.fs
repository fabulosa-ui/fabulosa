namespace Fabulosa

[<RequireQualifiedAccess>]
module Badge =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    let private combine htmlProps (badge: int) =
        (htmlProps
         |> addProp (ClassName "badge"))
        @ [ Data ("badge", badge) ]

    [<RequireQualifiedAccess>]
    module BadgeAvatar =

        type T = Avatar.T * int
        
        let build (avatar: T) =
            let props, children = avatar
            Avatar.ƒ
                { props with
                    HTMLProps = combine props.HTMLProps children }

        let ƒ = build

    [<RequireQualifiedAccess>]
    module BadgeButton =

        type T = Button.T * int

        let build (button: T) =
            let buttonT, badge = button
            let props, children = buttonT
            Button.ƒ
                ({ props with
                      HTMLProps = combine props.HTMLProps badge },
                  children)

        let ƒ = build
    
    [<RequireQualifiedAccess>]
    type Badge = int

    [<RequireQualifiedAccess>]
    type Props =
        { Badge: Badge }

    [<RequireQualifiedAccess>]
    type Child<'Avatar, 'Button> =
        | Avatar of 'Avatar
        | Button of 'Button
        | Anchor of HTMLProps * ReactElement list
        | Div of HTMLProps * ReactElement list
        | Span of HTMLProps * ReactElement list
        
    [<RequireQualifiedAccess>]
    type T<'Avatar, 'Button> =
        Props * Child<'Avatar, 'Button>
       
    let props =
        { Props.Badge = 0 }

    let children =
        Child.Div ([], [])

    let build avatarƒ buttonƒ (badge: T<'Avatar, 'Button>) =
        let props, children = badge
        match children with
        | Child.Avatar avatar ->
            avatarƒ (avatar, props.Badge)
        | Child.Button button ->
            buttonƒ (button, props.Badge)
        | Child.Anchor (anchorProps, children) ->
            R.a
                (combine anchorProps props.Badge)
                children
        | Child.Div (divProps, children) ->
            R.div
                (combine divProps props.Badge)
                children
        | Child.Span (spanProps, children) ->
            R.span
                (combine spanProps props.Badge)
                children

    let ƒ = build BadgeAvatar.ƒ BadgeButton.ƒ