﻿module AvatarPage

open Fabulosa.Avatar
open Fabulosa.Docs
open Fable.Import.React
module R = Fable.Helpers.React
open Renderer

(*** define: avatar-initial-sample ***)
let def = avatar ([], Initial "FA")
(*** define: avatar-source-sample ***)
let source = avatar ([], Url "Assets/avatar-1.png")
(*** define: avatar-sizes-sample ***)
let extraSmall = avatar ([ Size ExtraSmall ], Initial "FA")
(*** hide ***)
let small = avatar ([ Size Small ], Initial "FA")

let medium = avatar ([], Initial "FA")

let large = avatar ([ Size Large ], Initial "FA")

let extraLarge = avatar ([ Size ExtraLarge ], Initial "FA")
(*** define: avatar-presence-sample ***)
let presence = avatar ([ Presence Online ], Url "Assets/avatar-1.png")
(*** hide ***)
let render () =
    tryMount "avatar-initial-demo" def
    tryMount "avatar-source-demo" source
    tryMount "avatar-xs-demo" extraSmall
    tryMount "avatar-sm-demo" small
    tryMount "avatar-md-demo" medium
    tryMount "avatar-lg-demo" large
    tryMount "avatar-xl-demo" extraLarge
    tryMount "avatar-presence-demo" presence
    tryMount "avatar-params-table"
        (PropTable.paramTable
            (Some typeof<AvatarOptional>)
            None
            (Some typeof<AvatarChildren>))
(**

<div id="avatars">

<h2 class="s-title">Avatars</h2>

Avatars are user profile pictures.

#### Parameters

<div class="props-table" id="avatar-params-table"></div>

#### Initial

Avatars can have an Initial prop with name initials instead of images.

<div class="demo" id="avatar-initial-demo"></div>

*)
(*** include: avatar-initial-sample ***)
(**

#### Source

Avatars can also have a source image

<div class="demo" id="avatar-source-demo"></div>

*)
(*** include: avatar-source-sample ***)
(**

#### Sizes

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

#### Presence

Avatar can have a presence indicator.

<div class="demo">
    <span id="avatar-presence-demo"></span>
</div>

*)
(*** include: avatar-presence-sample ***)
(**

</div>

*)