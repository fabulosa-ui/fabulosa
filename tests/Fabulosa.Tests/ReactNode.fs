module ReactNode

    open System.Linq
    open Fable.Import.React
    module R = Fable.Helpers.React
    open Fabulosa
    open Fabulosa.Extensions
    open ClassNames
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
        let classes =
            function
            | ClassName c -> Some c
            | _ -> None
        node.Props
        |> Seq.choose htmlAttrs
        |> Seq.map classes
        |> Seq.choose id
        |> Seq.join " "
            
    let find child node =
        let same x = x = child
        node 
        |> descendents
        |> Seq.filter same

    let rec text node =
        let value =
            function
            | Value value -> Some value
            | _ -> None
        let childrenText = Seq.map text node.Children
        match node.Kind with
        | "<STRING>" ->
            node.Props
            |> Seq.choose htmlAttrs 
            |> Seq.choose value
            |> Seq.append childrenText
            |> String.concat " "
        | _ ->  String.concat " " childrenText
        