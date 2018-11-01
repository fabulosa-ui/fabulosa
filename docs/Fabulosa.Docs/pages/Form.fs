module FormPage

module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Fabulosa
open Fabulosa.Group
open Fabulosa.Select
open Fabulosa.Extensions.Fable.Helpers.React.Props
open Renderer

(*** define: form-checkbox-sample ***)
let checkbox =
    group ([],
      [ Label ([], Text "Login Preferences")
        Checkbox ([ Name "remember-me" ], Text "Remember me") ])
(*** define: form-input-sample ***)
let input =
    group ([],
      [ Label ([], Text "Name")
        Input [ Placeholder "Please enter your name" ] ])
(*** hide ***)
open Fabulosa.InputGroup
(*** define: form-input-group-sample ***)
let inputGroup =
    group ([],
      [ Label ([], Text "Email Address")
        InputGroup ([],
          (OptText None,
           [ Input [ Placeholder "Please enter email address" ]
             Select ([],
                [ Option ([], Text "@gmail.com")
                  Option ([], Text "@hotmail.com") ]) ],
           OptButton None))
        Label ([], Text "Website")
        InputGroup ([],
           (OptText (Some "https://"),
            [ Input [ Placeholder "Please enter website address" ] ],
            OptButton (Some ([], [ R.str "Save" ])))) ])
(*** define: form-radio-sample ***)
let radio =
    group ([],
      [ Label ([], Text "Gender")
        Radio ([ Name "gender" ], Text "Male")
        Radio ([ Name "gender"], Text "Female") ])
(*** hide ***)
open Fabulosa.Group
(*** define: form-select-sample ***)
let select =
    group ([],
      [ Label ([], Text "Language")
        Select ([],
          [ Option ([], Text "English")
            Option ([], Text "Spanish")
            Option ([], Text "Assembly") ]) ])
(*** define: form-sizes-sample ***)
let sizes =
    group ([],
      [ Label ([ Size Small ], Text "Small")
        Input ([ Placeholder "Please enter a value"; Size Small ])
        Label ([ Size Large ], Text "Large")
        Select ([ Size Large ],
          [ Option ([], Text "Large") ]) ])
(*** define: form-switch-sample ***)
let switch =
    group ([],
      [ Label ([], Text "Email Preferences")
        Switch ([], Text "Send me promotional emails") ])
(*** define: form-textarea-sample ***)
let textarea =
    group ([],
      [ Label ([], Text "Description")
        Textarea ([ Placeholder "Please enter a description" ], Text "") ])
(*** hide ***)
open Fabulosa.Validation
(*** define: form-validation-sample ***)
let validation =
    group ([],
      [ Label ([], Text "Valid Input")
        Validation ([ Success "This input is valid"],
          Input [ Placeholder "Please enter a value" ])
        Label ([], Text "Invalid Input")
        Validation ([ Error "This input is invalid" ],
          Input [ Placeholder "Please enter a value"]) ])
(*** hide ***)
let render () =
    tryMount "form-input-demo" input
    tryMount "form-select-demo" select
    tryMount "form-textarea-demo" textarea
    tryMount "form-radio-demo" radio
    tryMount "form-checkbox-demo" checkbox
    tryMount "form-switch-demo" switch
    tryMount "form-sizes-demo" sizes
    tryMount "form-validation-demo" validation
    tryMount "form-input-group-demo" inputGroup
(**

<div id="forms">

<h2 class="s-title">
    Forms
</h2>

Forms provide the most common control styles
used in forms, including input, textarea,
select, checkbox, radio and switch.

</div>

<div id="checkbox">

<h3 class="s-title">
    Checkbox
</h3>

The default checkbox component for a form.

<div class="demo">
    <span id="form-checkbox-demo"></span>
</div>

*)

(*** include: form-checkbox-sample ***)

(**

</div>

<div id="input">

<h3 class="s-title">
    Input
</h3>

The default input component for a form.

<div class="demo">
    <span id="form-input-demo"></span>
</div>

*)

(*** include: form-input-sample ***)

(**

</div>

<div id="inputgroup">

<h3 class="s-title">
    Input Group
</h3>

Component for grouping different kinds of input.

<div class="demo">
    <span id="form-input-group-demo"></span>
</div>

*)

(*** include: form-input-group-sample ***)

(**

</div>

<div id="radio">

<h3 class="s-title">
    Radio
</h3>

The default radio component for a form.

<div class="demo">
    <span id="form-radio-demo"></span>
</div>

*)

(*** include: form-radio-sample ***)

(**

</div>

<div id="select">

<h3 class="s-title">
    Select
</h3>

The default select component for a form.

<div class="demo">
    <span id="form-select-demo"></span>
</div>

*)

(*** include: form-select-sample ***)

(**

</div>

<div id="sizes">

<h3 class="s-title">
    Sizes
</h3>

Input, select and label components can be Small or Large.

<div class="demo">
    <span id="form-sizes-demo"></span>
</div>

*)

(*** include: form-sizes-sample ***)

(**

</div>

<div id="switch">

<h3 class="s-title">
    Switch
</h3>

A switch component for forms.

<div class="demo">
    <span id="form-switch-demo"></span>
</div>

*)

(*** include: form-switch-sample ***)

(**

</div>

<div id="textarea">

<h3 class="s-title">
    Textarea
</h3>

The default textarea component for a form.

<div class="demo">
    <span id="form-textarea-demo"></span>
</div>

*)

(*** include: form-textarea-sample ***)

(**

</div>

<div id="validation">

<h3 class="s-title">
    Validation
</h3>

Validation component for forms.

<div class="demo">
    <span id="form-validation-demo"></span>
</div>
*)

(*** include: form-validation-sample ***)

(**

</div>

*)