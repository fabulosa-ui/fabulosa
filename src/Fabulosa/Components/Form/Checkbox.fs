namespace Fabulosa

[<RequireQualifiedAccess>]
module Checkbox =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type private Inline = bool

    [<RequireQualifiedAccess>]
    type Props =
        { Inline: Inline
          Text: string
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type T = Props

    let inlineCheckbox =
        function
        | true -> "form-inline"
        | false -> ""
        >> ClassName

    let defaults =
        { Props.Inline = false
          Props.Text = "Label"
          Props.HTMLProps = [] }

    let ƒ (checkbox: T) =
        let containerProps =
            [] |> addProps
                [ ClassName "form-checkbox"
                  inlineCheckbox checkbox.Inline ]
        R.label containerProps
            [ R.input <| checkbox.HTMLProps @ [Type "checkbox"]
              R.i [ClassName "form-icon"] []
              R.str checkbox.Text ]

    let render = ƒ