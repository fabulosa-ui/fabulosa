module TagPage

open Fabulosa
module R = Fable.Helpers.React
open System.Collections
open System.Reflection
open FSharp.Reflection
open Fabulosa
open Fabulosa.Docs
open R.Props

(*** define: tag-color-demo ***)
let tl = Tag.ƒ Tag.defaults [R.str "default label"]
let tlPrimary = Tag.ƒ { Tag.defaults with Color = Tag.Color.Primary} [R.str "primary label"]
let tlSecondary = Tag.ƒ { Tag.defaults with Color = Tag.Color.Secondary} [R.str "secondary label"]
let tlSuccess = Tag.ƒ { Tag.defaults with Color = Tag.Color.Success} [R.str "success label"]
let tlWarning = Tag.ƒ { Tag.defaults with Color = Tag.Color.Warning} [R.str "warning label"]
let tlError = Tag.ƒ { Tag.defaults with Color = Tag.Color.Error} [R.str "error label"]        

(*** define: tag-rounded-demo ***)
let tagRounded =
    R.div [ClassName "tag-container"] [
        R.div [] [ Tag.ƒ { Tag.defaults with Rounded = true } [R.str "default label"] ]
    ]

(*** hide ***)
let tagColor =    
    R.div [ClassName "tag-container"] [
        R.div [] [ tl ]
        R.div [] [ tlPrimary ]
        R.div [] [ tlSecondary ]
        R.div [] [ tlSuccess ]
        R.div [] [ tlWarning ]
        R.div [] [ tlError ]        
    ]

let render () =
    Renderer.tryMount "tag-props-table" (PropTable.propTable typeof<Tag.Props> Tag.defaults)
    Renderer.tryMount "tag-color-demo" tagColor
    Renderer.tryMount "tag-rounded-demo" tagColor
(**
<div id="tags">
    <h2 class="s-title">
        Tags
    </h2>
</div>

Tags are formatted text tags for highlighted, informative information. Tags refere to Spectre.css [Labels](https://picturepan2.github.io/spectre/elements.html#labels)

<div id="props">
    <h3 class="s-title">
        Props
    </h3>
</div>

<div id="tag-props-table"></div>
*)

(**
<div id="color">
    <h3 class="s-title">
        Color
    </h3>
</div>

<div id="tag-color-demo"></div>

*)
(*** include: tag-color-demo ***)


(**
<div id="rounded">
    <h3 class="s-title">
        Rounded
    </h3>
</div>

<div id="tag-rounded-demo"></div>

*)
(*** include: tag-rounded-demo ***)
