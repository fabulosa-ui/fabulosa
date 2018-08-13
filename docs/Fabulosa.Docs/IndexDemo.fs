module IndexDemo

open Fabulosa
module R = Fable.Helpers.React
open R.Props

let button =
    Anchor.ƒ {
        Anchor.defaults with
            Kind = Button.Kind.Primary
            HTMLProps = [Href "/pages/button.html"]
    } [R.str "Fabulosa"]

R.mountById "button-demo" button