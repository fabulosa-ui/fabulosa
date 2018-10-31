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

    type FabulosaFormInputSizeHTMLProp =
        | Size of FabulosaFormFieldSize
        interface IHTMLProp