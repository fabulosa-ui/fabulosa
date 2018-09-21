module FormPage

open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer

(*** define: form-checkbox-sample ***)
let checkbox =
    Form.Group.ƒ
        ( Form.Group.defaults,
          [ Label.ƒ
              { Label.defaults with Text = "Login Preferences" }
            Checkbox.ƒ
              { Checkbox.defaults with
                  Text = "Remember Me"
                  HTMLProps = [Name "remember-me"] } ] )
(*** define: form-input-sample ***)
let input =
    Form.Group.ƒ
        ( Form.Group.defaults,
          [ Label.ƒ
              { Label.defaults with Text = "Name" }
            Input.ƒ
              { Input.defaults with
                  HTMLProps = [ Placeholder "Please enter your name" ] } ] )
(*** define: form-input-group-sample ***)
let inputGroup =
    Form.Group.ƒ
        ( Form.Group.defaults,
          [ Label.ƒ
              { Label.defaults with Text = "Email Address" }
            InputGroup.ƒ
              ( InputGroup.defaults,
                [ Input.ƒ
                    { Input.defaults with
                        HTMLProps = [ Placeholder "Please enter email address" ] }
                  Select.ƒ
                    ( Select.defaults,
                      [ Select.Child.Option
                          ( Select.Option.defaults, [ R.str "@gmail.com" ] )
                        Select.Child.Option
                          ( Select.Option.defaults, [ R.str "@hotmail.com" ] ) ] ) ] )
            Label.ƒ { Label.defaults with Text = "Website" }
            InputGroup.ƒ
                ( { InputGroup.defaults with
                      AddonLeft = InputGroup.AddonLeft.Text "https://"                                        
                      AddonRight = InputGroup.AddonRight.Button
                        ( Button.defaults,
                            [ R.str "Save"
                              R.RawText "\n"
                              Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Check } ] ) },
                  [ Input.ƒ
                      ( { Input.defaults with
                            HTMLProps = [Placeholder "Please enter website address"] } ) ] ) ] )
(*** define: form-radio-sample ***)
let radio =
    Form.Group.ƒ
        ( Form.Group.defaults,
          [ Label.ƒ
              { Label.defaults with Text = "Gender" }
            Radio.ƒ
              { Radio.defaults with
                  Text = "Male"
                  HTMLProps = [Name "gender"] }
            Radio.ƒ
              { Radio.defaults with
                  Text = "Female"
                  HTMLProps = [Name "gender"] } ] )
(*** define: form-select-sample ***)
let select =
    Form.Group.ƒ
        ( Form.Group.defaults,
          [ Label.ƒ
              { Label.defaults with Text = "Language" }
            Select.ƒ
              ( Select.defaults,
                [ Select.Child.Option
                    ( Select.Option.defaults,
                      [ R.str "English" ] )
                  Select.Child.Option
                    ( Select.Option.defaults,
                      [ R.str "Spanish" ] )
                  Select.Child.Option
                    ( Select.Option.defaults,
                      [ R.str "Assembly" ] ) ] ) ] )
(*** define: form-sizes-sample ***)
let sizes =
    Form.Group.ƒ
        ( Form.Group.defaults,
          [ Label.ƒ
              { Label.defaults with
                  Text = "Small"
                  Size = Label.Size.Small }
            Input.ƒ
              { Input.defaults with
                  HTMLProps = [Placeholder "Please enter a value"]
                  Size = Input.Size.Small }
            Label.ƒ
              { Label.defaults with
                  Text = "Large"
                  Size = Label.Size.Large }
            Select.ƒ
              ( { Select.defaults with
                    Size = Select.Size.Large },
                [ Select.Child.Option
                    ( Select.Option.defaults,
                      [ R.str "Large" ] ) ] ) ] )
(*** define: form-switch-sample ***)
let switch =
    Form.Group.ƒ
        ( Form.Group.defaults,
          [ Label.ƒ
              { Label.defaults with Text = "Email Preferences" }
            Switch.ƒ
              { Switch.defaults with
                  Text = "Send me promotional emails" } ] )
(*** define: form-textarea-sample ***)
let textarea =
    Form.Group.ƒ
        ( Form.Group.defaults,
          [ Label.ƒ
              { Label.defaults with Text = "Description" }
            Textarea.ƒ
              ( { Textarea.defaults with
                    HTMLProps = [Placeholder "Please enter a description"] },
                [] ) ] )
(*** define: form-validation-sample ***)
let validation =
    Form.Group.ƒ
        ( Form.Group.defaults,
          [ Label.ƒ
              { Label.defaults with Text = "Valid Input" }
            Input.ƒ
              { Input.defaults with
                  HTMLProps = [ Placeholder "Please enter a value" ] }
            |> Validation.ƒ <| Validation.Kind.Success "This input is valid."
            Label.ƒ
              { Label.defaults with Text = "Invalid Input" }
            Input.ƒ
              { Input.defaults with
                  HTMLProps = [Placeholder "Please enter a value"] }
            |> Validation.ƒ <| Validation.Kind.Error "This input is invalid." ] )
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