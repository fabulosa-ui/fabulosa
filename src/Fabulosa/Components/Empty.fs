namespace Fabulosa

[<RequireQualifiedAccess>]
module Empty =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children =
        { Icon: Icon.Props
          Title: string
          SubTitle: string
          Action: ReactElement seq }

    let defaults =
        { Props.HTMLProps = [] }

    let children =
        { Children.Icon = Icon.defaults
          Children.Title = ""
          Children.SubTitle = ""
          Children.Action = [] }

    let private icon props =
        R.div
            [ ClassName "empty-icon" ]
            [ Icon.ƒ { props with Size = Icon.Size.X3 } ]

    let private title text =
        R.p [ ClassName "empty-title h5" ] [ R.str text ]

    let private subTitle text =
        R.p [ ClassName "empty-subtitle" ] [ R.str text ]

    let private action elements =
        R.div [ ClassName "empty-action" ] elements

    let private renderChildren (children: Children) =
        [ icon children.Icon
          title children.Title
          subTitle children.SubTitle
          action children.Action ]

    let ƒ (props: Props) children =
        props.HTMLProps
        |> addProp (ClassName "empty")
        |> R.div <| renderChildren children