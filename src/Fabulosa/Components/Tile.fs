namespace Fabulosa

[<RequireQualifiedAccess>]
module Tile =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    module TileIcon =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }
            
        [<RequireQualifiedAccess>]
        type T<'Icon> = Props * 'Icon

        let props =
            { Props.HTMLProps = [] }

        let build<'Icon> iconƒ (icon: T<'Icon>) =
            let props, children = icon
            props.HTMLProps
            |> addProp (ClassName "tile-icon")
            |> R.div <| [ iconƒ children ]

        let ƒ = build Icon.ƒ

    [<RequireQualifiedAccess>]
    module Content =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }

        type Children =
            { Title: string
              SubTitle: string }
            
        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = [] }

        let children =
            { Children.Title = ""
              Children.SubTitle = "" }

        let build (content: T) =
            let props, children = content
            props.HTMLProps
            |> addProp (ClassName "tile-content")
            |> R.div
            <| [ R.p
                   [ ClassName "tile-title" ]
                   [ R.str children.Title ]
                 R.p
                   [ ClassName "tile-subtitle text-gray" ]
                   [ R.str children.SubTitle ] ]

        let ƒ = build

    [<RequireQualifiedAccess>]
    module Action =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }

        type Children = ReactElement list
            
        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = [] }

        let build (action: T) =
            let props, children = action
            props.HTMLProps
            |> addProp (ClassName "tile-action")
            |> R.div <| children

        let ƒ = build

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          Compact: bool }

    [<RequireQualifiedAccess>]
    type Children<'Icon, 'Content, 'Action> =
        { Icon: 'Icon option
          Content: 'Content
          Action: 'Action }

    [<RequireQualifiedAccess>]
    type T<'Icon, 'Content, 'Action> =
        Props * Children<'Icon, 'Content, 'Action>

    let props =
        { Props.HTMLProps = []
          Props.Compact = false }

    let children =
        { Children.Icon = None
          Children.Content = (Content.props, Content.children)
          Children.Action = (Action.props, [])}

    let private compact =
        function
        | true -> "tile-centered"
        | false -> ""
        >> ClassName

    let private icon iconƒ =
        function
        | Some props -> iconƒ props
        | None -> R.ofOption None

    let build
        iconƒ
        contentƒ
        actionƒ
        (tile: T<'Icon, 'Content, 'Action>) =
        let pops, children = tile
        props.HTMLProps
        |> addProps 
            [ ClassName "tile"
              compact props.Compact ]
        |> R.div
        <| [ icon iconƒ children.Icon
             contentƒ children.Content
             actionƒ children.Action ]

    let ƒ = build TileIcon.ƒ Content.ƒ Action.ƒ