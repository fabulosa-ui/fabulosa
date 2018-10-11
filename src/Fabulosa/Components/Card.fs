namespace Fabulosa

[<RequireQualifiedAccess>]
module Card =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    module Header =
        
        [<RequireQualifiedAccess>]
        type T =
            { Title: string
              SubTitle: string }

        let props =
            { T.Title = ""
              T.SubTitle = "" }

        let ƒ (header: T) =
            R.div
                [ ClassName "card-header" ]
                [ R.div
                    [ ClassName "card-title h5" ]
                    [ R.str header.Title ]
                  R.div
                    [ ClassName "card-subtitle text-gray" ]
                    [ R.str header.SubTitle ] ]

    [<RequireQualifiedAccess>]
    module Body =

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Children

        let props = []

        let ƒ (body: T) =
            if not (List.isEmpty body) then
                R.div [ClassName "card-body"] body
            else
                R.ofOption None

    [<RequireQualifiedAccess>]
    module Footer =

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Children

        let props = []

        let ƒ (footer: T) =
            if not (List.isEmpty footer) then
                R.div [ClassName "card-footer"] footer
            else
                R.ofOption None

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children<'Header, 'Body, 'Footer> =
        { Image: Media.Image.Props
          Header: 'Header
          Body: 'Body
          Footer: 'Footer }

    [<RequireQualifiedAccess>]
    type T<'Header, 'Body, 'Footer> =
        Props * Children<'Header, 'Body, 'Footer>

    let props =
        { Props.HTMLProps = [] }

    let children =
        { Children.Header = Header.props
          Children.Body = Body.props
          Children.Footer = Footer.props
          Children.Image = Media.Image.props }

    let build headerƒ bodyƒ footerƒ (card: T<'Header, 'Body, 'Footer>) =
        let props, children = card
        props.HTMLProps
        |> addProp (ClassName "card")
        |> R.div <|
        [ headerƒ children.Header
          R.div [ ClassName "card-image" ] [ Media.Image.ƒ children.Image ]
          bodyƒ children.Body
          footerƒ children.Footer ]

    let ƒ = build Header.ƒ Body.ƒ Footer.ƒ