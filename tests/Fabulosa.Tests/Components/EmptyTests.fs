module EmptyTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Empty tests" [

        test "Empty default" {
            Empty.ƒ
                Empty.defaults 
                Empty.children
            |> ReactNode.unit
            |> hasUniqueClass "empty"
        }

        test "Empty html props" {
            Empty.ƒ
                { Empty.defaults with 
                    HTMLProps = [ClassName "custom"] }
                Empty.children
            |> ReactNode.unit
            |> hasClass "empty custom"
        }

        test "Empty with children" {
            let iconProps = 
                { Icon.defaults with
                        Kind = Icon.Kind.Mail }
            let icon =
                Icon.ƒ { iconProps with Size = Icon.Size.X3 }
                |> ReactNode.unit
            let action =
                Button.ƒ ( Button.defaults, [R.str "Action"] )
            Empty.ƒ
                Empty.defaults
                { Icon = iconProps
                  Title = "Title"
                  SubTitle = "SubTitle"
                  Action = [action] }
            |> ReactNode.unit
            |>! hasChild 1 icon
            |>! hasText "Title SubTitle Action"
            |>! hasOrderedDescendentClass 1 "empty-icon empty-title empty-subtitle empty-action"
            |> ignore
        }
    ]