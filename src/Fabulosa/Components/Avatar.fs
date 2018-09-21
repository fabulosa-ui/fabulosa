namespace Fabulosa

[<RequireQualifiedAccess>]
module Avatar =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

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
    type Props =
        { Kind: Kind
          Initial: Initial
          Size: Size
          Source: Source
          HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type T = Props

    let defaults =
        { Props.Kind = Kind.Unset
          Props.Initial = ""
          Props.Size = Size.Unset
          Props.Source = ""
          Props.HTMLProps = [] }

    let private size =
        function
        | Size.ExtraSmall -> "avatar-xs"
        | Size.Small -> "avatar-sm"
        | Size.Medium -> "avatar-md"
        | Size.Large -> "avatar-lg"
        | Size.ExtraLarge -> "avatar-xl"
        | Size.Unset -> "avatar-md"
        >> ClassName

    let private presence =
        function
        | Presence.Away -> "away"
        | Presence.Busy -> "busy"
        | Presence.Online -> "online"
        | Presence.Unset -> ""
        >> ClassName

    let private kind =
        function
        | Kind.Icon source ->
            R.img
                [ ClassName "avatar-icon"
                  Src source ]
            |> Some
        | Kind.Presence p ->
            R.i
                [ ClassName "avatar-presence"
                  presence p ] []
            |> Some
        | Kind.Unset -> None

    let ƒ (avatar: T) =
        let containerProps =
            addProps
                [ ClassName "avatar"
                  size avatar.Size ] avatar.HTMLProps
                  @ [ Data ("initial", avatar.Initial) ]
        R.figure containerProps
            [ ( if avatar.Source <> ""
                then R.img [ Src avatar.Source ]
                else R.ofOption None )
              kind avatar.Kind |> R.ofOption ]
              
    let render = ƒ