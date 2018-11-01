module NavPage

open Fabulosa
open Fabulosa.Nav
open Fabulosa.Docs
open Renderer
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
                
(*** define: nav-default-sample ***)
let def =
    nav ([],
      [ Item ([], Text "Item One")
        Nav ([], [ Item ([], Text "Item One Nested") ])
        Item ([], Text "Item Two") ])
(*** hide ***)
let render () =
    tryMount "nav-default-demo" def
    //tryMount "nav-props-table"
    //    (PropTable.propTable typeof<Nav.Props> Nav.props)
    //tryMount "nav-item-props-table"
        //(PropTable.propTable typeof<Nav.Item.Props> Nav.Item.props)
(**

<div id="navs">

<h2 class="s-title">
    Navs
</h2>

Navs is the default component
for navigation lists

</div>

<div id="nav-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="nav-props-table"></div>

</div>

<div id="nav-item-props">

<h3 class="s-title">
    Item Props
</h3>

<div class="props-table" id="nav-item-props-table"></div>

</div>

<div id="nav-default">

<h3 class="s-title">
    Default
</h3>

The default nav component.

<div class="demo" style="width: 50%" id="nav-default-demo"></div>

*)

(*** include: nav-default-sample ***)

(**

</div>

*)