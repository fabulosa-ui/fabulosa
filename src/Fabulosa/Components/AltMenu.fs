namespace Fabulosa

module AltMenu =

    module R = Fable.Helpers.React
    open R.Props

    type State =
        { Opened: bool }

    type Message =
    | Click

    let init _ = { Opened = false }

    let update message state =
        match message with
        | Click -> { state with Opened = not state.Opened }

    let view model dispatch =
        R.div [] []

    let ƒ () = R.reactiveCom init update view "nil"