(*** hide ***)
module PanelPage
#r "Facades/netstandard"
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"


open Fabulosa
open Fabulosa.Panel
open Fabulosa.Docs
open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer
open Microsoft.FSharp.Core
open Fabulosa.InputGroup

let header =
    [ R.str "Comments" ]
    
let body =
    [ R.div []
    [ R.p [] [ R.str
          "Earth's Mightiest Heroes joined
          forces to take on threats that were
          too big for any one hero to tackle..." ]
      R.p [] [ R.str
          "Earth's Mightiest Heroes joined
          forces to take on threats that were
          too big for any one hero to tackle..." ]
      R.p [] [ R.str
          "Earth's Mightiest Heroes joined
          forces to take on threats that were
          too big for any one hero to tackle..." ]
      R.p [] [ R.str
          "Earth's Mightiest Heroes joined
          forces to take on threats that were
          too big for any one hero to tackle..." ]
      R.p [] [ R.str
          "Earth's Mightiest Heroes joined
          forces to take on threats that were
          too big for any one hero to tackle..." ] ] ]

let footer =
    [ inputGroup ([],
        (OptText None,
         [ Input [ P.Placeholder "Say Hello!" ] ],
         OptButton (Some([ Kind Primary ], [ R.str "Send" ])))) ]

(*** define: panel-default-sample ***)
let def =
    panel ([],
      [ Header ([], [ Title "Comments" ])
        Body ([], body)
        Footer ([], footer) ])
(*** hide ***)
let render () =
    tryMount "panel-default-demo" (R.div [ P.Style [ P.CSSProp.Width "50%" ] ] [ def ])
    tryMount "panel-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<PanelChild>))
(**

<div id="panel">

<h2 class="s-title">Panel</h2>

Panels are flexible view container with
auto-expand content section

#### Parameters

<div class="props-table" id="panel-params-table"></div>

#### Example

A simple panel component with a header, body, and footer

<div class="demo" id="panel-default-demo"></div>

*)
(*** include: panel-default-sample ***)
(**

</div>

*)