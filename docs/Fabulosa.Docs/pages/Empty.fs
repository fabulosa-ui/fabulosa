module EmptyPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer
open Microsoft.FSharp.Core

(*** define: empty-default-sample ***)
let empty =
    Empty.ƒ
        Empty.defaults
        { Icon = { Icon.defaults with Kind = Icon.Kind.Mail }
          Title = "You have no new messages" 
          SubTitle = "Click the button to start a conversation"
          Action = [ Button.ƒ ( Button.defaults, [R.str "Send a message"] ) ] }
(*** hide ***)
let render () =
    tryMount "empty-default-demo" empty
    tryMount "empty-props-table" (PropTable.propTable typeof<Empty.Props> Empty.defaults)
(**

<div id="empty">

<h2 class="s-title">
    Empty states
</h2>

Empty states/blank slates are commonly used
as placeholders for first time use, empty
data and error screens.

</div>

<div id="empty-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="empty-props-table"></div>

</div>

<div id="empty-default">

<h3 class="s-title">
    Default
</h3>

The empty state component. The icon is size
is always 3x bigger. Actions can be any
combination of React Elements.

<div class="demo" id="empty-default-demo"></div>

*)

(*** include: empty-default-sample ***)

(**

</div>

*)