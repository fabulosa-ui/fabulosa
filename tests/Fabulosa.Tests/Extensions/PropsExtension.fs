namespace Fabulosa.Tests.Extensions

open Fable.Helpers.React.Props
open ReactNode
module R = Fable.Helpers.React
open Fable.Import.React
open Fabulosa.Extensions

module Seq =

    open System.Linq
    let equals a b = Enumerable.SequenceEqual(a, b)

    let sortByToString = Seq.sortBy (fun elem -> elem |> string)

module rec ReactNode =

    [<CustomEquality; CustomComparison>]
    type T =
        { Kind: string
          Props: IProp seq
          Children: T seq }
        override x.Equals yobj =
            match yobj with
            | :? T as y ->
                x.Kind = y.Kind &&
                Seq.equals
                <| Seq.sortByToString x.Props
                <| Seq.sortByToString y.Props &&
                Seq.equals x.Children y.Children
            | _ -> false
        override x.GetHashCode () =
            hash (x.Kind, x.Props, x.Children)
        interface System.IComparable with
            member x.CompareTo yobj =
                match yobj with
                | :? T as y -> compare x y
                | _ -> invalidArg "yobj" "different types"

    let lift (element: ReactElement) =
        let (kind, props, children) =
            element :?> R.HTMLNode |> extract
        { Kind = kind
          Props = props
          Children = Seq.map lift children }

    let descendents node =
        let concat child =
            [child] @ (descendents child |> List.ofSeq)
        node.Children
        |> Seq.collect concat
    
    let props node = node.Props
    
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
        
    let text node =
        let htmlAttrs (prop: IProp) =
            match prop with
            | :? HTMLAttr as htmlAttr -> Some htmlAttr
            | _ -> None
        let value =
            function
            | Value value -> Some value
            | _ -> None
        match node.Kind with
        | "str" ->
            let nodeText =
                Seq.choose htmlAttrs node.Props
                  |> Seq.choose value
            let childrenText = Seq.map text node.Children
            String.concat " " (Seq.append nodeText childrenText)
        | _ ->  String.concat " " (Seq.map text node.Children)

module ReactNodeTests = 

    open Expecto
    
    [<Tests>]
    let reactNodeTests =
        testList "React Node T" [
            test "find returns empty when no matching descendents are provided" {
                let simpleNode = R.span [] [R.span [] []]
                let simpleDiv = R.div [] []
                
                let subject = ReactNode.lift simpleNode
                let descendent = ReactNode.lift simpleDiv

                let found = subject |> ReactNode.find descendent
                Expect.isEmpty found "Should not find what isn't there"
            }
            
            test "find returns does not return the root node itself" {
                let simpleNode = R.div [] []
                
                let subject = ReactNode.lift simpleNode
                let itself = ReactNode.lift simpleNode

                let found = subject |> ReactNode.find itself
                Expect.isEmpty found "Should not find itself"
            }
             
            test "find returns a subnodes" {
                let root = R.div [] [
                   R.span [] [
                       R.p [] [
                           R.p [] []
                       ]
                   ]
                   R.p [] []
                ]

                let subject = root |> ReactNode.lift
                let descendent = R.p [] [] |> ReactNode.lift

                let found = subject |> ReactNode.find descendent 
                Expect.equal (found |> Seq.length) 2 ""
            }
            
            test "a find a returns a subnodes as children" {
                let root = R.div [] [
                    R.span [] [
                       R.p [] [
                            R.p [] []
                            R.p [] []
                        ]
                    ]
                    R.p [] []
                    R.p [] []
                ]

                let subject = ReactNode.lift root
                let descendent = ReactNode.lift <| R.p [] []

                let found = subject |> ReactNode.find descendent
                Expect.equal (found |> Seq.length) 4 "Should find all descendents"
             }
             
            test "find returns subnodes matching on props" {
                let root = R.div [] [
                    R.span [] [
                       R.p [] [
                           R.p [ClassName "class-one"] []
                           R.p [] []
                       ]
                    ]
                    R.p [Id "id"; ClassName "class-one"] []
                    R.p [] []
                ]

                let subject = ReactNode.lift root
                let descendent1 = ReactNode.lift <| R.p [ClassName "class-one"] []
                let descendent2 = ReactNode.lift <| R.p [Id "id"; ClassName "class-one"] []
                
                let found1 = subject |> ReactNode.find descendent1
                
                Expect.equal (found1 |> Seq.length) 1 "Should find with props correctly"

                let found2 = subject |> ReactNode.find descendent2

                Expect.equal (found2 |> Seq.length) 1 "Should find with props correctly"
            }

            test "find poo" {
                let root = R.div [] [
                    R.RawText "waaaat"
                ]
                let subject = root |> ReactNode.lift |> ReactNode.text
                printfn "%A" subject
                Expect.isTrue true "Yep"
            }
        ]