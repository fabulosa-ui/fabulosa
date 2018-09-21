module ButtonTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Button tests" [

        test "Button default" {
            let child =
                R.div
                    [ ClassName "custom" ]
                    [ R.str "text" ]
            Button.ƒ
                ( Button.defaults, [ child ] )
            |> ReactNode.unit
            |>! hasUniqueClass "btn"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button custom class" {
            let child =
                R.div [] [ R.str "text" ]
            Button.ƒ
                ( { Button.defaults with
                      HTMLProps = [ClassName "custom"] },
                  [child] )
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Button kind primary" {
            let child = R.str "text"
            Button.ƒ
                ( { Button.defaults with
                      Kind = Button.Kind.Primary },
                  [ child ] )
            |> ReactNode.unit 
            |>! hasClass "btn btn-primary"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button kind link" {
            let child = R.str "text"
            Button.ƒ
                ( { Button.defaults with
                      Kind = Button.Kind.Link },
                  [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-link"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button color success" {
            let child = R.str "text"
            Button.ƒ
                ( { Button.defaults with
                      Color = Button.Color.Success },
                  [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-success"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button color error" {
            let child = R.str "text"
            Button.ƒ
                ( { Button.defaults with
                      Color = Button.Color.Error },
                  [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-error"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button size small" {
            let child = R.str "text"
            Button.ƒ
                ( { Button.defaults with
                      Size = Button.Size.Small },
                  [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-sm"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button size large" {
            let child = R.str "text"
            Button.ƒ
                ( { Button.defaults with
                      Size = Button.Size.Large },
                  [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-lg"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button state disabled" {
            let child = R.str "text"
            Button.ƒ
                ( { Button.defaults with
                      State = Button.State.Disabled  },
                  [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn disabled"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button state active" {
            let child = R.str "text"
            Button.ƒ
                ( { Button.defaults with
                      State = Button.State.Active },
                  [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn active"
            |> hasChild 1 (child |> ReactNode.unit)
        }
        
        test "Button state loading" {
            let child = R.str "text"
            Button.ƒ
                ( { Button.defaults with
                      State = Button.State.Loading },
                  [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn loading"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button format squared action" {
            let child = R.str "text"
            Button.ƒ
                ( { Button.defaults with
                      Format = Button.Format.SquaredAction },
                  [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-action"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button format round action" {
            let child = R.str "text"
            Button.ƒ
                ( { Button.defaults with
                      Format = Button.Format.RoundAction },
                  [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-action circle"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button children with name" {
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            Button.ƒ
                ( Button.defaults, [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn"
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }
        
        test "Button children with class" {
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            Button.ƒ
                ( { Button.defaults with Size = Button.Size.Small },
                  [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-sm"
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

    ]