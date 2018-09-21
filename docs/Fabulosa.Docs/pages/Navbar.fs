module NavbarPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open Fable.Import.React
open Renderer

(*** define: navbar-sample ***)
let navbar =
    Navbar.ƒ
        ( Navbar.defaults,
          [ Navbar.Child.Section
              ( Navbar.defaults,
                [ Anchor.ƒ
                    ( { Anchor.defaults with
                          Kind = Button.Kind.Link },
                      [ R.str "Left 1" ] )
                  Anchor.ƒ
                    ( { Anchor.defaults with
                          Kind = Button.Kind.Link },
                      [ R.str "Left 2" ] ) ] )
            Navbar.Child.Center
              ( Navbar.defaults,
                [ Anchor.ƒ
                    ( { Anchor.defaults with
                          Kind = Button.Kind.Link },
                      [ R.str "Center" ] ) ] )
            Navbar.Child.Section
              ( Navbar.defaults,
                [ Anchor.ƒ
                    ( Anchor.defaults,
                      [ R.str "Right" ] ) ] ) ] )
(*** hide ***)
let render () =
    tryMount "navbar-demo" navbar
    tryMount "navbar-props-table" (PropTable.propTable typeof<Navbar.Props> Navbar.defaults)
(**

<div id="navbar">

<h2 class="s-title">
    Navbar
</h2>

The navbar component can include
logo brand, nav links and buttons,
search box or any combination of
those elements. Each section with
the navbar-section class will be
evenly distributed in the container.

</div>

<div id="navbar-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="navbar-props-table"></div>

</div>

<div id="default">

<h3 class="s-title">
    Default
</h3>

A simple navbar

<div class="demo" id="navbar-demo"></div>

*)

(*** include: navbar-sample ***)

(**

</div>

*)