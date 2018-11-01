module BadgePage

open Fabulosa
open Fabulosa.Badge
open Fabulosa.Avatar
open Fabulosa.Docs
open Renderer
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React

(*** define: badge-div-span-sample ***)
let div = badge ([], Value 1, Div ([], [ R.str "Text" ]))

let span = badge ([], Value 2, Span ([], [ R.str "Text" ]))
(*** define: badge-button-avatar-sample ***)
let button = badge ([], Value 3, Button ([], [ R.str "Button" ]))

let avatar = badge ([], Value 4, Avatar ([ Size Large ], Url "assets/avatar-1.png"))
(*** hide ***)
let render () =
    tryMount "badge-div-demo" div
    tryMount "badge-span-demo" span
    tryMount "badge-button-demo" button
    tryMount "badge-avatar-demo" avatar
    //tryMount "badge-props-table"
        //(PropTable.unionPropTable typeof<BadgeRequired>)
    tryMount "badge-child-table"
        (PropTable.unionPropTable typeof<BadgeChildren>)
(**
<div id="badges">

<h2 class="s-title">
    Badge
</h2>

Badges are often used as unread number indicators.

</div>

<div id="divorspan">

<h3 class="s-title">
    Div or Span
</h3>

Badges can be rendered on top
of div or span elements.

<div class="demo">
    <span id="badge-div-demo"></span>
    <br/>
    <span id="badge-span-demo"></span>
</div>

*)

(*** include: badge-div-span-sample ***)

(**

</div>

<div id="buttonoravatar">

<h3 class="s-title">
    Button or Avatar
</h3>

Badges can also be render on top
of the button and avatar components.

<div class="demo">
    <span id="badge-button-demo"></span>
    <span id="badge-avatar-demo"></span>
</div>

*)

(*** include: badge-button-avatar-sample ***)

(**

</div>

<div id="badge-props">

<h3 class="s-title">
    Required props
</h3>

<div class="props-table" id="badge-props-table"></div>

</div>

<div id="badge-props">

<h3 class="s-title">
    Child options
</h3>

<div class="props-table" id="badge-child-table"></div>

</div>

*)