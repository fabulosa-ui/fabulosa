namespace Fabulosa

[<RequireQualifiedAccess>]
module Radio =

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

    let defaults =
        { Props.Inline = false
          Props.Text = "Label"
          Props.HTMLProps = [] }

    let private inlineRadio =
        function
        | true -> "form-inline"
        | false -> ""

    let ƒ (radio: T) =
        let containerClass =
            [ "form-radio"
              inlineRadio radio.Inline ]
            |> concatStrings
        R.label [ClassName containerClass]
            [ R.input <| radio.HTMLProps @ [Type "radio"]
              R.i [ClassName "form-icon"] []
              R.str radio.Text ]

    let render = ƒ