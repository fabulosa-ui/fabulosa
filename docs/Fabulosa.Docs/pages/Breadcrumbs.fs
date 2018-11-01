module BreadcrumbPage

open Fabulosa
open Fabulosa.Breadcrumb
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer

(*** define: breadcrumbs-demo ***)
let element =
    breadcrumb ([],
        [ String ([], Text "Text")
          Link ([], Href "#", Text "Link")
          Elements ([], [ R.str "Hey: "; R.a [] [ R.str "Jude" ] ]) ])
(*** hide ***)
let render () =
    tryMount "breadcrumbs-demo" element
    tryMount "breadcrumb-children-table"
        (PropTable.unionPropTable typeof<BreadcrumbChildren>)
    //tryMount "breadcrumb-text-children-table"
        //(PropTable.unionPropTable typeof<BreadcrumbItemChildren>)
    tryMount "breadcrumb-link-required-table"
        (PropTable.unionPropTable typeof<BreadcrumbLinkRequired>)
    //tryMount "breadcrumb-link-children-table"
        //(PropTable.unionPropTable typeof<BreadcrumbItemChildren>)
(**

<div id="breadcrumbs">

<h2 class="s-title">
    Breadcrumbs
</h2>

Breadcrumbs are used as navigational
hierarchies to indicate current location.

</div>

<div id="breadcrumb-example">

<h3 class="s-title">
    Example
</h3>

<div id="breadcrumbs-demo"></div>

</div>

*)

(*** include: breadcrumbs-demo ***)

(**

<div id="breadcrumb-children">

<h3 class="s-title">
    Breadcrumb children
</h3>

<div class="props-table" id="breadcrumb-children-table"></div>

</div>

<div id="breadcrumb-text-children">

<h3 class="s-title">
    Breadcrumb text children
</h3>

<div class="props-table" id="breadcrumb-text-children-table"></div>

</div>

<div id="breadcrumb-link-required-children">

<h3 class="s-title">
    Breadcrumb link required props
</h3>

<div class="props-table" id="breadcrumb-link-required-table"></div>

</div>

<div id="breadcrumb-link-children">

<h3 class="s-title">
    Breadcrumb link children
</h3>

<div class="props-table" id="breadcrumb-link-children-table"></div>

</div>

*)