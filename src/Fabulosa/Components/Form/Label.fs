namespace Fabulosa

[<RequireQualifiedAccess>]
module Label =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Size =
    | Small
    | Large
    | Unset

    [<RequireQualifiedAccess>]
    type Props =
        { Size: Size
          Text: string
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type T = Props

    let defaults =
        { Props.Size = Size.Unset
          Props.Text = "Checkbox"
          Props.HTMLProps = [] }

    let private size =
        function
        | Size.Small -> "label-sm"
        | Size.Large -> "label-lg"
        | Size.Unset -> ""

    let ƒ (label: T) =
        label.HTMLProps
        |> addProps
            [ ClassName "form-label"
              ClassName <| size label.Size ]
        |> R.label
        <| [R.str label.Text]

    let render = ƒ
    