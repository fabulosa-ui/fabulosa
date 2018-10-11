namespace Fabulosa

[<RequireQualifiedAccess>]
module Empty =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    module EmptyIcon =
       
        let build (icon: Icon.T) =
            R.div
                [ ClassName "empty-icon" ]
                [ Icon.ƒ { icon with Size = Icon.Size.X3 } ]

        let ƒ = build

    [<RequireQualifiedAccess>]
    module Title =

        [<RequireQualifiedAccess>]
        type T = string

        let children: T = ""

        let ƒ (title: T) =
            R.p
                [ ClassName "empty-title h5" ]
                [ R.str title ]

    [<RequireQualifiedAccess>]
    module SubTitle =

        [<RequireQualifiedAccess>]
        type T = string

        let children: T = ""

        let ƒ (subTitle: T) =
            R.p
                [ ClassName "empty-subtitle" ]
                [ R.str subTitle ]

    [<RequireQualifiedAccess>]
    module Action =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let children: T = []

        let ƒ (action: T) =
            R.div
                [ ClassName "empty-action" ]
                action

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children<'Icon, 'Title, 'SubTitle, 'Action> =
        { Icon: 'Icon
          Title: 'Title
          SubTitle: 'SubTitle
          Action: 'Action }

    [<RequireQualifiedAccess>]
    type T<'Icon, 'Title, 'SubTitle, 'Action> =
        Props * Children<'Icon, 'Title, 'SubTitle, 'Action>

    let props =
        { Props.HTMLProps = [] }

    let children =
        { Children.Icon = Icon.props
          Children.Title = Title.children
          Children.SubTitle = SubTitle.children
          Children.Action = Action.children }

    let build
        emptyIconƒ
        titleƒ
        subTitleƒ
        actionƒ
        (empty: T<'Icon, 'Title, 'SubTitle, 'Action>) =
        let prps,children = empty
        props.HTMLProps
        |> addProp (ClassName "empty")
        |> R.div <|
        [ emptyIconƒ children.Icon
          titleƒ children.Title
          subTitleƒ children.SubTitle
          actionƒ children.Action ]

    let ƒ = build EmptyIcon.ƒ Title.ƒ SubTitle.ƒ Action.ƒ