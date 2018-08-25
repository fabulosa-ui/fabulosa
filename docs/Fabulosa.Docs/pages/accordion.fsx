(*** hide ***)
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"

open Fabulosa
open Fable.Import.React
module R = Fable.Helpers.React

(*** define: accordion-sample ***)
let accordion =
    Accordion.ƒ
        Accordion.defaults
        [ { Header = "Header One"
            Content =
                [ R.a [] [R.str "Item One"]
                  R.a [] [R.str "Item Two"] ] }
          { Header = "Header Two"
            Content =
                [ R.a [] [R.str "Item One"]
                  R.a [] [R.str "Item Two"] ] } ]
(**
<h2 class="s-title">
    Accordions
</h2>

Accordions are used to toggle sections of content.

<span id="accordion-demo" style="margin-bottom: 10px"></div>

*)

(*** include: accordion-sample ***)
