module TablePage

open Fabulosa
open Fabulosa.Table
module R = Fable.Helpers.React
open Fable.Import.React
open Renderer

let bolso =
    [ Column ([], [ R.str "Jair" ])
      Column ([], [ R.str "Bolsonaro" ])
      Column ([], [ R.str "melhorjair@procanada.com" ]) ]
let michel =
    [ Column ([], [ R.str "Michel" ])
      Column ([], [ R.str "Temer" ])
      Column ([], [ R.str "temquemanterissoai@vampiro.com" ]) ]
(*** define: table-columns-sample ***)
let donald =
    [ Column ([], [ R.str "Donald" ])
      Column ([], [ R.str "Trump" ])
      Column ([], [ R.str "wall@mexico.com" ]) ]

let titles =
    [ TitleColumn ([], [ R.str "First Name" ])
      TitleColumn ([], [ R.str "Last Name" ])
      TitleColumn ([], [ R.str "Email" ]) ]
(*** define: table-row-active-sample ***)
let active = Row ([ Active ], bolso)
(*** define: table-head-sample ***)
let head = Head ([], [ Row ([], titles) ])
(*** define: table-body-sample ***)
let body =
    Body ([],
       [ active
         Row ([], michel)
         Row ([], donald) ])
(*** define: table-default-sample ***)
let def = table ([], [head; body])
(*** define: table-striped-sample ***)
let striped = table ([ Kind Striped ], [ head; body ])
(*** define: table-hover-sample ***)
let hover = table ([ Kind Hover ], [ head; body ])
(*** hide ***)
let render () =
    tryMount "table-default-demo" def
    tryMount "table-striped-demo" striped
    tryMount "table-hover-demo" hover
    //tryMount "table-props-table"
    //    (PropTable.propTable typeof<Table.Props> Table.props)
    //tryMount "table-row-props-table"
        //(PropTable.propTable typeof<Table.Row.Props> Table.Row.props)
(**

<div id="table">

<h2 class="s-title">
    Table
</h2>

Tables include default styles
for tables and data sets.

</div>

<div id="table-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="table-props-table"></div>

</div>

<div id="table-default">

<h3 class="s-title">
    Default
</h3>

The default table

<div class="demo" id="table-default-demo"></div>

*)

(*** include: table-default-sample ***)

(**

</div>

<div id="table-striped">

<h3 class="s-title">
    Striped
</h3>

The striped table

<div class="demo" id="table-striped-demo"></div>

*)

(*** include: table-striped-sample ***)

(**

</div>

<div id="table-hover">

<h3 class="s-title">
    Hover
</h3>

The hover table

<div class="demo" id="table-hover-demo"></div>

*)

(*** include: table-hover-sample ***)

(**

</div>

<div id="table-head">

<h3 class="s-title">
    Head
</h3>

The table head

*)

(*** include: table-head-sample ***)

(**

</div>

<div id="table-head">

<h3 class="s-title">
    Body
</h3>

The table body

*)

(*** include: table-body-sample ***)

(**

</div>

<div id="table-row">

<h3 class="s-title">
    Row
</h3>

The table row

</div>

<div id="table-row-props">

<h3 class="s-title">
    Row Props
</h3>

<div class="props-table" id="table-row-props-table"></div>

</div>

<div id="table-row-default">

<h3 class="s-title">
    Rows can be acivated 
</h3>

*)

(*** include: table-row-active-sample ***)

(**

</div>

<div id="table-column">

<h3 class="s-title">
    Columns
</h3>

Columns can be title columns or default

*)

(*** include: table-columns-sample ***)

(**

</div>

*)