module StepPage

open Fabulosa
open Fabulosa.Step
module R = Fable.Helpers.React
open Fable.Import.React
open Renderer

(*** define: step-default-sample ***)
let def =
    step ([],
      [ Item ([], [ R.str "Step 1" ])
        Item ([ Active ], [ R.str "Step 2" ])
        Item ([], [ R.str "Step 3" ]) ])
(*** hide ***)
let render () =
    tryMount "step-default-demo" def
    //tryMount "step-props-table"
    //    (PropTable.propTable typeof<Step.Props> Step.props)
    //tryMount "step-item-props-table"
        //(PropTable.propTable typeof<Step.Item.Props> Step.Item.props)
(**

<div id="step">

<h2 class="s-title">
    Step
</h2>

Steps are progress indicators of a
sequence of task steps

</div>

<div id="step-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="step-props-table"></div>

</div>

<div id="step-default">

<h3 class="s-title">
    Default
</h3>

A simple step component with three steps
and an active step

<div class="demo" id="step-default-demo"></div>

*)

(*** include: step-default-sample ***)

(**

</div>

<div id="step-item">

<h2 class="s-title">
    Step Item
</h2>

Step items are child elements for steps

</div>

<div id="step-item-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="step-item-props-table"></div>

</div>

*)