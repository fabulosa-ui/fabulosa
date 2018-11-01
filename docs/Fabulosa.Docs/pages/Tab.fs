module TabPage

open Fabulosa
open Fabulosa.Badge
open Fabulosa.Tab
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer
open Microsoft.FSharp.Core

(*** define: tab-default-sample ***)
let def =
    tab ([],
      [ Item ([], [ R.a [] [ R.str "Tab 1" ] ])
        Item ([ Active ], [ R.a [] [ R.str "Tab 2" ] ])
        Item ([],
          [ badge ([], Value 1, Anchor ([], [ R.str "Tab 3" ])) ]) ])
(*** hide ***)
let render () =
    tryMount "tab-default-demo" def
    //tryMount "tab-props-table"
        //(PropTable.propTable typeof<Tab.Props> Tab.props)
(**

<div id="tab">

<h2 class="s-title">
    Tab
</h2>

Tabs enable quick switch between different views

</div>

<div id="tab-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="tab-props-table"></div>

</div>

<div id="tab-default">

<h3 class="s-title">
    Default
</h3>

A simple tab component

<div class="demo" id="tab-default-demo"></div>

*)

(*** include: tab-default-sample ***)

(**

</div>

*)