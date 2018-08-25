(*** hide ***)
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"

open Fabulosa
open Fable.Import.React
module R = Fable.Helpers.React

(*** define: sample ***)
let fabulousButton =
    Button.ƒ
        Button.defaults
        [R.str "Fabulosa"]

(**
<h2 class="s-title">
    Getting Started
</h2>
*)

(*** include: sample ***)

(**
<div class="demo" id="button-demo">
</div>
*)
