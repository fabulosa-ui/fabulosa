module IndexPage

open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer

(*** define: sample ***)
let fabulousButton =
    Anchor.ƒ
        ( { Anchor.defaults with
              Kind = Button.Kind.Primary
              HTMLProps = [Href "button.html"] },
          [R.str "Fabulosa"] )
(*** hide ***)
let render () =
    tryMount "button-demo" fabulousButton
(**
<h2 class="s-title">
    Getting Started
</h2>

Create a fabulous button

*)

(*** include: sample ***)

(**
<div class="demo" id="button-demo">
</div>
*)
