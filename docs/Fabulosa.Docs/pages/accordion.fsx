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
(*** define: accordion-custom-sample ***)
let custom =
    Accordion.ƒ
        { Accordion.defaults with
            CustomIcon =
                { Icon.defaults with
                    Kind = Icon.Kind.Forward } }
        [ { Header = "Header One"
            Content =
                [ R.a [] [R.str "Item One"]
                  R.a [] [R.str "Item Two"] ] }
          { Header = "Header Two"
            Content =
                [ R.a [] [R.str "Item One"]
                  R.a [] [R.str "Item Two"] ] } ]
(**

<div id="accordions">

<h2 class="s-title">
    Accordions
</h2>

Accordions are used to toggle sections of content.

<div class="demo" id="accordion-demo"></div>

*)

(*** include: accordion-sample ***)

(**

</div>

<div id="accordion-custom">

<h3 class="s-title">
    Custom Icon
</h3>

Accordions accept icon props for a custom icon.

<div class="demo" id="accordion-custom-demo"></div>

*)

(*** include: accordion-custom-sample ***)

(**

</div>

*)
