module ButtonDemo

open Fabulosa
module R = Fable.Helpers.React

let button =
    Button.ƒ
        Button.defaults
        [R.str "Default"]

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

let small =
    Button.ƒ {
        Button.defaults with
            Size = Button.Size.Small
    } [R.str "Small"]

R.mountById "button-small-demo" small

let medium =
    Button.ƒ
        Button.defaults
        [R.str "Default"]

R.mountById "button-medium-demo" medium

let large =
    Button.ƒ {
        Button.defaults with
            Size = Button.Size.Large
    } [R.str "Large"]

R.mountById "button-large-demo" large

let success =
    Button.ƒ {
        Button.defaults with
            Color = Button.Color.Success
    } [R.str "Success"]

R.mountById "button-success-demo" success

let error =
    Button.ƒ {
        Button.defaults with
            Color = Button.Color.Error
    } [R.str "Error"]

R.mountById "button-error-demo" error