﻿namespace Fabulosa

module Radio =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    type RadioOptional =
        | Inline
        interface IHTMLProp

    type RadioChildren =
        Text of string

    type Radio = HTMLProps * RadioChildren

    let private isInline (prop: IHTMLProp) =
        match prop with
        | :? RadioOptional as opt ->
            match opt with
            | Inline -> true
        | _ -> false

    let propToClassName (prop: IHTMLProp) =
        match prop with
        | :? RadioOptional as opt ->
            match opt with
            | Inline -> className "form-inline"
        | _ -> prop

    let radio ((opt, Text txt): Radio) =
        let withInline, withoutInline =
            List.partition isInline opt
        Unmerged withInline
        |> addProp (ClassName "form-radio")
        |> map propToClassName
        |> merge
        |> R.label
        <| [ R.input (Type "radio" :> IHTMLProp :: withoutInline)
             R.i [ClassName "form-icon"] []
             R.str txt ]
