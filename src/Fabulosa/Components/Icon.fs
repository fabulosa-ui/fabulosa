namespace Fabulosa

module Icon =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

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

    type Size =
        | X2
        | X3
        | X4

    type IconOptional =
        | Size of Size
        interface IHTMLProp

    type IconRequired =
        Kind of Kind

    type Icon =
        HTMLProps * IconRequired

    let private kind =
        function
        | ArrowUp -> "icon-arrow-up"
        | ArrowRight -> "icon-arrow-right"
        | ArrowDown -> "icon-arrow-down"
        | ArrowLeft -> "icon-arrow-left"
        | Upward -> "icon-upward"
        | Forward -> "icon-forward"
        | Downward -> "icon-downward"
        | Back -> "icon-back"
        | Caret -> "icon-caret"
        | Menu -> "icon-menu"
        | Apps -> "icon-apps"
        | MoreHoriz -> "icon-more-horiz"
        | MoreVert -> "icon-more-vert"
        | ResizeHoriz -> "icon-resize-horiz"
        | ResizeVert -> "icon-resize-vert"
        | Plus -> "icon-plus"
        | Minus -> "icon-minus"
        | Cross -> "icon-cross"
        | Check -> "icon-check"
        | Stop -> "icon-stop"
        | Shutdown -> "icon-shutdown"
        | Refresh -> "icon-refresh"
        | Search -> "icon-search"
        | Flag -> "icon-flag"
        | Bookmark -> "icon-bookmark"
        | Edit -> "icon-edit"
        | Delete -> "icon-delete"
        | Share -> "icon-share"
        | Download -> "icon-download"
        | Upload -> "icon-upload"
        | Mail -> "icon-mail"
        | People -> "icon-people"
        | Message -> "icon-message"
        | Photo -> "icon-photo"
        | Time -> "icon-time"
        | Location -> "icon-location"
        | Link -> "icon-link"
        | Emoji -> "icon-emoji"
        | Loading -> "loading"
        >> ClassName

    let private size (prop: IHTMLProp) =
        match prop with
        | :? IconOptional as opt ->
            match opt with
            | Size X2 -> "icon-2x"
            | Size X3 -> "icon-3x"
            | Size X4 -> "icon-4x"
            |> ClassName
            :> IHTMLProp
        | _ -> prop

    let icon ((opt, (Kind req)): Icon) =
        Unmerged opt
        |> addProps
            [ ClassName "icon"
              kind req ]
        |> map size
        |> merge
        |> R.i <| []
