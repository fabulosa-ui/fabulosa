namespace Fabulosa.Docs

module AccordionDemo =

    open Fabulosa
    module R = Fable.Helpers.React

    let accordion =
        Accordion.ƒ
            Accordion.defaults
            [ { Header = "Header One"
                Content = [
                    R.str "Simple string"
                    R.p [] [R.str "A paragraph"]
                    R.a [] [R.str "A link"]
                ] }
              { Header = "Header Two"
                Content = [
                    R.str "Item One"
                    R.str "Item Two"
                ] } ]

    let render () =
        Renderer.tryMount "demo" accordion