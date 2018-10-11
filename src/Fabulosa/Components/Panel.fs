namespace Fabulosa

[<RequireQualifiedAccess>]
module Panel =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    module Header =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (header: T) =
            R.div
                [ ClassName "panel-header" ]
                [ R.div [ ClassName "panel-title h6"] header ]

    [<RequireQualifiedAccess>]
    module Nav =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (nav: T) =
            R.div
                [ ClassName "panel-nav" ]
                nav

    [<RequireQualifiedAccess>]
    module Body =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (body: T) =
            R.div
                [ ClassName "panel-body" ]
                body

    [<RequireQualifiedAccess>]
    module Footer =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (footer: T) =
            R.div
                [ ClassName "panel-footer" ]
                footer

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children<'Header, 'Nav, 'Body, 'Footer> =
        { Header: 'Header option
          Nav: 'Nav option
          Body: 'Body option
          Footer: 'Footer option }

    [<RequireQualifiedAccess>]
    type T<'Header, 'Nav, 'Body, 'Footer> =
        Props * Children<'Header, 'Nav, 'Body, 'Footer>

    let props =
        { Props.HTMLProps = [] }

    let children =
        { Children.Header = None
          Children.Nav = None
          Children.Body = None
          Children.Footer = None }

    let private child render =
        function
        | Some elements ->
            render elements
        | None -> R.ofOption None

    let build
        headerƒ
        navƒ
        bodyƒ
        footerƒ
        (panel: T<'Header, 'Nav, 'Body, 'Footer>) =
        let rops, children = panel
        props.HTMLProps
        |> addProp (ClassName "panel")
        |> R.div
        <| [ child headerƒ children.Header
             child navƒ children.Nav
             child bodyƒ children.Body
             child footerƒ children.Footer ]

    let ƒ = build Header.ƒ Nav.ƒ Body.ƒ Footer.ƒ
