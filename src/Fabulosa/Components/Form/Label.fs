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
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type Children = string

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.Size = Size.Unset
          Props.HTMLProps = [] }

    let private size =
        function
        | Size.Small -> "label-sm"
        | Size.Large -> "label-lg"
        | Size.Unset -> ""

    let build (label: T) =
        let props, children = label
        props.HTMLProps
        |> addProps
            [ ClassName "form-label"
              ClassName <| size props.Size ]
        |> R.label
        <| [ R.str children ]

    let ƒ = build
    