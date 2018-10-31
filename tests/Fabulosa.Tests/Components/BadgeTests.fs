module BadgeTests

open Expecto
open Fabulosa
open Fabulosa.Badge
open Fabulosa.Avatar
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Badge tests" [

        test "Badge default" {
            badge ([], Value 1, Div ([], [ R.str "Badge" ]))
            |> ReactNode.unit
            |>! hasUniqueClass "badge"
            |>! hasProp (P.Data ("badge", 1))
            |> hasText "Badge"
        }

        test "Badge span" {
            badge ([], Value 2, Span ([], [ R.str "Badge" ]))
            |> ReactNode.unit
            |>! hasUniqueClass "badge"
            |>! hasProp (P.Data ("badge", 2))
            |> hasText "Badge"
        }

        test "Badge button" {
            badge ([], Value 3, Button ([], [ R.str "Badge" ]))
            |> ReactNode.unit
            |>! hasUniqueClass "btn badge"
            |>! hasProp (P.Data ("badge", 3))
            |> hasText "Badge"
        }

        test "Badge avatar" {
            badge ([], Value 1, Avatar ([], Initial "FA"))
            |> ReactNode.unit
            |>! hasClass "avatar badge"
            |> hasProp (P.Data ("badge", 1))
        }

        test "Badge avatar size" {
            badge ([], Value 99, Avatar ([ Size Large ], Initial "FA"))
            |> ReactNode.unit
            |>! hasUniqueClass "avatar badge avatar-lg"
            |> hasProp (P.Data ("badge", 99))
        }

    ]