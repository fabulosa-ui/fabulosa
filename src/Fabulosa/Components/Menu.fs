namespace Fabulosa

module Menu =

    open Fabulosa.Extensions
    open Fabulosa.Button
    open Fable.Import
    open Fable.Import.React
    module R = Fable.Helpers.React
    open Fable.Helpers.React.ReactiveComponents
    module P = R.Props
    
    type MenuItem = ReactElement list

    let menuItem (comp: MenuItem) =
        R.li [ P.ClassName "menu-item" ] comp

    type MenuDividerOptional =
        | Text of string
        interface P.IHTMLProp

    type MenuDivider =
        P.HTMLProps

    let private menuDividerText (prop: P.IHTMLProp) =
        match prop with
         | :? MenuDividerOptional as opt ->
             match opt with
             | Text txt ->
                 ([] |> List.cast<P.IHTMLProp>)
                  @ [ P.Data ("content", txt) ]
                 |> List.head
         | _ -> prop 

    let menuDivider (opt: MenuDivider) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "divider")
        |> P.map menuDividerText
        |> P.merge
        |> R.li <| []

    type TriggerMessage =
        Click of int * int

    type private TriggerRequired =
        TriggerMessage -> unit

    type TriggerChildren =
        Button of Button

    type private Trigger =
        TriggerRequired * TriggerChildren

    let private onTriggerClicked (e: MouseEvent) =
        let element = e.currentTarget :?> Browser.Element
        let rect = element.getBoundingClientRect ()
        let x = (rect.left |> int) + (Browser.window.scrollX |> int)
        let y = (rect.bottom |> int) + (Browser.window.scrollY |> int)
        TriggerMessage.Click (x, y)

    let menuTrigger ((req, (Button btn)): Trigger) =
        let btnOpt, btnChi = btn
        let withClick =
           P.Unmerged btnOpt
            |> P.addProps
                [ P.ClassName "btn"
                  P.OnClick (onTriggerClicked >> req) ]
            |> P.merge
        R.a withClick btnChi

    type Position =
        Position of int * int

    type IsOpen =
        | IsOpen of bool
        interface P.IHTMLProp

    type MenuContainerRequired =
        Position * IsOpen

    type MenuContainerChildren = ReactElement []

    type private MenuContainer =
        P.HTMLProps * MenuContainerRequired * MenuContainerChildren

    let menuContainer (opt, (Position (x, y), IsOpen opn), chi) =
        if opn then
            opt
            |> P.addProps
                [ P.ClassName "menu"
                  P.Style
                      [ P.Position "absolute"
                        P.Left x
                        P.Top y ] ]
            |> P.merge
            |> R.ul <| chi
            |> Some
        else None
        |> R.ofOption

    type MenuChild =
    | Item of MenuItem
    | Divider of MenuDivider

    type MenuChildren =
        MenuChild list

    type MenuRequired =
        Trigger of Button

    type Menu =
        P.HTMLProps * MenuRequired * MenuChildren

    type State =
        { IsOpen: bool
          Position: int * int }

    let private init (opt, req) =
        let maybeOpen =
            opt
            |> List.tryFind
                (fun (prop: P.IHTMLProp) ->
                    match prop with
                    | :? IsOpen as opt ->
                        match opt with
                        | IsOpen opn -> true
                    | _ -> false)
        { IsOpen = maybeOpen.IsSome
          Position = 0, 0 }

    let private update message state =
        match message with
        | TriggerMessage.Click (x, y) ->
            { state with
                IsOpen = not state.IsOpen
                Position = x, y }

    let private view (model) dispatch =
        let (opt: P.HTMLProps), (Trigger trig) = model.props
        R.fragment [] 
            [ menuTrigger (dispatch, Button trig)
              menuContainer
                (P.Unmerged [], (Position model.state.Position, IsOpen model.state.IsOpen), 
                 model.children)
              |> Portal.ƒ "menu-container" ]

    let menu ((opt, req, chi): Menu) =
        R.reactiveCom
            init
            update
            view
            ""
            (opt, req)
            (Seq.map
                (function
                 | Item elements -> menuItem elements
                 | Divider divider -> menuDivider divider)
                chi)
                