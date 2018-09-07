module AvatarTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Avatar tests" [

        test "Avatar default" {
            let props = Avatar.defaults
            let avatar = Avatar.ƒ props

            avatar
            |> ReactNode.unit
            |> hasClass "avatar avatar-md"
        }

        test "Avatar size small" {
            let props = { Avatar.defaults with Size = Avatar.Size.Small }
            let avatar = Avatar.ƒ props

            avatar
            |> ReactNode.unit
            |> hasClass "avatar avatar-sm"
        }

        test "Avatar data initial" {
            let props = { Avatar.defaults with Initial = "FA" }
            let avatar = Avatar.ƒ props

            avatar
            |> ReactNode.unit
            |> hasProp (Data ("initial", props.Initial))
        }

        test "Avatar image" {
            let props = { Avatar.defaults with Source = "source.png" }
            let avatar = Avatar.ƒ props
            let image =
                R.img [Src "source.png"]
                |> ReactNode.unit

            avatar
            |> ReactNode.unit
            |> hasChild 1 image
        }

        test "Avatar image with icon" {
            let props =
                { Avatar.defaults with
                    Kind = Avatar.Kind.Icon "icon.png"}
            let avatar = Avatar.ƒ props
            let icon =
                R.img [Src "icon.png"; ClassName "avatar-icon"]
                |> ReactNode.unit      

            avatar
            |> ReactNode.unit
            |> hasChild 1 icon
        }

        test "Avatar image with presence" {
            let props =
                { Avatar.defaults with
                    Kind = Avatar.Kind.Presence Avatar.Presence.Online}
            let avatar = Avatar.ƒ props
            let icon =
                R.img [Src "icon.png"]
                |> ReactNode.unit      

            avatar
            |> ReactNode.unit
            |> hasDescendentClass "avatar-presence online"
        }

        test "Avatar html props" {
            let props =
                { Avatar.defaults with
                    HTMLProps = [ClassName "custom"] }
            let avatar = Avatar.ƒ props

            avatar
            |> ReactNode.unit
            |> hasClass "custom"
        }

    ]