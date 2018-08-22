namespace Fabulosa.Tests.Extensions

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Fabulosa.Tests.Extensions

module Expect =
    let containsToString sequence subject errorMes=
        (sequence
        |> Seq.map (fun x -> x.ToString())
        |> Seq.contains (subject.ToString())
        |> Expect.isTrue) errorMes
        
    let rec nodeEqual (expected: TestNode) (actual: TestNode) =
        if expected.Element <> null && actual.Element <> null then
            Expect.equal (expected.Classes()) (actual.Classes()) "Classes should equal"
            Expect.containsAll (expected.Props()) (actual.Props()) "Classes should equal"
            let expectedLength = expected.Children() |> Seq.length 
            let actualLength = actual.Children() |> Seq.length 
            Expect.equal expectedLength actualLength "Expected and actual children have same length"
            if (expectedLength > 0) then
                Seq.iter2 nodeEqual (expected.Children()) (actual.Children())
        
    let nodeNotEqual (expected: TestNode) (actual: TestNode) =
        Expect.throws (fun _ -> nodeEqual expected actual) "Exception was expected to be raised"
    
    
module Tests =
    module MultiNode =
        open ClassNames
        module R = Fable.Helpers.React
        open Fable.Import.React
        open Fable.Helpers
        
        open R.Props
        type Kind =
        | One
        | Two
        | Three
        
        [<RequireQualifiedAccess>]
        type Props = {
            SubNode: Props option
            HTMLProps: IHTMLProp list
        }
        
        let defaults: Props = {
            SubNode = None
            HTMLProps = []
        }
            
        let rec ƒ (props: Props) =
            let childLessElement = 
                props.HTMLProps
                |> combineProps ["additionalClass"]
                |> R.span
        
            childLessElement [
                R.span [ClassName "more-content"] [R.str "extra test node"]
                props.SubNode |> Option.map ƒ |> React.ofOption 
            ]    
            
        let render = ƒ
        
    [<Tests>]
    let expectoTests =
        testList "NodeEquals tests" [        
            test "Equal Elements are equal" {
                let node1 = MultiNode.ƒ MultiNode.defaults |> TestNode
                let node2 = MultiNode.ƒ MultiNode.defaults |> TestNode
    
                Expect.nodeEqual node1 node2
            }
            
            test "Elements with the same props are equal" {
                let node1 = MultiNode.ƒ { MultiNode.defaults with HTMLProps = [Id "pele"]}  |> TestNode
                let node2 = MultiNode.ƒ { MultiNode.defaults with HTMLProps = [Id "pele"]} |> TestNode
    
                Expect.nodeEqual node1 node2
            }
            
            test "Elements with the diff props are not equal" {
                let node1 = MultiNode.ƒ { MultiNode.defaults with HTMLProps = [Id "pele"]}  |> TestNode
                let node2 = MultiNode.ƒ { MultiNode.defaults with HTMLProps = [Id "maradona"]} |> TestNode
                
                Expect.nodeNotEqual node1 node2
                
                let node1 = MultiNode.ƒ { MultiNode.defaults with HTMLProps = [ClassName "pele"]}  |> TestNode
                let node2 = MultiNode.ƒ { MultiNode.defaults with HTMLProps = [ClassName "maradona"]} |> TestNode
                Expect.nodeNotEqual node1 node2
            }
            
            test "Elements with sub elements that are not equal are distinguished" {
                let props1 = 
                    { MultiNode.defaults with 
                        HTMLProps = [Id "pele"] 
                        SubNode = Some { MultiNode.defaults with HTMLProps = [ClassName "test-class"; Id "hello"] }
                    } 
                let props2 = 
                    { MultiNode.defaults with 
                        HTMLProps = [Id "pele"] 
                        SubNode = Some { MultiNode.defaults with HTMLProps = [ClassName "another-class"; Id "hello"] }
                    } 
                let node1 = MultiNode.ƒ props1 |> TestNode
                let node2 = MultiNode.ƒ props2 |> TestNode
    
                Expect.nodeNotEqual node1 node2
            }
            
            test "Elements with sub elements that are equal pass successfully" {
                let props1 = 
                    { MultiNode.defaults with 
                        HTMLProps = [Id "pele"] 
                        SubNode = Some { MultiNode.defaults with HTMLProps = [ClassName "test-class"; Id "hello"] }
                    } 
                let props2 = 
                    { MultiNode.defaults with 
                        HTMLProps = [Id "pele"] 
                        SubNode = Some { MultiNode.defaults with HTMLProps = [ClassName "test-class"; Id "hello"] }
                    } 
                let node1 = MultiNode.ƒ props1 |> TestNode
                let node2 = MultiNode.ƒ props2 |> TestNode
    
                Expect.nodeEqual node1 node2
            }
        ]