namespace Fabulosa.Docs

module rec PropTable =
    open System.Reflection
    open FSharp.Reflection
    open Fable.Import.React
    open Fable.Helpers.React.Props
    open Fabulosa.Table
    module R = Fable.Helpers.React
    module P = R.Props
        
    let flip f a b = f b a
    
    module SystemType =
        let name (typ: PropertyInfo) = typ.Name

    let typeMatches checker systemType =
            checker systemType
            |> function
               | true -> Some systemType
               | false -> None

    let (|Union|_|) = typeMatches FSharpType.IsUnion

    let (|Tuple|_|) = typeMatches FSharpType.IsTuple

    let (|List|_|) (systemType: System.Type) =
        match systemType.Name.Contains "FSharpList" with
        | true -> Some "list"
        | false -> None

    let (|Option|_|) (systemType: System.Type) =
        match systemType.Name.Contains "FSharpOption" with
        | true -> Some "option"
        | false -> None
    
    let rec systemTypeName (aType: System.Type) =
        match aType with 
            | (List strType) | (Option strType) ->
                aType.GenericTypeArguments
                |> List.ofArray
                |> List.map systemTypeName
                |> flip List.append [ strType ]
                |> List.reduce (fun x -> (fun y -> x + " " + y))
            | Tuple tuple ->
                tuple
                |> FSharpType.GetTupleElements
                |> Array.map systemTypeName
                |> List.ofArray
                |> String.concat " * "
                |> (fun str -> "(" + str + ")")
            | option when option.Name = "FSharpFunc`2" -> 
                option.GenericTypeArguments
                |> List.ofArray
                |> List.map systemTypeName
                |> List.reduce (fun x -> (fun y -> x + " -> " + y))
            | t ->
                t.Name

    let rec describeType (propType: System.Type) =
        match propType with
        | Tuple propType ->
            propType
            |> FSharpType.GetTupleElements
            |> Array.map systemTypeName
            |> List.ofArray
            |> String.concat " * "
            |> (fun str -> "(" + str + ")")
        | Union propType ->
            let cases = FSharpType.GetUnionCases propType
            let more =
                if Seq.length cases > 6
                then " | ..."
                else ""
            (cases
            |> Array.truncate 6
            |> Array.map (fun c -> c.Name)
            |> String.concat " | ") + more
        | _ -> systemTypeName propType

    let getRecordPropFields aType (record: obj) = 
        let recordTypeFields = FSharpType.GetRecordFields aType
        let fieldNames = recordTypeFields |> Array.map SystemType.name
        let fieldPropertyTypes =
            recordTypeFields
            |> Array.map (fun propInfo -> propInfo.PropertyType)
            |> Array.map describeType
        record
        |> FSharpValue.GetRecordFields
        |> Array.zip3 fieldNames fieldPropertyTypes
        |> List.ofArray 
        |> List.map (fun (x, y, _) -> R.str x, R.str y, R.str "")
        
    let getUnionPropFields (union: System.Type) kind = 
        FSharpType.GetUnionCases union
        |> List.ofArray
        |> List.collect
            (fun case ->
                let fields = case.GetFields()
                let propTypes =
                    fields
                    |> Array.map (fun e -> e.PropertyType)
                propTypes
                |> Array.map
                    (fun typ -> (case.Name, describeType typ))
                |> Array.map (fun (a, b) ->
                    (R.str a, R.str b, R.str kind))
                |> List.ofArray
            )

    let getTuplePropFields st (kind: string) =
        FSharpType.GetTupleElements st
        |> List.ofArray
        |> List.collect (getFields kind)

    let getFields (kind: string) = 
        function
        | Union u -> getUnionPropFields u kind
        | Tuple t -> getTuplePropFields t kind
        | _ -> []

    let toTableRow rowValue =
        let (col1, col2, col3) = rowValue
        Row ([],
         [ Column ([], [ col1 ])
           Column ([ Style [ WhiteSpace "pre" ] ], [ col2 ])
           Column ([], [ col3 ]) ])

    let renderTable rowValues =
        table
            ([ Kind Striped ],
             [ Head ([],
                 [ Row ([],
                     [ TitleColumn ([ Style [ Width "150px"]], [ R.str "Name" ])
                       TitleColumn ([], [ R.str "Type" ])
                       TitleColumn ([], [ R.str "Kind" ]) ]) ])
               Body ([],
                   (rowValues |> List.map toTableRow)) ])

    let propTable aType obj = getRecordPropFields aType obj |> renderTable 

    let unionPropTable union = getUnionPropFields union "None" |> renderTable

    let paramTable optType reqType chiType =
        let fields (typ: System.Type option) (kind: string) =
            match typ with
            | Some t -> getFields kind t
            | None -> []
        (fields optType "IHTMLProp" )
        @ (fields reqType "Required")
        @ (fields chiType "Child")
        |> renderTable

    let definition compType =
        let name, def, _ =
            getFields "" compType
            |> List.head
        R.p [ Style [
            Padding "10px"
            Background "#fafaff"
            Color "#5755d9"
            FontFamily "\"SF Mono\", \"Segoe UI Mono\",\"Roboto Mono\",Menlo,Courier,monospace"
            FontSize "10pt"
            FontWeight "100"] ] [
            R.span [ Style [ TextTransform "lowercase" ] ] [ name ]
            R.str " "
            R.span [] [ def ] ]
        