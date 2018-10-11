namespace Fabulosa

open Fable.Import.React
[<RequireQualifiedAccess>]
module Chip =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    module Remove =

        [<RequireQualifiedAccess>]
        type Props =
            { OnRemove: MouseEvent -> unit }

        [<RequireQualifiedAccess>]
        type T = Props

        let ƒ (remove: T) =
            ({ Anchor.props with
                 HTMLProps =
                   [ ClassName "btn btn-clear"
                     Role "button"
                     OnClick remove.OnRemove ] }, [])
            |> Anchor.ƒ

    module ChipAvatar =
        
        let build (avatar: Avatar.T) =
            Avatar.ƒ
                { avatar with
                    Size = Avatar.Size.Small }

        let ƒ = build

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          OnRemove: (MouseEvent -> unit) option }

    [<RequireQualifiedAccess>]
    type Children<'Avatar> =
        { Text: string
          Avatar: 'Avatar option }

    [<RequireQualifiedAccess>]
    type T<'Avatar> =
        Props * Children<'Avatar>

    let props =
        { Props.HTMLProps = []
          Props.OnRemove = None }

    let children =
        { Children.Text = ""
          Children.Avatar = None }

    let private remove =
        function
        | Some fn -> Remove.ƒ { OnRemove = fn }
        | None -> R.ofOption None

    let private avatar avatarƒ =
        function
        | Some avatar ->
            avatarƒ avatar
        | None -> R.ofOption None

    let build avatarƒ (chip: T<'Avatar>) =
        let props, children = chip
        props.HTMLProps
        |> addProp (ClassName "chip")
        |> R.div <|
        [ avatar avatarƒ children.Avatar
          R.str children.Text
          remove props.OnRemove ]

    let ƒ = build ChipAvatar.ƒ