(*** hide ***)
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"

open Fabulosa
open Fable.Import.React
module R = Fable.Helpers.React
open R.Props

(*** define: form-input-sample ***)
let input =
    Form.Group.ƒ Form.Group.defaults [
        Label.ƒ {
            Label.defaults with Text = "Name"
        }
        Input.ƒ {
            Input.defaults with
                HTMLProps = [Placeholder "Please enter your name"]
        }
    ]
(*** define: form-textarea-sample ***)
let textarea =
    Form.Group.ƒ Form.Group.defaults [
        Label.ƒ {
            Label.defaults with Text = "Description"
        }
        Textarea.ƒ {
            Textarea.defaults with
                HTMLProps = [Placeholder "Please enter a description"]
        } []
    ]
(*** define: form-select-sample ***)
let select =
    Form.Group.ƒ Form.Group.defaults [
        Label.ƒ {
            Label.defaults with Text = "Language"
        }
        Select.ƒ Select.defaults [
            Select.Option.ƒ Select.Option.defaults [R.str "English"]
            Select.Option.ƒ Select.Option.defaults [R.str "Spanish"]
            Select.Option.ƒ Select.Option.defaults [R.str "Assembly"]
        ]
    ]
(**
<h2 class="s-title">
    Forms
</h2>

Forms provide the most common control styles
used in forms, including input, textarea,
select, checkbox, radio and switch.

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
<h3 class="s-title">
    Select
</h3>

The default select component for a form.

<div class="demo">
    <span id="form-select-demo"></span>
</div>
*)

(*** include: form-select-sample ***)