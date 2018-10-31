namespace Fabulosa

module Pagination =

    open Fable.Import
    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    module P = R.Props

    type PaginationItemOptional =
        | Disabled
        interface P.IHTMLProp

    type OnPageChanged =
        | OnPageChanged of (int -> unit)

    type PaginationItemRequired =
        OnPageChanged * FabulosaValue

    type PaginationItem =
        P.HTMLProps * PaginationItemRequired * FabulosaText

    let private (|Int|_|) str =
       match System.Int32.TryParse(str) with
       | (true, int) -> Some int
       | _ -> None

    let private onClick (e: MouseEvent) =
        let element = e.currentTarget :?> Browser.HTMLElement
        match element.getAttribute "data-value" with
        | Int value -> value
        | _ -> -99

    let private propToClassName (prop: P.IHTMLProp) =
        match prop with
        | :? PaginationItemOptional as opt ->
            match opt with
            | Disabled -> P.className "disabled"
        | :? FabulosaActive as opt ->
            match opt with
            | Active -> P.className "active"
        | _ -> prop

    let paginationItem ((opt, (OnPageChanged pc, Value v), (Text txt)): PaginationItem) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "page-item")
        |> P.map propToClassName
        |> P.merge
        |> R.li
        <| [ R.a
               [ P.OnClick (onClick >> pc)
                 P.Data ("value", v)
                 P.Href "#" ]
               [ R.str txt ] ]

    type PaginationChild =
        | Item of PaginationItem

    type Pagination =
        P.HTMLProps * PaginationChild list

    let pagination ((opt, chi): Pagination) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "pagination")
        |> P.merge
        |> R.ul
        <| Seq.map
            (fun (Item item) -> paginationItem item)
            chi
