namespace Fabulosa

module Menu =

    open Fabulosa.Extensions
    open Fable.Import
    open Fable.Import.React
    module R = Fable.Helpers.React
    open Fable.Helpers.React.ReactiveComponents
    open R.Props

    [<RequireQualifiedAccess>]
    module Item =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let build (item: T) =
            R.li [ ClassName "menu-item" ] item

        let ƒ = build

    [<RequireQualifiedAccess>]
    module Divider =

        [<RequireQualifiedAccess>]
        type T = string option

        let build (divider: T) =
            match divider with
            | Some text ->
                R.li
                    [ ClassName "divider"
                      Data ("content", text) ] []
            | None ->
                R.li
                    [ ClassName "divider" ] []

        let ƒ = build

    [<RequireQualifiedAccess>]
    module Trigger =

        [<RequireQualifiedAccess>]
        type Message =
        | Click of int * int

        [<RequireQualifiedAccess>]
        type private Props =
            Message -> unit

        [<RequireQualifiedAccess>]
        type private Children = Button.T

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props _ = ()

        let children =
            Button.props,
            [ Icon.ƒ
                { Icon.props with Kind = Icon.Kind.Menu } ]

        let onClick (e: MouseEvent) =
            let element = e.currentTarget :?> Browser.Element
            let rect = element.getBoundingClientRect ()
            let x = (rect.left |> int) + (Browser.window.scrollX |> int)
            let y = (rect.bottom |> int) + (Browser.window.scrollY |> int)
            Message.Click (x, y)

        let build (trigger: T) =
            let props, children = trigger
            let cProps, cChildren = children
            let withClick =
                cProps.HTMLProps @ [ OnClick (onClick >> props) ]
            Anchor.ƒ
                ( { cProps with
                      HTMLProps = withClick },
                  cChildren )

        let ƒ = build

    [<RequireQualifiedAccess>]
    module Container =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps
              Opened: bool
              Position: int * int }

        [<RequireQualifiedAccess>]
        type Children = ReactElement []

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = []
              Props.Opened = false
              Props.Position = 0, 0 }

        let build (container: T) =
            let props, children = container
            let (x, y) = props.Position
            if props.Opened then
                props.HTMLProps
                @
                [ Style
                    [ Position "absolute"
                      Left x
                      Top y ] ]
                |> addProp (ClassName "menu")
                |> R.ul <| children
            else R.ofOption None

        let ƒ = build

    [<RequireQualifiedAccess>]
    type Child<'Item, 'Divider> =
    | Item of 'Item
    | Divider of 'Divider

    [<RequireQualifiedAccess>]
    type Children<'Item, 'Divider> =
        Child<'Item, 'Divider> list

    type Props =
        { HTMLProps: HTMLProps
          Trigger: Button.T
          Opened: bool }

    [<RequireQualifiedAccess>]
    type T<'Item, 'Divider> =
        Props * Children<'Item, 'Divider>

    type State =
        { Opened: bool
          Position: int * int }

    let private init (props: Props) =
        { Opened = props.Opened
          Position = Container.props.Position }

    let private update message state =
        match message with
        | Trigger.Message.Click (x, y) ->
            { state with
                Opened = not state.Opened
                Position = x, y }

    let private view model dispatch =
        R.fragment [] 
            [ Trigger.ƒ (dispatch, model.props.Trigger)
              Container.ƒ
                ({ Opened = model.state.Opened
                   Position = model.state.Position
                   HTMLProps = model.props.HTMLProps },
                 model.children)
              |> Portal.ƒ "menu-container" ]

    let props =
        { HTMLProps = Container.props.HTMLProps
          Trigger = Trigger.children
          Opened = Container.props.Opened }

    let build itemƒ dividerƒ (menu: T<'Item, 'Divider>) =
        let props, children = menu
        R.reactiveCom
            init
            update
            view
            ""
            props
            (Seq.map
                (function
                 | Child.Item elements -> itemƒ elements
                 | Child.Divider divider -> dividerƒ divider)
                children)

    let ƒ = build Item.ƒ Divider.ƒ