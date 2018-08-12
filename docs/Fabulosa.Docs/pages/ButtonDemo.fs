module ButtonDemo

open Fabulosa
module R = Fable.Helpers.React

let button = Button.ƒ Button.defaults [R.str "Default"]

R.mountById "button-default-demo" button

let primary =
    Button.ƒ {
        Button.defaults with
            Kind = Button.Kind.Primary
    } [R.str "Primary"]

R.mountById "button-primary-demo" primary

let link =
    Button.ƒ {
        Button.defaults with
            Kind = Button.Kind.Link
    } [R.str "Link"]

R.mountById "button-link-demo" link