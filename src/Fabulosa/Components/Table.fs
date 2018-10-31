namespace Fabulosa

module Table =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    type TableColumn = HTMLProps * ReactElement list

    let tableColumn ((opt, chi): TableColumn) =
        R.td opt chi

    type TableTitleColumn = HTMLProps * ReactElement list

    let tableTitleColumn ((opt, chi): TableTitleColumn) =
        R.th opt chi

    type TableRowChild =
        | Column of TableColumn
        | TitleColumn of TableTitleColumn

    type TableRowChildren =
        TableRowChild list

    type TableRow =
        HTMLProps * TableRowChildren

    let private rowPropToClassName (prop: IHTMLProp) =
        match prop with
        | :? FabulosaActive as opt ->
            match opt with
            | Active -> className "active"
        | _ -> prop
        
    let tableRow ((opt, chi): TableRow) =
        Unmerged opt
        |> map rowPropToClassName
        |> merge
        |> R.tr
        <| List.map
            (function
             | Column col -> tableColumn col
             | TitleColumn col -> tableTitleColumn col)
            chi

    type TableHeadOrBodyChild =
        Row of TableRow

    type TableHead =
        HTMLProps * TableHeadOrBodyChild list

    let tableHead ((opt, chi): TableHead) =
        R.thead
            opt
            (List.map (fun (Row row) -> tableRow row) chi)
            
    type TableBody =
        HTMLProps * TableHeadOrBodyChild list

    let tableBody ((opt, chi): TableBody) =
        R.tbody
            opt
            (List.map (fun (Row row) -> tableRow row) chi)

    type TableKind =
        | Striped
        | Hover

    type TableOptional =
        | Kind of TableKind
        interface IHTMLProp

    type TableChild =
        | Head of TableHead
        | Body of TableBody

    type Table =
        HTMLProps * TableChild list

    let private tablePropToClassName (prop: IHTMLProp) =
        match prop with
        | :? TableOptional as opt ->
            match opt with
            | Kind Striped -> className "table-striped"
            | Kind Hover -> className "table-hover"
        | _ -> prop

    let table ((opt, chi): Table) =
        Unmerged opt
        |> addProp (ClassName "table")
        |> map tablePropToClassName
        |> merge
        |> R.table
        <| List.map
            (function
             | Head head -> tableHead head
             | Body body -> tableBody body)
            chi
