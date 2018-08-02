namespace Fabulosa

[<RequireQualifiedAccess>]
module Icon =

    open ClassNames
    module R = Fable.Helpers.React

    type Type =
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

    type Size =
    | X2
    | X3
    | X4

    type Props =
    | Type of Type
    | Size of Size

    let propToClass =
        function
        | Type ArrowUp -> "icon-arrow-up"
        | Type ArrowRight -> "icon-arrow-right"
        | Type ArrowDown -> "icon-arrow-down"
        | Type ArrowLeft -> "icon-arrow-left"
        | Type Upward -> "icon-upward"
        | Type Forward -> "icon-forward"
        | Type Downward -> "icon-downward"
        | Type Back -> "icon-back"
        | Type Caret -> "icon-caret"
        | Type Menu -> "icon-menu"
        | Type Apps -> "icon-apps"
        | Type MoreHoriz -> "icon-more-horiz"
        | Type MoreVert -> "icon-more-vert"
        | Type ResizeHoriz -> "icon-resize-horiz"
        | Type ResizeVert -> "icon-resize-vert"
        | Type Plus -> "icon-plus"
        | Type Minus -> "icon-minus"
        | Type Cross -> "icon-cross"
        | Type Check -> "icon-check"
        | Type Stop -> "icon-stop"
        | Type Shutdown -> "icon-shutdown"
        | Type Refresh -> "icon-refresh"
        | Type Search -> "icon-search"
        | Type Flag -> "icon-flag"
        | Type Bookmark -> "icon-bookmark"
        | Type Edit -> "icon-edit"
        | Type Delete -> "icon-delete"
        | Type Share -> "icon-share"
        | Type Download -> "icon-download"
        | Type Upload -> "icon-upload"
        | Type Mail -> "icon-mail"
        | Type People -> "icon-people"
        | Type Message -> "icon-message"
        | Type Photo -> "icon-photo"
        | Type Time -> "icon-time"
        | Type Location -> "icon-location"
        | Type Link -> "icon-link"
        | Type Emoji -> "icon-emoji"
        | Type Loading -> "loading"
        | Size X2 -> "icon-2x"
        | Size X3 -> "icon-3x"
        | Size X4 -> "icon-4x"

    let i props =
        ["icon"] @ List.map propToClass props
        |> combineProps
        >> R.i

    // [ClassName "form-icon"]