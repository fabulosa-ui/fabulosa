namespace Fabulosa.Docs

module AvatarDemo =

    open Fabulosa
    module R = Fable.Helpers.React


    let avatar =
        Avatar.ƒ { 
            Avatar.defaults with
                Initial = "FA"
        }

    let render () =
        Renderer.tryMount "avatar-demo" avatar