namespace Fabulosa.Tests.Extensions

open Fable.Helpers.React.Props
open ReactNode
module R = Fable.Helpers.React
open R.Props
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
    member this.Element = element
    
    member this.Node () =
        this.Element :?> HTMLNode |> extract 

    member this.Props () =
        let name, props, children = this.Node ()
        props
    
    member this.Name () =
        let name, props, children = this.Node ()
        name
    
    member this.Children () =
        let name, props, children = this.Node ()
        children 
        |> Seq.map TestNode 
        
    member private this.TextRec text (node : TestNode) : string =
        match node.Element :?> HTMLNode with
        | Text t -> text + t
        | RawText t -> text + t
        | Node (a, b, c) -> 
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
        