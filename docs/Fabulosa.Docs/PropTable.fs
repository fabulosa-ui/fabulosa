namespace Fabulosa.Docs

module PropTable =
    open System.Reflection
    open FSharp.Reflection
    module R = Fable.Helpers.React
    open Fable.Import
    open Fable.Import.React
    open R.Props
    open Fabulosa
    
    let flip f a b = f b a
    
    module SystemType =
        let name (typ: PropertyInfo) = typ.Name
    
    let rec systemTypeName(aType: System.Type) =
        let appendMap = ["FSharpList`1", "list"; "FSharpOption`1", "option"] |> Map.ofList
        let exists comparison key value = comparison = key
        
        let (|APPENDABLE|_|) (aType: System.Type) =
           match Map.tryFind aType.Name appendMap with 
           | Some appendableName -> Some appendableName
           | _ -> None
        
        match aType with 
            | APPENDABLE appendableName->
                aType.GenericTypeArguments
                |> List.ofArray
                |> List.map (fun f -> systemTypeName f)
                |> flip List.append [appendableName]
                |> List.reduce (fun x -> (fun y -> x + " " + y))
            | option when option.Name = "FSharpFunc`2" -> 
                option.GenericTypeArguments
                |> List.ofArray
                |> List.map (fun f -> systemTypeName f)
                |> List.reduce (fun x -> (fun y -> x + " -> " + y))
            | t ->
                t.Name
    
    let rec describeName (typeInfo: PropertyInfo) =
        systemTypeName typeInfo.PropertyType

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
        (Table.Row.props,
         [ Table.Row.Child.Column
             (Table.Column.props, [col1])
           Table.Row.Child.Column
              ({ Table.Column.props with
                   HTMLProps = [ Style [ WhiteSpace "pre" ] ] },
                 [col2])
           Table.Row.Child.Column
              ({ Table.Column.props with
                   HTMLProps = [Style [WhiteSpace "pre"]] },
               [col3]) ])

    let renderTable rowValues =
        Table.ƒ
            ({ Table.props with
                 Kind = Table.Kind.Striped },
             [ Table.Child.Head
                 (Table.Head.props,
                  [ (Table.Row.props,
                     [ Table.Row.Child.TitleColumn
                         (Table.TitleColumn.props,
                          [R.str "Name"])
                       Table.Row.Child.TitleColumn
                           (Table.TitleColumn.props,
                            [R.str "Type"])
                       Table.Row.Child.TitleColumn
                           (Table.TitleColumn.props,
                            [R.str "Default"]) ]) ])
               Table.Child.Body
                  (Table.Body.props,
                   (rowValues |> List.map toTableRow)) ])
        
    let propTable aType obj = getPropFields aType obj |> renderTable 
        