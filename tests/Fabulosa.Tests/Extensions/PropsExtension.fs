namespace Fabulosa.Tests.Extensions

open Fable.Helpers.React.Props
open ReactNode
module R = Fable.Helpers.React
open Fable.Helpers.React
open Fable.Import.React
open Fabulosa.Extensions

type Find = 
| Class of string
| Name of string

module rec Props =
    let containsClass (className: string) (prop: IProp)  =
        match prop with 
        | :? HTMLAttr as htmlAttr -> 
            match htmlAttr with
            | ClassName c -> c.Contains(className) 
            | _ -> false
        | _ -> false

type TestNode(element: ReactElement) = 
    member __.Element =
        match element with
        | null -> R.span [] []
        | _ -> element
    
    member this.Node () =
        this.Element :?> HTMLNode |> extract

    member this.Props () =
        let _, props, _ = this.Node ()
        props
    
    member this.Name () =
        let name, _, _ = this.Node ()
        name
    
    member this.Children () =
        let _, _, children = this.Node ()
        children 
        |> Seq.map TestNode 
        
    member private this.TextRec text (node : TestNode) : string =
        match node.Element :?> HTMLNode with
        | Text t -> text + t
        | RawText t -> text + t
        | Node (_, _, c) -> 
            c
            |> Seq.map TestNode
            |> Seq.map (this.TextRec text)
            |> Seq.join " "
        | _ -> text
         
    member this.Text () = this.TextRec "" this
            
    member this.Classes () =
        this.Props ()
        |> Seq.map (
            fun p ->
                match p with
                | :? HTMLAttr as htmlAttr -> 
                  match htmlAttr with
                  | ClassName c -> Some c
                  | _ -> None
                | _ -> None)
        |> Seq.choose id
        |> Seq.join " "
        
    member private this.FindTestNode (nodeSeq : TestNode seq) filterFn (subject: TestNode) =
        let nodeSeq =
            match Seq.tryFind filterFn (subject.Props ()) with 
            | Some s -> Seq.append nodeSeq [subject]
            | None -> nodeSeq
        subject.Children ()
            |> Seq.map (this.FindTestNode nodeSeq filterFn)
            |> Seq.collect id
            |> Seq.append nodeSeq
        
    
    member private this.FindTestNodeByName nodeSeq name (node: TestNode) =
        let nodeSeq = 
            if (node.Name() = name) then
                Seq.append nodeSeq [node]
            else 
                nodeSeq   
        node.Children()
        |> Seq.map (this.FindTestNodeByName nodeSeq name) 
        |> Seq.collect id
        |> Seq.append nodeSeq
        
        
    member this.Find (queryType) =
        match queryType with 
        | Class c -> this.FindTestNode [] (Props.containsClass c) this
        | Name name -> this.FindTestNodeByName [] name this

module rec TestNodeExtensions =

    open System
    open Expecto

    let private hasClass classes someClass = 
        Expect.stringContains classes someClass
        <| String.Format ("Should contain class '{0}'", someClass)

    let hasClasses (classes: string list) (element: ReactElement) = 
        let rootNode = element |> TestNode
        List.iter (hasClass <| rootNode.Classes()) classes

    let getChildren (node: TestNode) = 
        node.Children() |> Seq.collect
            (fun (child: TestNode) ->
                [child.Name(), child.Props()]
                @ (getChildren child |> List.ofSeq))
    
    let hasDescendentClass (someClass: string) (element: ReactElement) =
        let rootNode = element |> TestNode
        let rootChildren = getChildren rootNode
        let child =
            Seq.tryFind
                (fun (_, (props: IProp seq)) ->
                    Seq.contains
                        (ClassName someClass)
                        (Seq.cast<HTMLAttr> props))
                rootChildren
        Expect.isSome child
        <| String.Format ("Descendent with class '{0}' not found", someClass)

    let hasDescendent (descendent: ReactElement) (element: ReactElement) =
        let rootNode = element |> TestNode
        let descendentNode = descendent |> TestNode
        let rootChildren = getChildren rootNode
        let child =
            Seq.tryFind
                (fun (name, _) -> name = descendentNode.Name())
                rootChildren
        Expect.isSome child
        <| String.Format ("Descendent with name '{0}' not found", descendentNode.Name())
        match child with
        | Some (_, props) ->
            Expect.containsAll props (descendentNode.Props())
                "Descendent with same props not found"
        | None -> ()

module Seq =

    open System.Linq
    let equals a b = Enumerable.SequenceEqual(a, b)

    let sortByToString = Seq.sortBy (fun elem -> elem.ToString())

module rec ReactNode =

    open Expecto

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
            element :?> HTMLNode |> extract
        { Kind = kind
          Props = props
          Children = Seq.map lift children }

    let descendents node =
        let concat child =
            [child] @ (descendents child |> List.ofSeq)
        node.Children
        |> Seq.collect concat
    
    let found child node =
        Expect.contains
            (lift node |> descendents)
            (lift child) "Descendent not found"
    
    let props reactElement = (lift reactElement).Props
    
    let className reactElement =
        let node = lift reactElement
        node.Props
        |> Seq.map (
            fun p ->
                match p with
                | :? HTMLAttr as htmlAttr -> 
                  match htmlAttr with
                  | ClassName c -> Some c
                  | _ -> None
                | _ -> None)
        |> Seq.choose id
        |> Seq.join " "
            
    let find (child: ReactElement) node = 
        let child = child |> lift
        node 
        |> lift
        |> descendents
        |> Seq.filter (fun x -> x = child)
        
    let private innerText text (element: ReactElement) =
        match element :?> HTMLNode with
        | Text t -> text + t
        | RawText t -> text + t
        | Node (_, _, c) -> 
            c
            |> Seq.map (innerText text)
            |> Seq.join " "
        | _ -> text
        
    let text element = innerText "" element

module ReactNodeTests = 
    open Fabulosa
    open Expecto
    
    [<Tests>]
    let reactNodeTests =
        testList "React Node T" [
            test "find returns empty when no matching descendents are provided" {
                let simpleNode = R.span [] [R.span [] []]
                let simpleDiv = R.div [] []
                
                let foundElements = ReactNode.find simpleDiv simpleNode
                
                Expect.isEmpty foundElements ""
            }
            
            test "find returns does not return the root node itself" {
                let simpleNode = R.div [] []
                
                let foundElements = ReactNode.find simpleNode simpleNode
                
                Expect.isEmpty foundElements ""
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
                let foundElements = ReactNode.find (R.p [] []) root
                
                Expect.equal (foundElements |> Seq.length) 2 ""
            }
            
            test "find returns a subnodes as children" {
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
                let foundElements = ReactNode.find (R.p [] []) root
                 
                Expect.equal (foundElements |> Seq.length) 4 ""
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
                
                let foundElements = ReactNode.find (R.p [ClassName "class-one"] []) root
                
                Expect.equal (foundElements |> Seq.length) 1 ""
               
                let foundElements = ReactNode.find (R.p [Id "id"; ClassName "class-one"] []) root
                
                Expect.equal (foundElements |> Seq.length) 1 ""
            }
        ]