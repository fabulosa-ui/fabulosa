module AccordionPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React

(*** define: accordion-sample ***)
let accordion =
    Accordion.ƒ
        Accordion.defaults
        [ { Header = "Header One"
            Content = [
                R.a [] [R.str "Item One"]
                R.a [] [R.str "Item Two"]
            ] }
          { Header = "Header Two"
            Content = [
                R.a [] [R.str "Item One"]
                R.a [] [R.str "Item Two"]
            ] } ]
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

</div>

<div id="accordion-props">

<h3 class="s-title">
    Props
</h3>

<div id="accordion-props-table"></div>

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
    Renderer.tryMount "accordion-demo" accordion
    Renderer.tryMount "accordion-custom-demo" custom
    Renderer.tryMount "accordion-props-table" (PropTable.propTable typeof<Accordion.Props> Accordion.defaults)
    