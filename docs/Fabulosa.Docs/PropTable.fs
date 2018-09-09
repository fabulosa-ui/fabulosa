namespace Fabulosa.Docs

module PropTable =
    open System.Reflection
    open FSharp.Reflection
    module R = Fable.Helpers.React
    open Fable.Import.React
    open R.Props
    open Fabulosa
    
    let flip f a b = f b a
    
    module SystemType =
        let name (typ: PropertyInfo) = typ.Name
    
    let rec describeName (typeInfo: PropertyInfo) =
        match typeInfo.PropertyType with 
        | list when list.Name = "FSharpList`1" -> 
            list.GenericTypeArguments
            |> List.ofArray
            |> List.map (fun f -> f.Name)
            |> flip List.append ["list"]
            |> List.reduce (fun x -> (fun y -> x + " " + y))
        | t ->
            t |> string

    let rec describeType (typeInfo: PropertyInfo) =
        if FSharpType.IsUnion(typeInfo.PropertyType) then
            let name (case: UnionCaseInfo) = case.Name
            let cases = FSharpType.GetUnionCases typeInfo.PropertyType
            let more =
                if Seq.length cases > 4
                then " | ..."
                else ""
            (cases
            |> Array.truncate 4
            |> Array.map name
            |> String.concat " | ") + more
        else
            describeName typeInfo
        
    let getPropFields aType (obj: obj) = 
        let typ = aType
        let record = obj
        let recordTypeFields = FSharpType.GetRecordFields typ
        let recordValueFields = FSharpValue.GetRecordFields record
        let fieldNames = recordTypeFields |> Array.map SystemType.name
        let fieldPropertyTypes = recordTypeFields |> Array.map describeType

        recordValueFields
        |> Array.zip3 fieldNames fieldPropertyTypes
        |> List.ofArray 
        |> List.map (fun (x, y, z) ->
            let t =
                if y.StartsWith("Fabulosa.") then
                    let page =
                        (y.Split ('.')).[1].ToLower()
                    R.a
                        [Href (page + ".html#" + page + "-props")]
                        [R.str y]
                else
                    R.str y
            R.str (x |> string),
            t,
            R.str (z.ToString().Replace(";", ""))
        )

    let toTableRow rowValue =
        let (col1, col2, col3) = rowValue
        Table.Row.ƒ Table.Row.defaults [
            Table.Column.ƒ Table.Column.defaults [col1]
            Table.Column.ƒ
                { Table.Column.defaults with
                    HTMLProps = [Style [WhiteSpace "pre"]] }
                [col2]
            Table.Column.ƒ
                { Table.Column.defaults with
                    HTMLProps = [Style [WhiteSpace "pre"]] }
                [col3]
        ]
    
    let renderTable rowValues =
        Table.ƒ { Table.defaults with Kind = Table.Kind.Striped } [
            Table.Head.ƒ Table.Head.defaults [
                Table.Row.ƒ Table.Row.defaults [
                    Table.TitleColumn.ƒ Table.TitleColumn.defaults [R.str "Name"]
                    Table.TitleColumn.ƒ Table.TitleColumn.defaults [R.str "Type"]
                    Table.TitleColumn.ƒ Table.TitleColumn.defaults [R.str "Default"]
                ]
            ]
            Table.Body.ƒ Table.Body.defaults (rowValues |> List.map toTableRow) 
        ]
        
    let propTable aType obj = getPropFields aType obj |> renderTable 
        