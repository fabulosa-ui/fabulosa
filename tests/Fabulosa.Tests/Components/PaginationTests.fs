module PaginationTests

open Expecto
open Fabulosa
open Fabulosa.Pagination
module R = Fable.Helpers.React
module P = R.Props
open Expect
open Foq

let mockClickable page =
    let mockElement =
        Mock<Fable.Import.Browser.HTMLElement>
            .Property(fun x -> <@ x.getAttribute "data-value" @>)
            .Returns(page)
    Mock<Fable.Import.React.MouseEvent>
        .Property(fun x -> <@ x.currentTarget @>)
        .Returns(mockElement)

[<Tests>]
let tests =
    testList "Pagination tests" [

        test "Pagination default" {
            pagination ([], [])
            |> ReactNode.unit
            |> hasUniqueClass "pagination"
        }

        test "Pagination html props" {
            pagination
                ([ P.ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Pagination prev and next" {
            let fn _ = ()
            let prev = [], (OnPageChanged fn, Value -1), (Text "Prev")
            let next = [], (OnPageChanged fn, Value 0), (Text "Prev")
            pagination ([], [ Item prev; Item next ])
            |> ReactNode.unit
            |>! hasChild 1 (paginationItem prev |> ReactNode.unit)
            |> hasChild 1 (paginationItem next |> ReactNode.unit)
        }

        test "Pagination some pages" {
            let fn _ = ()
            let item = ([], (OnPageChanged fn, Value 1), Text "1")
            let pages =
                seq { 1 .. 10 }
                |> Seq.map
                   (fun n -> Item item)
                |> List.ofSeq
            pagination
                ([], pages)
            |> ReactNode.unit
            |> hasChild 10 (paginationItem item |> ReactNode.unit)
        }

        test "Pagination item defaults" {
            let fn _ = ()
            paginationItem
                ([], (OnPageChanged fn, Value 1), Text "Next")
            |> ReactNode.unit
            |> hasUniqueClass "page-item"
        }

        test "Pagination item disabled" {
            let fn _ = ()
            paginationItem
                ([ Disabled ], (OnPageChanged fn, Value 1), Text "Next")
            |> ReactNode.unit
            |> hasClass "disabled"
        }

        test "Pagination item active" {
            let fn _ = ()
            paginationItem
                ([ Active ], (OnPageChanged fn, Value 1), Text "Next")
            |> ReactNode.unit
            |> hasClass "active"
        }

        test "Pagination page changed" {
            let fn page =
                Expect.equal page 1 "Should click on the 'Next' link"
            let element =
                pagination ([],
                    [ Item ([ Active ], (OnPageChanged fn, Value 1), Text "Next") ])
                |> ReactNode.unit
                |> ReactNode.descendentProps
            let onClick (prop: P.IProp) =
                match prop with
                | :? P.DOMAttr as attr ->
                    match attr with
                    | P.OnClick fn -> Some fn
                    | _ -> None
                | _ -> None
            match Seq.tryPick onClick element with
            | Some fn -> fn (mockClickable "1")
            | None -> ()
        }

    ]