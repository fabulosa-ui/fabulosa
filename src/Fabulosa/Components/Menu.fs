namespace Fabulosa

module Menu =

    open Fabulosa.Extensions
    open Fable.Import
    open Fable.Import.React
    module R = Fable.Helpers.React
    open Fable.Helpers.React.ReactiveComponents
    open R.Props

    [<RequireQualifiedAccess>]
    type Trigger = Button.T

    [<RequireQualifiedAccess>]
    type Divider =
    | Text of string
    | Empty

    [<RequireQualifiedAccess>]
    type Child =
    | Item of ReactElement seq
    | Divider of Divider

    [<RequireQualifiedAccess>]
    type Children = Child seq

    [<RequireQualifiedAccess>]
    type Message =
    | Click of int * int

    type Props =
        { HTMLProps: HTMLProps
          Trigger: Trigger
          Opened: bool }

    type State =
        { Opened: bool
          Position: int * int }

    let onClick (e: MouseEvent) =
        let element = e.currentTarget :?> Browser.Element
        let rect = element.getBoundingClientRect ()
        let x = (rect.left |> int) + (Browser.window.scrollX |> int)
        let y = (rect.bottom |> int) + (Browser.window.scrollY |> int)
        Message.Click (x, y)

    let private renderTrigger (trigger: Trigger) dispatch =
        let props, children = trigger
        let withClick =
            props.HTMLProps @ [ OnClick (onClick >> dispatch) ]
        Anchor.ƒ
            ( { props with
                  HTMLProps = withClick },
              children )

    let private renderDivider =
        function
        | Divider.Text text ->
            R.li
                [ ClassName "divider"
                  Data ("content", text) ] []
        | Divider.Empty ->
            R.li
                [ ClassName "divider" ] []

    let private renderItem =
        R.li [ ClassName "menu-item" ]

    let private renderChild =
        function
        | Child.Item elements -> renderItem elements
        | Child.Divider divider -> renderDivider divider

    let private renderChildren children =
        Seq.map renderChild children

    let private renderMenu state props children =
        let (x, y) = state.Position
        if state.Opened then
            props.HTMLProps
            @
            [ Style
                [ Position "absolute"
                  Left x
                  Top y ] ]
            |> addProp (ClassName "menu")
            |> R.ul <| children
        else R.ofOption None

    let private init (props: Props) =
        { Opened = props.Opened
          Position = 0, 0 }

    let private update message state =
        match message with
        | Message.Click (x, y) ->
            { state with
                Opened = not state.Opened
                Position = x, y }

    let private view model dispatch =
        R.fragment [] 
            [ renderTrigger model.props.Trigger dispatch
              renderMenu
                model.state
                model.props
                model.children |> Portal.ƒ "menu-container" ]

    let defaults =
        { HTMLProps = []
          Trigger =
            Button.defaults,
            [ Icon.ƒ
                { Icon.defaults with Kind = Icon.Kind.Menu } ]
          Opened = false }

    let ƒ props children =
        R.reactiveCom
            init
            update
            view
            ""
            props
            (renderChildren children)