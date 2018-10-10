module AccordionPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open Renderer

(*** define: accordion-sample ***)
let accordion =
    Accordion.ƒ
        (Accordion.props,
         [ { Header =
                { Accordion.Header.children with
                    Text = "Header One"}
             Body =
               [ R.a [] [ R.str "Item One" ]
                 R.a [] [ R.str "Item Two" ] ] }
           { Header =
                { Accordion.Header.children with
                    Text = "Header Two" }
             Body =
               [ R.a [] [ R.str "Item One" ]
                 R.a [] [ R.str "Item Two" ] ] } ])
(*** define: accordion-custom-sample ***)
let custom =
    Accordion.ƒ
        (Accordion.props,
         [ { Header =
                { Icon =
                    { Icon.props with
                        Kind = Icon.Kind.Forward }
                  Text = "Header One"}
             Body =
               [ R.a [] [ R.str "Item One" ]
                 R.a [] [ R.str "Item Two" ] ] }
           { Header =
                { Icon =
                    { Icon.props with
                        Kind = Icon.Kind.Forward }
                  Text = "Header One" }
             Body =
               [ R.a [] [ R.str "Item One" ]
                 R.a [] [ R.str "Item Two" ] ] } ])
(**

<div id="accordions">

<h2 class="s-title">
    Accordions
</h2>

Accordions are used to toggle sections of content.

</div>

<div id="accordion-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="accordion-props-table"></div>

</div>

<div id="accordion-default">

<h3 class="s-title">
    Default
</h3>

The default setting for accordions

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

(*** hide ***)
let render () =
    tryMount "accordion-demo" accordion
    tryMount "accordion-custom-demo" custom
    tryMount "accordion-props-table"
        (PropTable.propTable typeof<Accordion.Props> Accordion.props)
    