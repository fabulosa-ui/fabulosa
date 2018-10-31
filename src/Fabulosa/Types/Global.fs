namespace Fabulosa

[<AutoOpen>]
module Global =

    module R = Fable.Helpers.React
    open R.Props

    type FabulosaText =
        Text of string

    type FabulosaFormFieldSize =
        | Small
        | Large

    type FabulosaFormSize =
        | Size of FabulosaFormFieldSize
        interface IHTMLProp

    type FabulosaFormInline =
        | Inline
        interface IHTMLProp

    type FabulosaActive =
        | Active
        interface IHTMLProp

    type FabulosaValue =
        | Value of int
        interface IHTMLProp
