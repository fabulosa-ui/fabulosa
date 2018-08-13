module ButtonDemo

open Fabulosa
module R = Fable.Helpers.React

let button =
    Button.ƒ
        Button.defaults
        [R.str "Default"]

let primary =
    Button.ƒ {
        Button.defaults with
            Kind = Button.Kind.Primary
    } [R.str "Primary"]

let link =
    Button.ƒ {
        Button.defaults with
            Kind = Button.Kind.Link
    } [R.str "Link"]

let small =
    Button.ƒ {
        Button.defaults with
            Size = Button.Size.Small
    } [R.str "Small"]
let medium =
    Button.ƒ
        Button.defaults
        [R.str "Default"]
let large =
    Button.ƒ {
        Button.defaults with
            Size = Button.Size.Large
    } [R.str "Large"]

let success =
    Button.ƒ {
        Button.defaults with
            Color = Button.Color.Success
    } [R.str "Success"]

let error =
    Button.ƒ {
        Button.defaults with
            Color = Button.Color.Error
    } [R.str "Error"]

let render () =
    Renderer.tryMount "button-default-demo" button
    Renderer.tryMount "button-primary-demo" primary
    Renderer.tryMount "button-link-demo" link
    Renderer.tryMount "button-small-demo" small
    Renderer.tryMount "button-medium-demo" medium
    Renderer.tryMount "button-large-demo" large
    Renderer.tryMount "button-success-demo" success
    Renderer.tryMount "button-error-demo" error