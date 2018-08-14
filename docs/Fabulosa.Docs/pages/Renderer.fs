namespace Fabulosa.Docs

module Renderer =

    module R = Fable.Helpers.React

    let tryMount id elem =
        try
            R.mountById id elem
        with
            | _ -> Fable.Import.Browser.console.log "failed to mount"