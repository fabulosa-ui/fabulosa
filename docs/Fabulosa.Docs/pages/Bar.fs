module BarPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer

(*** define: bar-default-sample ***)
let bar = Bar.ƒ Bar.defaults [
    { Bar.Item.defaults with Value = 25 }
]
(*** define: bar-small-sample ***)
let small =
    Bar.ƒ {
        Bar.defaults with
            Small = true
    } [ { Bar.Item.defaults with Value = 25 } ]
(*** define: bar-item-tooltip-sample ***)
let tooltip = Bar.ƒ Bar.defaults [
    { Bar.Item.defaults with
        Value = 25
        Tooltip = true }
]
(*** define: bar-item-multiple-sample ***)
let multiple = Bar.ƒ Bar.defaults [
    { Bar.Item.defaults with
        Value = 25 }
    { Bar.Item.defaults with
        Value = 15 }
    { Bar.Item.defaults with
        Value = 5 }
]
(*** hide ***)
let render () =
    tryMount "bar-default-demo" bar
    tryMount "bar-small-demo" small
    tryMount "bar-item-tooltip-demo" tooltip
    tryMount "bar-item-multiple-demo" multiple
    tryMount "bar-props-table" (PropTable.propTable typeof<Bar.Props> Bar.defaults)
(**

<div id="bars">

<h2 class="s-title">
    Bars
</h2>

Bars represent the progress of a task or the
value within the known range. Bars are custom
components for displaying HTML5 progress, meter
and input range elements.

</div>

<div id="bar-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="bar-props-table"></div>

</div>

<div id="bar-default">

<h3 class="s-title">
    Default
</h3>

The default bar

<div class="demo" id="bar-default-demo"></div>

*)

(*** include: bar-default-sample ***)

(**

</div>

<div id="bar-small">

<h3 class="s-title">
    Small
</h3>

A small version of the bar

<div class="demo" id="bar-small-demo"></div>

*)

(*** include: bar-small-sample ***)

(**

</div>

<div id="bar-item-tooltip">

<h3 class="s-title">
    Tooltips
</h3>

Bar items can have tooltips

<div class="demo" id="bar-item-tooltip-demo"></div>

*)

(*** include: bar-item-tooltip-sample ***)

(**

</div>

<div id="bar-item-multiple">

<h3 class="s-title">
    Multiple items
</h3>

Bar can also have multiple items

<div class="demo" id="bar-item-multiple-demo"></div>

*)

(*** include: bar-item-multiple-sample ***)

(**

</div>

*)