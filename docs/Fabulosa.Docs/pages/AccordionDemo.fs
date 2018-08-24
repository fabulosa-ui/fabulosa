namespace Fabulosa.Docs

module AccordionDemo =

    open Fabulosa
    open Fable.Helpers.React
    open Fable.Helpers.React.Props

    let accordion =
        Accordion.ƒ
            Accordion.defaults
            [ { Header = [ str "Header One" ]
                Content = [
                    ul [ClassName "menu menu-nav"] [
                        li [ClassName "menu-item"] [
                            a [] [str "Item One"]
                        ]
                        li [ClassName "menu-item"] [
                            a [] [str "Item Two"]
                        ]
                    ]
                ] }
              { Header = [ str "Header Two" ]
                Content = [
                    ul [ClassName "menu menu-nav"] [
                        li [ClassName "menu-item"] [
                            a [] [str "Item One"]
                        ]
                        li [ClassName "menu-item"] [
                            a [] [str "Item Two"]
                        ]
                    ]
                ]
              } ]
           

    let render () =
        Renderer.tryMount "demo" accordion