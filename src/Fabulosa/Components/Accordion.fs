namespace Fabulosa

module Accordion =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    module Header =

        [<RequireQualifiedAccess>]
        type Children =
            { Icon: Icon.T
              Text: string }

        [<RequireQualifiedAccess>]
        type T = Children

        let ƒ (header: T) =
            R.summary
                [ ClassName "accordion-header" ]
                [ Icon.ƒ header.Icon
                  R.RawText "\n"
                  R.str header.Text ]

    module Body =

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Children

        let private renderItem content =
            R.li
                [ ClassName "menu-item" ]
                [ content ]

        let ƒ (body: T) =
            R.div
                [ ClassName "accordion-body" ]
                [ R.ul
                    [ ClassName "menu menu-nav"] 
                    ( List.map renderItem body ) ]

    module Item =

        [<RequireQualifiedAccess>]
        type Children =
            { Header: Header.T
              Body: Body.T }

        [<RequireQualifiedAccess>]
        type T = Children

        let ƒ (item: T) =
            R.details
                [ ClassName "accordion" ]
                [ Header.ƒ item.Header
                  Body.ƒ item.Body ]

    [<RequireQualifiedAccess>]
    type Props =
        { CustomIcon: Icon.Props
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type Child =
        { Header: string
          Body: ReactElement list }

    [<RequireQualifiedAccess>]
    type Children = Child list

    [<RequireQualifiedAccess>]
    type T = Props * Children    
    let defaults =
        { Props.CustomIcon =
            { Icon.defaults with
                Kind = Icon.Kind.ArrowRight }
          Props.HTMLProps = [] }

    let ƒ (accordion: T) =
        let props, children = accordion
        let iconProps =
            { props.CustomIcon with
                HTMLProps = props.CustomIcon.HTMLProps
                |> addProp (ClassName "mr-1") }
        R.div []
        <| Seq.map
            (fun (child: Child) ->
                Item.ƒ
                    { Header =
                        { Icon = iconProps
                          Text = child.Header }
                      Body = child.Body } )
            children
        