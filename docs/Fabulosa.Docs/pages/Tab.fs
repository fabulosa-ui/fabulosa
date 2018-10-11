module TabPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer
open Microsoft.FSharp.Core

(*** define: tab-default-sample ***)
let search =
    InputGroup.ƒ
      ({ InputGroup.props with
           Inline = true
           AddonRight =
             InputGroup.AddonRight.Button
               ({ Button.props with
                    Kind = Button.Kind.Primary
                    Size = Button.Size.Small },
                [ R.str "Search" ]) },
         [ InputGroup.Child.Input
             ({ Input.props with
                  Size = Input.Size.Small
                  HTMLProps =
                    [ Placeholder "Search documents" ] }) ])

let tab =
    Tab.ƒ
        ({ Tab.props with
             Action = Some
               [ search ] },
         [ (Tab.Item.props,
            [ R.a [] [ R.str "Tab 1" ] ])
           ({ Tab.Item.props with
                Active = true },
            [ R.a [] [ R.str "Tab 2" ] ])
           (Tab.Item.props,
            [ Badge.ƒ
                ({ Badge.props with
                     Badge = 1 },
                 Badge.Child.Anchor
                   ([], [ R.str "Tab 3" ])) ]) ])
(*** hide ***)
let render () =
    tryMount "tab-default-demo" tab
    tryMount "tab-props-table"
        (PropTable.propTable typeof<Tab.Props> Tab.props)
(**

<div id="tab">

<h2 class="s-title">
    Tab
</h2>

Tabs enable quick switch between different views

</div>

<div id="tab-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="tab-props-table"></div>

</div>

<div id="tab-default">

<h3 class="s-title">
    Default
</h3>

A simple tab component with a badge item
and a search action on the right


<div class="demo" id="tab-default-demo"></div>

*)

(*** include: tab-default-sample ***)

(**

</div>

*)