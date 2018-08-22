module ReactNode

module R = Fable.Helpers.React
open Expecto

let extract = function
    | R.Node (a, b, c) -> (a, b, c)
    | R.List elements -> ("", seq [], elements)
    | _ -> ("", seq [], seq [])

let compareNode (subject: Fable.Import.React.ReactElement) node =
    let nodeName, nodeProps, nodeChildren = extract node
    let subName, subProps, subChildren = extract (subject :?> R.HTMLNode)
    Expect.equal (subject.GetType()) (node.GetType()) "Should have a type of react html node"
    Expect.equal nodeName subName "Should have equal names"
    Expect.sequenceEqual nodeProps subProps "Should have equal props"
    Expect.sequenceEqual nodeChildren subChildren "Should have equal children"