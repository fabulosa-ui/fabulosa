module CardPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer

(*** define: card-default-sample ***)
let card =
    Card.ƒ
        Card.defaults
        { Header =
            { Title = "Apple" 
              SubTitle = "Hardware and software" }
          Body =
            [ R.p [] [ R.str "To make a contribution to
                the world by making tools for the mind
                that advance humankind." ] ]
          Footer =
            [ Button.ƒ
                ( Button.defaults, [ R.str "Purchase" ] ) ]
          Image =
            { Media.Image.defaults with
                HTMLProps = [ Src "assets/macos-sierra-2.jpg" ] } }
(*** hide ***)
let demo = R.div [Style [MaxWidth "50%"]] [card]
let render () =
    tryMount "card-default-demo" demo
    tryMount "card-props-table" (PropTable.propTable typeof<Card.Props> Card.defaults)
(**

<div id="cards">

<h2 class="s-title">
    Cards
</h2>

Cards are flexible content containers.

</div>

<div id="card-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="card-props-table"></div>

</div>

<div id="card-default">

<h3 class="s-title">
    Default
</h3>

The default card

<div class="demo" id="card-default-demo"></div>

*)

(*** include: card-default-sample ***)

(**

</div>

*)