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
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type Children = string

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.Inline = false
          Props.HTMLProps = [] }

    let private inlineRadio =
        function
        | true -> "form-inline"
        | false -> ""

    let build (radio: T) =
        let props, children = radio
        let containerClass =
            [ "form-radio"
              inlineRadio props.Inline ]
            |> concatStrings
        R.label [ClassName containerClass]
            [ R.input <| props.HTMLProps @ [Type "radio"]
              R.i [ClassName "form-icon"] []
              R.str children ]

    let ƒ = build