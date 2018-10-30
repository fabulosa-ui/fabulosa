namespace Fabulosa

module Checkbox =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    type CheckboxOptional =
        | Inline
        interface IHTMLProp

    type CheckboxChildren =
        Text of string

    type Checkbox = HTMLProps * CheckboxChildren

    let private isInline (prop: IHTMLProp) =
        match prop with
        | :? CheckboxOptional as opt ->
            match opt with
            | Inline -> true
        | _ -> false

    let propToClassName (prop: IHTMLProp) =
        match prop with
        | :? CheckboxOptional as opt ->
            match opt with
            | Inline -> className "form-inline"
        | _ -> prop

    let checkbox ((opt, Text txt): Checkbox) =
        let withInline, withoutInline =
            List.partition isInline opt
        Unmerged withInline
        |> addProp (ClassName "form-checkbox")
        |> map propToClassName
        |> merge
        |> R.label
        <| [ R.input (Type "checkbox" :> IHTMLProp :: withoutInline)
             R.i [ClassName "form-icon"] []
             R.str txt ]
