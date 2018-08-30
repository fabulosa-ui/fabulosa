module ButtonPage

open Fabulosa
module R = Fable.Helpers.React

(*** define: button-kind-sample ***)
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
(*** define: button-size-sample ***)
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
(*** define: button-color-sample ***)
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
(*** hide ***)
let icon =
    Icon.ƒ {
        Icon.defaults with
            Kind = Icon.Kind.Plus
    } []
(*** define: button-format-sample ***)
let squared =
    Button.ƒ {
        Button.defaults with
            Format = Button.Format.SquaredAction
    } [icon]

let round =
    Button.ƒ {
        Button.defaults with
            Format = Button.Format.RoundAction
            Kind = Button.Kind.Primary
    } [icon]
(*** define: button-state-sample ***)
let disabled =
    Button.ƒ {
        Button.defaults with
            State = Button.State.Disabled
    } [R.str "Disabled"]

let active =
    Button.ƒ {
        Button.defaults with
            State = Button.State.Active
    } [R.str "Active"]

let loading =
    Button.ƒ {
        Button.defaults with
            State = Button.State.Loading
    } [R.str "------"]
(*** hide ***)
let render () =
    Renderer.tryMount "button-default-demo" button
    Renderer.tryMount "button-primary-demo" primary
    Renderer.tryMount "button-link-demo" link
    Renderer.tryMount "button-small-demo" small
    Renderer.tryMount "button-medium-demo" medium
    Renderer.tryMount "button-large-demo" large
    Renderer.tryMount "button-success-demo" success
    Renderer.tryMount "button-error-demo" error
    Renderer.tryMount "button-squared-demo" squared
    Renderer.tryMount "button-round-demo" round
    Renderer.tryMount "button-disabled-demo" disabled
    Renderer.tryMount "button-active-demo" active
    Renderer.tryMount "button-loading-demo" loading
(**

<div id="buttons">

<h2 class="s-title">
    Buttons
</h2>

Buttons include simple button styles for
actions in different types and sizes.

</div>

<div id="kinds">

<h3 class="s-title">
    Kinds
</h3>

Buttons can have kinds Default, Primary or Link.

<div class="demo">
    <span id="button-default-demo"></span>
    <span id="button-primary-demo"></span>
    <span id="button-link-demo"></span>
</div>
*)

(*** include: button-kind-sample ***)

(**

</div>

<div id="sizes">

<h3 class="s-title">
    Sizes
</h3>

Buttons can have sizes Small or Large.

<div class="demo">
    <span id="button-small-demo"></span>
    <span id="button-medium-demo"></span>
    <span id="button-large-demo"></span>
</div>
*)

(*** include: button-size-sample ***)

(**

</div>

<div id="colors">

<h3 class="s-title">
    Colors
</h3>

Buttons can have colors for Success and Error.

<div class="demo">
    <span id="button-success-demo"></span>
    <span id="button-error-demo"></span>
</div>
*)

(*** include: button-color-sample ***)

(**

</div>

<div id="formats">

<h3 class="s-title">
    Formats
</h3>

Buttons can have formats of SquaredAction and RoundAction.

<div class="demo">
    <span id="button-squared-demo"></span>
    <span id="button-round-demo"></span>
</div>
*)

(*** include: button-format-sample ***)

(**

</div>

<div id="states">

<h3 class="s-title">
    States
</h3>

Buttons can have states of SquaredAction and RoundAction.

<div class="demo">
    <span id="button-disabled-demo"></span>
    <span id="button-active-demo"></span>
    <span id="button-loading-demo"></span>
</div>
*)

(*** include: button-state-sample ***)

(**
</div>
*)