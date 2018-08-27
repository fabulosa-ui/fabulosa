(*** hide ***)
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"

open Fabulosa
open Fable.Import.React
module R = Fable.Helpers.React

(*** define: avatar-initial-sample ***)
let avatar =
    Avatar.ƒ {
        Avatar.defaults with
            Initial = "FA"
    }
(*** define: avatar-sizes-sample ***)
let extraSmall =
    Avatar.ƒ {
        Avatar.defaults with
            Initial = "FA"
            Size = Avatar.Size.ExtraSmall
    }
(*** define: avatar-kinds-sample ***)
let icon =
    Avatar.ƒ {
        Avatar.defaults with
            Initial = "FA"
            Kind = Avatar.Kind.Icon "assets/avatar-1.png"
    }
let presence =
    Avatar.ƒ {
        Avatar.defaults with
            Initial = "FA"
            Kind = Avatar.Kind.Presence Avatar.Presence.Online
    }
(**
<div id="avatars">

<h2 class="s-title">
    Avatars
</h2>

Avatars are user profile pictures.

</div>

<div id="avatar-initial">

<h3 class="s-title">
    Initial
</h3>

Avatars can have an Initial prop with name initials instead of images.

<div class="demo" id="avatar-initial-demo"></div>

*)

(*** include: avatar-initial-sample ***)

(**

</div>

<div id="avatar-sizes">

<h3 class="s-title">
    Sizes
</h3>

Avatar can be ExtraSmall, Small, Medium, Large and ExtraLarge.

<div class="demo">
    <span id="avatar-xs-demo"></span>
    <span id="avatar-sm-demo"></span>
    <span id="avatar-md-demo"></span>
    <span id="avatar-lg-demo"></span>
    <span id="avatar-xl-demo"></span>
</div>

*)

(*** include: avatar-sizes-sample ***)

(**

</div>

<div id="avatar-kinds">

<h3 class="s-title">
    Kind
</h3>

Avatar can have kinds of Icon or Presence.

<div class="demo">
    <span id="avatar-icon-demo"></span>
    <span id="avatar-presence-demo"></span>
</div>

*)

(*** include: avatar-kinds-sample ***)

(**
</div>
*)