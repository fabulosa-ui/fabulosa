module ResponsivePage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Renderer

(*** define: responsive-sample ***)
let hideSmall =
    Responsive.ƒ
        ( { Responsive.defaults with
              Hide = Responsive.Size.SM },
          [ Button.ƒ
              ( Button.defaults,
                [ R.str "Hide small" ] ) ] )

let showLarge =
    Responsive.ƒ
        ( { Responsive.defaults with
              Show = Responsive.Size.LG },
          [ Button.ƒ
              ( Button.defaults,
                [R.str "Show large"] ) ] )
(*** hide ***)
let render () =
    tryMount "responsive-demo-hide" hideSmall
    tryMount "responsive-demo-show" showLarge
    tryMount "navbar-props-table" (PropTable.propTable typeof<Responsive.Props> Responsive.defaults)
(**

<div id="responsive">

<h2 class="s-title">
    Responsive
</h2>

Spectre provides a neat responsive
layout grid system and responsive
visibility utilities.

</div>

<div id="responsive-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="navbar-props-table"></div>

</div>

<div id="responsive-hide-show">

<h3 class="s-title">
    Hide and Show
</h3>

Show or hide elements based
on the viewport size

<div class="demo" style="display:flex">
    <span id="responsive-demo-hide"></span>
    &nbsp;
    <span id="responsive-demo-show"></span>
</div>

*)

(*** include: responsive-sample ***)

(**

</div>

*)