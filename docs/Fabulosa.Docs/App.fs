module App

open Fable.Import.Browser
open Fable.Core.JsInterop

importAll "./styles.scss"

open Elmish
open Elmish.Browser.UrlParser
open Elmish.Browser.Navigation
module R = Fable.Helpers.React
open Fabulosa
open R.Props

type Page =
    | ButtonPage
    | CodePage
    | FormPage
    | GridPage
    | TablePage
    | TypographyPage
    | HomePage

type Model = {
    currentPage: Page
}

type Message = int

let toHash page =
    match page with
    | ButtonPage -> "#button"
    | CodePage -> "#code"
    | FormPage -> "#form"
    | GridPage -> "#grid"
    | HomePage -> "#home"
    | TablePage -> "#table"
    | TypographyPage -> "#typography"

let pageParser: Parser<Page->Page,Page> =
    oneOf [
        map ButtonPage (s "button")
        map CodePage (s "code")
        map GridPage (s "grid")
        map FormPage (s "form")
        map HomePage (s "home")
        map TablePage (s "table")
        map TypographyPage (s "typography")
    ]

let menuItem label page currentPage =
    R.li
      [ ClassName "nav-item" ]
      [ R.a
          [ R.classList [ "is-active", page = currentPage ]
            Href (toHash page) ]
          [ R.str label ] ]

let menu currentPage =
    R.fragment [] [
        R.div [ClassName "docs-brand"] [
            R.a [ClassName "docs-logo"] [
                R.img [Src "logo_64.svg"; Style [Width 42]]
                R.strong [] [R.str "FABULOSA"]
            ]
        ]
        R.ul [ ClassName "nav docs-nav" ] [
            menuItem "Home" HomePage currentPage
            menuItem "Button" ButtonPage currentPage
            menuItem "Code" CodePage currentPage
            menuItem "Form" FormPage currentPage
            menuItem "Grid" GridPage currentPage
            menuItem "Table" TablePage currentPage
            menuItem "Typograpy" TypographyPage currentPage
        ]
    ]

let urlUpdate (result: Option<Page>) model =
    match result with
    | None ->
        console.error("Error parsing url")
        model, Navigation.modifyUrl (toHash model.currentPage)
    | Some page ->
        { model with currentPage = page }, []

let init result =
    let (model, cmd) =
        urlUpdate result { currentPage = HomePage }
    model, Cmd.batch [ cmd ]

let update (msg: Message) (model: Model): Model * Cmd<Message> =
    match msg with
    | _ -> model, []

let view (model: Model) (dispatch: Dispatch<'a>) =
    let pageHtml =
        function
        | ButtonPage -> ButtonPage.view ()
        | CodePage -> CodePage.view ()
        | FormPage -> FormPage.view()
        | GridPage -> GridPage.view ()
        | HomePage -> Home.view ()
        | TablePage -> TablePage.view ()
        | TypographyPage -> TypographyPage.view ()
    R.div [ClassName "docs-container off-canvas off-canvas-sidebar-show"] [
        R.div [ClassName "docs-navbar"] [
            Navbar.Header.ƒ Navbar.defaults [
                Navbar.Section.ƒ Navbar.defaults []
                Navbar.Section.ƒ Navbar.defaults [
                    Anchor.ƒ Anchor.defaults [R.str "hello"]
                ]
            ]
        ]
        R.div [Id "sidebar-id"; ClassName "docs-sidebar off-canvas-sidebar"] [
            menu model.currentPage
        ]
        R.a [ClassName "off-canvas-toggle btn btn-primary btn-action"; Href "#sidebar-id"; Style [ZIndex 100]] [
            R.i [ClassName "icon icon-menu"] []
        ]
        R.a [ClassName "off-canvas-overlay"; Href "#close"] []
        R.div [ClassName "off-canvas-content"] [
            R.div [ClassName "docs-content"] [
                pageHtml model.currentPage
            ]
        ]
    ]

open Elmish.React

Program.mkProgram init update view
|> Program.toNavigable (parseHash pageParser) urlUpdate
|> Program.withReact "elmish-app"
|> Program.run