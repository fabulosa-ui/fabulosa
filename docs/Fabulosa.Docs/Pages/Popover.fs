module PopoverPage

open Fabulosa.Popover
open Fabulosa.Button
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer
open Microsoft.FSharp.Core

(*** define: popover-default-sample ***)
let def =
    popover ([ Position Right ],
        (Trigger [ button ([], [ R.str "Popover" ]) ],
         Content [ CardPage.def ]))
(*** hide ***)
let render () =
    tryMount "popover-default-demo" def
    tryMount "popover-params-table"
        (PropTable.paramTable
            (Some typeof<PopoverOptional>)
            None
            (Some typeof<PopoverChildren>))
(**

<div id="popover">

<h2 class="s-title">Popover</h2>

Popovers are small overlay content containers.

#### Parameters

<div class="props-table" id="popover-params-table"></div>

#### Example

A simple popover component that pops upwards.

<div class="demo" id="popover-default-demo"></div>

*)
(*** include: popover-default-sample ***)
(**

</div>

*)