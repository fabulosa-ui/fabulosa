namespace Fabulosa

[<RequireQualifiedAccess>]
module Icon =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Kind =
    | ArrowUp
    | ArrowRight
    | ArrowDown
    | ArrowLeft
    | Upward
    | Forward
    | Downward
    | Back
    | Caret
    | Menu
    | Apps
    | MoreHoriz
    | MoreVert
    | ResizeHoriz
    | ResizeVert
    | Plus
    | Minus
    | Cross
    | Check
    | Stop
    | Shutdown
    | Refresh
    | Search
    | Flag
    | Bookmark
    | Edit
    | Delete
    | Share
    | Download
    | Upload
    | Mail
    | People
    | Message
    | Photo
    | Time
    | Location
    | Link
    | Emoji
    | Loading
    | Unset

    [<RequireQualifiedAccess>]
    type Size =
    | X2
    | X3
    | X4
    | Unset

    [<RequireQualifiedAccess>]
    type Props =
        { Kind: Kind
          Size: Size
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type T = Props

    let defaults =
        { Props.Kind = Kind.Unset
          Props.Size = Size.Unset
          Props.HTMLProps = [] }

    let private kind =
        function
        | Kind.ArrowUp -> "icon-arrow-up"
        | Kind.ArrowRight -> "icon-arrow-right"
        | Kind.ArrowDown -> "icon-arrow-down"
        | Kind.ArrowLeft -> "icon-arrow-left"
        | Kind.Upward -> "icon-upward"
        | Kind.Forward -> "icon-forward"
        | Kind.Downward -> "icon-downward"
        | Kind.Back -> "icon-back"
        | Kind.Caret -> "icon-caret"
        | Kind.Menu -> "icon-menu"
        | Kind.Apps -> "icon-apps"
        | Kind.MoreHoriz -> "icon-more-horiz"
        | Kind.MoreVert -> "icon-more-vert"
        | Kind.ResizeHoriz -> "icon-resize-horiz"
        | Kind.ResizeVert -> "icon-resize-vert"
        | Kind.Plus -> "icon-plus"
        | Kind.Minus -> "icon-minus"
        | Kind.Cross -> "icon-cross"
        | Kind.Check -> "icon-check"
        | Kind.Stop -> "icon-stop"
        | Kind.Shutdown -> "icon-shutdown"
        | Kind.Refresh -> "icon-refresh"
        | Kind.Search -> "icon-search"
        | Kind.Flag -> "icon-flag"
        | Kind.Bookmark -> "icon-bookmark"
        | Kind.Edit -> "icon-edit"
        | Kind.Delete -> "icon-delete"
        | Kind.Share -> "icon-share"
        | Kind.Download -> "icon-download"
        | Kind.Upload -> "icon-upload"
        | Kind.Mail -> "icon-mail"
        | Kind.People -> "icon-people"
        | Kind.Message -> "icon-message"
        | Kind.Photo -> "icon-photo"
        | Kind.Time -> "icon-time"
        | Kind.Location -> "icon-location"
        | Kind.Link -> "icon-link"
        | Kind.Emoji -> "icon-emoji"
        | Kind.Loading -> "loading"
        | Kind.Unset -> ""
        >> ClassName

    let private size =
        function
        | Size.X2 -> "icon-2x"
        | Size.X3 -> "icon-3x"
        | Size.X4 -> "icon-4x"
        | Size.Unset -> ""
        >> ClassName

    let ƒ (icon: T) =
        icon.HTMLProps
        |> addProps
            [ ClassName "icon"
              kind icon.Kind
              size icon.Size ]
        |> R.i <| []

    let render = ƒ
