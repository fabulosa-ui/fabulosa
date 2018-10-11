namespace Fabulosa

[<RequireQualifiedAccess>]
module Tag =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fabulosa.Extensions

    [<RequireQualifiedAccess>]
    type Color =
    | Default
    | Primary
    | Secondary
    | Success
    | Warning
    | Error

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          Rounded: bool
          Color: Color }

    [<RequireQualifiedAccess>]
    type Children = string

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.HTMLProps = []
          Props.Rounded = false
          Props.Color = Color.Default }

    let private color =
        function
        | Color.Default -> ""
        | Color.Primary -> "label-primary"
        | Color.Secondary -> "label-secondary"
        | Color.Success -> "label-success"
        | Color.Warning -> "label-warning"
        | Color.Error -> "label-error"
        >> ClassName

    let private rounded =
        function
        | true -> "label-rounded"
        | false -> ""
        >> ClassName

    let build (tag: T) =
        let props, children = tag
        props.HTMLProps
        |> addProps
            [ ClassName "label"
              color props.Color
              rounded props.Rounded ]
        |> R.span <| [ R.str children ]

    let ƒ = build