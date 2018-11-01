module PaginationPage

open Fabulosa
open Fabulosa.Pagination
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Fable.Import.JS
open Renderer
open Microsoft.FSharp.Core

(*** define: pagination-default-sample ***)
let pagCh = OnPageChanged (fun page -> console.log page)

let pages =
    seq { 1 .. 9 }
    |> Seq.map
         (fun n ->
            if n = 5 then Item ([ Active ], (pagCh, Value n), Text (string n))
            else Item ([], (pagCh, Value n), Text (string n)))
    |> Seq.toList

let def =
    pagination
        ([],
         Item ([], (pagCh, Value -2), Text "Prev")
         :: pages @ [ Item ([], (pagCh, Value -1), Text "Next") ])
(*** hide ***)
let render () =
    tryMount "pagination-default-demo" def
    //tryMount "pagination-props-table"
    //    (PropTable.propTable typeof<Pagination.Props> Pagination.props)
    //tryMount "page-item-props-table"
        //(PropTable.propTable typeof<Pagination.Item.Props> Pagination.Item.props)
(**

<div id="pagination">

<h2 class="s-title">
    Pagination
</h2>

The pagination component is fully customizable,
with props for active, disabled, and a callback
that gives you the clicked page

</div>

<div id="pagination-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="pagination-props-table"></div>

</div>

<div id="pagination-default">

<h3 class="s-title">
    Default
</h3>

A simple pagination component that shows all pages.
If you want collapsed pages, just add disabled items
you can use the disabled prop.

<div class="demo" id="pagination-default-demo"></div>

*)

(*** include: pagination-default-sample ***)

(**

</div>

<div id="page-item">

<h2 class="s-title">
    Page Item
</h2>

Page items are child elements for pagination

</div>

<div id="page-item-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="page-item-props-table"></div>

</div>

*)