module ReactNode

    open System.Linq
    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
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
                Enumerable.SequenceEqual(x.Children, y.Children)
            | _ -> false
        override x.GetHashCode () =
            hash (x.Kind, x.Props, x.Children)
        interface System.IComparable with
            member x.CompareTo yobj =
                match yobj with
                | :? T as y -> compare x y
                | _ -> invalidArg "yobj" "different types"

    let rec unit (element: ReactElement) =
        let (kind, props, children) =
            element :?> R.HTMLNode |> ReactNodeElement.extract
        { Kind = kind
          Props = props
          Children = Seq.map unit children }

    let props node = node.Props

    let kind node = node.Kind

    let children node = node.Children

    #nowarn "40"
    let rec descendents =
        children
        >> Seq.collect
            (fun child ->
                seq {
                    yield child
                    yield! descendents child
                })
        
    let className =
        let classes =
            function
            | ClassName c -> Some c
            | _ -> None
        props
        >> Seq.choose htmlAttrs
        >> Seq.map classes
        >> Seq.choose id
        >> Seq.join " "
    
    let text node =
        let value =
            function
            | Value value -> Some value
            | _ -> None
        match kind node with
        | "<STRING>" ->
            props node
            |> Seq.choose htmlAttrs
            |> Seq.pick value
        | _ ->  ""

    let find child =
        let same x = x = child
        descendents
        >> Seq.filter same

    let descendentClassName =
        descendents
        >> Seq.map className
        >> String.concat " "

    let descendentProps =
        descendents
        >> Seq.collect props

    let descendentText =
        descendents
        >> Seq.map text
        >> Seq.filter String.isNotEmpty
        >> Seq.join " "
        