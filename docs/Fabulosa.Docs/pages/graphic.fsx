(*** hide ***)
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"

open Fabulosa
open Fable.Import.React
module R = Fable.Helpers.React

(*** define: avatar-sample ***)
let avatar =
    Avatar.ƒ {
        Avatar.defaults with
            Initial = "FA"
    }
(**
<div id="avatar">

<h2 class="s-title">
    Avatars
</h2>

Avatars are user profile pictures.

<div class="demo" id="avatar-demo"></div>

*)

(*** include: avatar-sample ***)

(**
</div>
*)
