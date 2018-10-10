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

        let children =
            { Children.Icon =
                { Icon.props with
                    Kind = Icon.Kind.ArrowRight }
              Children.Text = "" }

        let build (header: T) =
            let iconProps =
                { header.Icon with
                    HTMLProps = header.Icon.HTMLProps
                    |> addProp (ClassName "mr-1") }
            R.summary
                [ ClassName "accordion-header" ]
                [ Icon.ƒ iconProps
                  R.RawText "\n"
                  R.str header.Text ]

        let ƒ = build

    module Body =

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Children

        let private renderItem content =
            R.li
                [ ClassName "menu-item" ]
                [ content ]

        let build (body: T) =
            R.div
                [ ClassName "accordion-body" ]
                [ R.ul
                    [ ClassName "menu menu-nav"] 
                    ( List.map renderItem body ) ]

        let ƒ = build

    module Item =

        [<RequireQualifiedAccess>]
        type Children<'Header, 'Body> =
            { Header: 'Header
              Body: 'Body }

        [<RequireQualifiedAccess>]
        type T<'Header, 'Body> = Children<'Header, 'Body>

        let build headerƒ bodyƒ (item: T<'Header, 'Body>) =
            R.details
                [ ClassName "accordion" ]
                [ headerƒ item.Header
                  bodyƒ item.Body ]

        let ƒ = build Header.ƒ Body.ƒ

    [<RequireQualifiedAccess>]
    type Props =
        { CustomIcon: Icon.T
          HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children<'Item> = 'Item list

    [<RequireQualifiedAccess>]
    type T<'Item> = Props * Children<'Item>
      
    let props =
        { Props.CustomIcon =
            { Icon.props with
                Kind = Icon.Kind.ArrowRight }
          Props.HTMLProps = [] }

    let build itemƒ (accordion: T<'Item>) =
        let props, children = accordion
        let iconProps =
            { props.CustomIcon with
                HTMLProps = props.CustomIcon.HTMLProps
                |> addProp (ClassName "mr-1") }
        R.div []
        <| Seq.map itemƒ children

    let ƒ = build Item.ƒ
