namespace Fabulosa

module Grid =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    module P = R.Props

    type Kind =
    | MLAuto
    | MRAuto
    | MXAuto

    type private ColSize = int

    type GridColumnOptional =
        | Kind of Kind
        | Size of ColSize
        | XSSize of ColSize
        | SMSize of ColSize
        | MDSize of ColSize
        | LGSize of ColSize
        | XLSize of ColSize
        interface P.IHTMLProp

    type GridColumn = P.HTMLProps * ReactElement list

    let private colPropToClassName (prop: P.IHTMLProp) =
        match prop with
        | :? GridColumnOptional as opt ->
            match opt with
            | Kind MLAuto -> "col-ml-auto"
            | Kind MRAuto -> "col-mr-auto"
            | Kind MXAuto -> "col-mx-auto"
            | Size n -> "col-" + string n
            | XSSize n -> "col-xs-" + string n
            | SMSize n -> "col-sm-" + string n
            | MDSize n -> "col-md-" + string n
            | LGSize n -> "col-lg-" + string n
            | XLSize n -> "col-xl-" + string n
            |> P.ClassName
            :> P.IHTMLProp
        | _ -> prop

    let gridColumn ((opt, chi): GridColumn) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "column")
        |> P.map colPropToClassName
        |> P.merge
        |> R.div <| chi

    type GridRowOptional =
        | Gapless
        | OneLine
        interface P.IHTMLProp

    type GridRowChild =
        Column of GridColumn

    type GridRowChildren = GridRowChild list

    type GridRow = P.HTMLProps * GridRowChildren

    let private rowPropToClassName (prop: P.IHTMLProp) =
        match prop with
        | :? GridRowOptional as opt ->
            match opt with
            | Gapless -> "col-gapless"
            | OneLine -> "col-oneline"
            |> P.ClassName
            :> P.IHTMLProp
        | _ -> prop

    let gridRow ((opt, chi): GridRow) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "columns")
        |> P.map rowPropToClassName
        |> P.merge
        |> R.div
        <| Seq.map
            (fun (Column col) -> gridColumn col)
            chi

    type GridChild =
        Row of GridRow

    type GridChildren =
        GridChild list

    type Grid = P.HTMLProps * GridChildren

    let grid ((opt, chi): Grid) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "container")
        |> P.merge
        |> R.div
        <| Seq.map
            (fun (Row row) -> gridRow row)
            chi    