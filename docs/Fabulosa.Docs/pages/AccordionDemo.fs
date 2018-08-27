﻿namespace Fabulosa.Docs

module AccordionDemo =

    open Fabulosa
    module R = Fable.Helpers.React
    
    let accordion =
        Accordion.ƒ
            Accordion.defaults
            [ { Header = "Header One"
                Content = [
                    R.a [] [R.str "Item One"]
                    R.a [] [R.str "Item Two"]
                ] }
              { Header = "Header Two"
                Content = [
                    R.a [] [R.str "Item One"]
                    R.a [] [R.str "Item Two"]
                ] } ]
    let custom =
        Accordion.ƒ
            { Accordion.defaults with
                CustomIcon =
                    { Icon.defaults with
                        Kind = Icon.Kind.Forward } }
            [ { Header = "Header One"
                Content =
                    [ R.a [] [R.str "Item One"]
                      R.a [] [R.str "Item Two"] ] }
              { Header = "Header Two"
                Content =
                    [ R.a [] [R.str "Item One"]
                      R.a [] [R.str "Item Two"] ] } ]

    let render () =
        Renderer.tryMount "accordion-demo" accordion
        Renderer.tryMount "accordion-custom-demo" custom