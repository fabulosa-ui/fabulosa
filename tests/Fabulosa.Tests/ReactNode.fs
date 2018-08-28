module ReactNode

    open System.Linq
    open Fable.Import.React
    module R = Fable.Helpers.React
    open Fabulosa.Extensions
    open R.Props

    let stringEquals a b =
        let stringSort = Seq.map string >> Seq.sort
        Enumerable.SequenceEqual(stringSort a, stringSort b)

    [<CustomEquality; CustomComparison>]
    type T =
        { Kind: string
          Props: IProp seq
          Children: T seq }
        override x.Equals yobj =
            match yobj with
            | :? T as y ->
                x.Kind = y.Kind &&
                stringEquals x.Props y.Props &&
                Seq.equals x.Children y.Children
            | _ -> false
        override x.GetHashCode () =
            hash (x.Kind, x.Props, x.Children)
        interface System.IComparable with
            member x.CompareTo yobj =
                match yobj with
                | :? T as y -> compare x y
                | _ -> invalidArg "yobj" "different types"

    let props node = node.Props

    let kind node = node.Kind

    let children node = node.Children

    let rec unit (element: ReactElement) =
        let (kind, props, children) =
            element :?> R.HTMLNode |> ReactNodeElement.extract
        { Kind = kind
          Props = props
          Children = Seq.map unit children }

    let rec descendents node =
        let concat child =
            [child] @ (descendents child |> List.ofSeq)
        node.Children
        |> Seq.collect concat
        
    let className node =
        node.Props
        |> Seq.map
            (fun p ->
                match p with
                | :? HTMLAttr as htmlAttr -> 
                  match htmlAttr with
                  | ClassName c -> Some c
                  | _ -> None
                | _ -> None)
        |> Seq.choose id
        |> Seq.join " "
            
    let find child node = 
        node 
        |> descendents
        |> Seq.filter (fun x -> x = child)

    let rec text node =
        let htmlAttrs (prop: IProp) =
            match prop with
            | :? HTMLAttr as htmlAttr -> Some htmlAttr
            | _ -> None
        let value =
            function
            | Value value -> Some value
            | _ -> None
        let childrenText = Seq.map text node.Children
        match node.Kind with
        | "<STRING>" ->
            let nodeText =
                Seq.choose htmlAttrs node.Props
                  |> Seq.choose value
            Seq.append nodeText childrenText |> String.concat " "
        | _ ->  String.concat " " childrenText
        