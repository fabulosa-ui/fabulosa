namespace Fabulosa.Docs

module AvatarDemo =

    open Fabulosa
    module R = Fable.Helpers.React


    let avatar =
        Avatar.ƒ { 
            Avatar.defaults with
                Initial = "FA"
        }
    let extraSmall =
        Avatar.ƒ {
            Avatar.defaults with
                Initial = "FA"
                Size = Avatar.Size.ExtraSmall
        }
    let small =
        Avatar.ƒ {
            Avatar.defaults with
                Initial = "FA"
                Size = Avatar.Size.Small
        }
    let medium =
        Avatar.ƒ {
            Avatar.defaults with
                Initial = "FA"
                Size = Avatar.Size.Medium
        }
    let large =
        Avatar.ƒ {
            Avatar.defaults with
                Initial = "FA"
                Size = Avatar.Size.Large
        }
    let extraLarge =
        Avatar.ƒ {
            Avatar.defaults with
                Initial = "FA"
                Size = Avatar.Size.ExtraLarge
        }
    let icon =
        Avatar.ƒ {
            Avatar.defaults with
                Initial = "FA"
                Kind = Avatar.Kind.Icon "assets/avatar-1.png"
        }
    let presence =
        Avatar.ƒ {
            Avatar.defaults with
                Initial = "FA"
                Kind = Avatar.Kind.Presence Avatar.Presence.Online
        }

    let render () =
        Renderer.tryMount "avatar-demo" avatar
        Renderer.tryMount "avatar-xs-demo" extraSmall
        Renderer.tryMount "avatar-sm-demo" small
        Renderer.tryMount "avatar-md-demo" medium
        Renderer.tryMount "avatar-lg-demo" large
        Renderer.tryMount "avatar-xl-demo" extraLarge
        Renderer.tryMount "avatar-icon-demo" icon
        Renderer.tryMount "avatar-presence-demo" presence