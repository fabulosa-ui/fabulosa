module PanelPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer
open Microsoft.FSharp.Core

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
    [ InputGroup.ƒ
        ({ InputGroup.props with
             AddonRight =
               InputGroup.AddonRight.Button
                 ({ Button.props with
                      Kind = Button.Kind.Primary },
                  [ R.str "Send" ]) },
           [ InputGroup.Child.Input
               ({ Input.props with
                    HTMLProps =
                       [ Placeholder "Say Hello!" ] }) ]) ]

(*** define: panel-default-sample ***)
let panel =
    Panel.ƒ
        (Panel.props,
         { Header = Some header
           Nav = None
           Body = Some body
           Footer = Some footer })
(*** hide ***)
let render () =
    tryMount "panel-default-demo" (R.div [ Style [ Width "50%" ] ] [ panel ])
    tryMount "panel-props-table"
        (PropTable.propTable typeof<Panel.Props> Panel.props)
(**

<div id="panel">

<h2 class="s-title">
    Panel
</h2>

Panels are flexible view container with
auto-expand content section

</div>

<div id="panel-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="panel-props-table"></div>

</div>

<div id="panel-default">

<h3 class="s-title">
    Default
</h3>

A simple panel component with a header, body, and footer

<div class="demo" id="panel-default-demo"></div>

*)

(*** include: panel-default-sample ***)

(**

</div>

*)