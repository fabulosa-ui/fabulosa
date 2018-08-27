namespace Fabulosa

[<RequireQualifiedAccess>]
module Avatar =

    module R = Fable.Helpers.React
    open R.Props
    open ClassNames

    [<RequireQualifiedAccess>]
    type HTMLProps = IHTMLProp list

    [<RequireQualifiedAccess>]
    type Size =
    | ExtraSmall
    | Small
    | Medium
    | Large
    | ExtraLarge
    | Unset

    [<RequireQualifiedAccess>]
    type Initial = string

    [<RequireQualifiedAccess>]
    type Presence =
    | Online
    | Busy
    | Away
    | Unset

    [<RequireQualifiedAccess>]
    type Kind =
    | Icon of string
    | Presence of Presence
    | Unset

    [<RequireQualifiedAccess>]
    type Source = string

    [<RequireQualifiedAccess>]
    type Props = {
        Kind: Kind
        Initial: Initial
        Size: Size
        Source: Source
        HTMLProps: HTMLProps
    }

    let defaults = {
        Props.Kind = Kind.Unset
        Props.Initial = ""
        Props.Size = Size.Unset
        Props.Source = ""
        Props.HTMLProps = []
    }

    let size =
        function
        | Size.ExtraSmall -> "avatar-xs"
        | Size.Small -> "avatar-sm"
        | Size.Medium -> "avatar-md"
        | Size.Large -> "avatar-lg"
        | Size.ExtraLarge -> "avatar-xl"
        | Size.Unset -> "avatar-md"

    let presence =
        function
        | Presence.Away -> "away"
        | Presence.Busy -> "busy"
        | Presence.Online -> "online"
        | Presence.Unset -> ""

    let kind =
        function
        | Kind.Icon source ->
            Some <| R.img
                [ ClassName "avatar-icon"
                  Src source ]
        | Kind.Presence p ->
            Some <| R.i
                [R.classList [
                    "avatar-presence", true
                    presence p, true
                ]] []
        | Kind.Unset -> None


    let ƒ (props: Props) =
        let containerProps =
            combineProps
                [ "avatar"
                  size props.Size ] props.HTMLProps
                  @ [Data ("initial", props.Initial)]
        R.figure containerProps
            [ (if props.Source <> "" then R.img [Src props.Source] else R.ofOption None)
              kind props.Kind |> R.ofOption ]
              
    let render = ƒ