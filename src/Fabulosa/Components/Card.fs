namespace Fabulosa

[<RequireQualifiedAccess>]
module Card =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    module Header =
        
        [<RequireQualifiedAccess>]
        type T =
            { Title: string
              SubTitle: string }

        let defaults =
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

    module Body =

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Children

        let defaults = []

        let ƒ (body: T) =
            if not (List.isEmpty body) then
                R.div [ClassName "card-body"] body
            else
                R.ofOption None

    module Footer =

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Children

        let defaults = []

        let ƒ (footer: T) =
            if not (List.isEmpty footer) then
                R.div [ClassName "card-footer"] footer
            else
                R.ofOption None

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children =
        { Image: Media.Image.Props
          Header: Header.T
          Body: Body.T
          Footer: Footer.T }

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let defaults =
        { Props.HTMLProps = [] }

    let children =
        { Children.Header = Header.defaults
          Children.Body = Body.defaults
          Children.Footer = Footer.defaults
          Children.Image = Media.Image.defaults }

    let ƒ (card: T) =
        let props, children = card
        props.HTMLProps
        |> addProp (ClassName "card")
        |> R.div <|
        [ Header.ƒ children.Header
          R.div [ ClassName "card-image" ] [ Media.Image.ƒ children.Image ]
          Body.ƒ children.Body
          Footer.ƒ children.Footer ]
