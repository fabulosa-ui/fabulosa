module FormPage

open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer

(*** define: form-checkbox-sample ***)
let checkbox =
    Group.ƒ
        (Group.props,
         [ Group.Child.Label
             (Label.props, "Login Preferences")
           Group.Child.Checkbox
             ({ Checkbox.props with
                 HTMLProps = [Name "remember-me"] },
              "Remember me") ])
(*** define: form-input-sample ***)
let input =
    Group.ƒ
        (Group.props,
         [ Group.Child.Label
             (Label.props, "Name")
           Group.Child.Input
             { Input.props with
                 HTMLProps =
                   [ Placeholder "Please enter your name" ] } ])
(*** define: form-input-group-sample ***)
let inputGroup =
    Group.ƒ
        (Group.props,
         [ Group.Child.Label
             (Label.props, "Email Address")
           Group.Child.InputGroup
             (InputGroup.props,
              [ InputGroup.Child.Input
                  { Input.props with
                      HTMLProps = [ Placeholder "Please enter email address" ] }
                InputGroup.Child.Select
                  (Select.props,
                   [ Select.Child.Option
                       (Select.Option.props, "@gmail.com")
                     Select.Child.Option
                       (Select.Option.props, "@hotmail.com") ]) ])
           Group.Child.Label
               (Label.props, "Website")
           Group.Child.InputGroup
             ({ InputGroup.props with
                  AddonLeft = InputGroup.AddonLeft.Text "https://"                                        
                  AddonRight =
                    InputGroup.AddonRight.Button
                      (Button.props,
                       [ R.str "Save"
                         R.RawText "\n"
                         Icon.ƒ { Icon.props with Kind = Icon.Kind.Check } ]) },
                [ InputGroup.Child.Input
                    ({ Input.props with
                         HTMLProps = [Placeholder "Please enter website address"] }) ]) ])
(*** define: form-radio-sample ***)
let radio =
    Group.ƒ
        (Group.props,
         [ Label.ƒ
             { Label.props with Text = "Gender" }
           Radio.ƒ
             { Radio.props with
                 Text = "Male"
                 HTMLProps = [Name "gender"] }
           Radio.ƒ
             { Radio.props with
                 Text = "Female"
                 HTMLProps = [Name "gender"] } ])
(*** define: form-select-sample ***)
let select =
    Group.ƒ
        (Group.props,
         [ Label.ƒ
             { Label.props with Text = "Language" }
           Select.ƒ
             (Select.props,
              [ Select.Child.Option
                  (Select.Option.props,
                   [ R.str "English" ])
                Select.Child.Option
                  (Select.Option.props,
                    [ R.str "Spanish" ])
                Select.Child.Option
                  (Select.Option.props,
                   [ R.str "Assembly" ]) ]) ])
(*** define: form-sizes-sample ***)
let sizes =
    Group.ƒ
        (Group.props,
         [ Label.ƒ
             { Label.props with
                 Text = "Small"
                 Size = Label.Size.Small }
           Input.ƒ
             { Input.props with
                 HTMLProps =
                    [ Placeholder "Please enter a value" ]
                 Size = Input.Size.Small }
           Label.ƒ
             { Label.props with
                 Text = "Large"
                 Size = Label.Size.Large }
           Select.ƒ
             ({ Select.props with
                  Size = Select.Size.Large },
              [ Select.Child.Option
                  (Select.Option.props,
                     [ R.str "Large" ]) ]) ])
(*** define: form-switch-sample ***)
let switch =
    Group.ƒ
        (Group.props,
         [ Label.ƒ
             { Label.props with
                 Text = "Email Preferences" }
           Switch.ƒ
             { Switch.props with
                 Text = "Send me promotional emails" } ])
(*** define: form-textarea-sample ***)
let textarea =
    Group.ƒ
        (Group.props,
         [ Label.ƒ
             { Label.props with Text = "Description" }
           Textarea.ƒ
             ({ Textarea.props with
                  HTMLProps =
                    [ Placeholder "Please enter a description" ] },
              []) ])
(*** define: form-validation-sample ***)
let validation =
    Group.ƒ
        (Group.props,
         [ Label.ƒ
             { Label.props with
                 Text = "Valid Input" }
           Input.ƒ
             { Input.props with
                 HTMLProps = [ Placeholder "Please enter a value" ] }
           |> Validation.ƒ
            <| Validation.Kind.Success "This input is valid."
           Label.ƒ
             { Label.props with Text = "Invalid Input" }
           Input.ƒ
             { Input.props with
                 HTMLProps = [Placeholder "Please enter a value"] }
           |> Validation.ƒ
            <| Validation.Kind.Error "This input is invalid." ])
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