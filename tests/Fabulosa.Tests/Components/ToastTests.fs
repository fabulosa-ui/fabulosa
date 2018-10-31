module ToastTests

open Expecto
open Fabulosa
open Fabulosa.Toast
module R = Fable.Helpers.React
open Fable.Import.React
module P = R.Props
open Expect
open Foq

let mockElement text =
    Mock<Fable.Import.Browser.Element>
        .Property(fun x -> <@ x.innerHTML @>)
        .Returns(text)

let mockEvent mockElement =
    Mock<Fable.Import.React.MouseEvent>
        .Property(fun x -> <@ x.currentTarget @>)
        .Returns(mockElement)

[<Tests>]
let tests =
    testList "Toast tests" [

        test "Toast default" {
           toast ([], Text "Toast")
            |> ReactNode.unit
            |>! hasUniqueClass "toast"
            |> hasText "Toast"
        }

        test "Toast html props" {
            toast ([ P.ClassName "custom" ], Text "Toast")
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Toast colors" {
            toast ([ Color Primary ], Text "Toast")
            |> ReactNode.unit
            |> hasClass "toast-primary"

            toast ([ Color Success ], Text "Toast")
            |> ReactNode.unit
            |> hasClass "toast-success"

            toast ([ Color Warning ], Text "Toast")
            |> ReactNode.unit
            |> hasClass "toast-warning"

            toast ([ Color Error ], Text "Toast")
            |> ReactNode.unit
            |> hasClass "toast-error"
        }

        test "Toast close" {
            let clickable = mockElement "Text"
            let event = mockEvent clickable
            let fn (e: MouseEvent) =
                Expect.equal
                    ((e.currentTarget) :> obj)
                    ((clickable) :> obj)
                    "Should be the mocked element"
            let props =
                toast ([ OnRequestClose fn ], Text "Toast")
                |> ReactNode.unit
                |> ReactNode.descendentProps
            let onClick (prop: P.IProp) =
                match prop with
                | :? P.DOMAttr as attr ->
                    match attr with
                    | P.OnClick fn -> Some fn
                    | _ -> None
                | _ -> None
            match Seq.tryPick onClick props with
            | Some fn -> fn (event)
            | None ->
                Expect.isTrue
                    false
                    "Did not contain onClick prop"
        }
       
    ]