(*** hide ***)
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"

open Fabulosa
open Fable.Import.React
module R = Fable.Helpers.React

(*** define: button-sample ***)
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

(**
<h2 class="s-title">
    Buttons
</h2>
<p class="s-description">
    Buttons include simple button styles for
    actions in different types and sizes.
</p>

### Kinds

Buttons can have the kinds Default, Primary, or Link

<div class="demo">
    <span id="button-default-demo"></span>
    <span id="button-primary-demo"></span>
    <span id="button-link-demo"></span>
</div>


### Code Sample
*)

(*** include: button-sample ***)