module ButtonPage


open Fabulosa.Docs
open Fabulosa.Icon
open Fabulosa.Button
open Fabulosa
module R = Fable.Helpers.React
open Renderer

(*** define: button-kind-sample ***)
let def = button ([], [ R.str "Default" ])

let primary = button ([ Kind Primary ], [ R.str "Primary" ])

let link = button ([ Kind Link ], [ R.str "Link" ])
(*** define: button-size-sample ***)
let small = button ([ Size Small ], [ R.str "Small" ])

let medium = button ([], [ R.str "Medium" ])

let large = button ([ Size Large ], [ R.str "Large" ])
(*** define: button-color-sample ***)
let success = button ([ Color Success ], [ R.str "Success" ])

let error = button ([ Color Error ], [ R.str "Error" ])
(*** hide ***)
let icon = icon ([], IconRequired.Kind Plus)
(*** define: button-format-sample ***)
let squared = button ([ Shape Squared ], [ icon ])

let round = button ([ Shape Round; Kind Primary ], [ icon ])
(*** define: button-state-sample ***)
let disabled = button ([ State Disabled ], [ R.str "Disabled" ])

let active = button ([ State Button.Active ], [ R.str "Active" ])

let loading = button ([ State Loading ], [ R.str "-------" ])
(*** hide ***)
let render () =
    tryMount "button-default-demo" def
    tryMount "button-primary-demo" primary
    tryMount "button-link-demo" link
    tryMount "button-small-demo" small
    tryMount "button-medium-demo" medium
    tryMount "button-large-demo" large
    tryMount "button-success-demo" success
    tryMount "button-error-demo" error
    tryMount "button-squared-demo" squared
    tryMount "button-round-demo" round
    tryMount "button-disabled-demo" disabled
    tryMount "button-active-demo" active
    tryMount "button-loading-demo" loading
    tryMount "button-props-table"
        (PropTable.unionPropTable typeof<ButtonOptional>)
(**

<div id="buttons">

<div id="alt"></div>

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

<div id="button-props">

<h3 class="s-title">
    Optional Props
</h3>

<div class="props-table" id="button-props-table"></div>

</div>

*)
