module HomeDemo

open Fabulosa
module R = Fable.Helpers.React
open R.Props

let button =
    Anchor.ƒ {
        Anchor.defaults with
            Kind = Button.Kind.Primary
            HTMLProps = [Href "button.html"]
    } [R.str "Fabulosa"]

let render () =
    Renderer.tryMount "button-demo" button
