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
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type Children = string

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let inlineCheckbox =
        function
        | true -> "form-inline"
        | false -> ""
        >> ClassName

    let props =
        { Props.Inline = false
          Props.HTMLProps = [] }

    let build (checkbox: T) =
        let props, children = checkbox
        let containerProps =
            [] |> addProps
                [ ClassName "form-checkbox"
                  inlineCheckbox props.Inline ]
        R.label containerProps
            [ R.input <| props.HTMLProps @ [Type "checkbox"]
              R.i [ClassName "form-icon"] []
              R.str children ]

    let ƒ = build