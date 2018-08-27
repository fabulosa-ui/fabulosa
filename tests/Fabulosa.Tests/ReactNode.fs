module ReactNode

module R = Fable.Helpers.React
open R.Props
open Expecto

let nullElement el =
    if el <> null then 
        el
    else 
        R.str "<NULL-NULL>"
        
let isNull x = x = null

let extract = function
    | R.Node (a, b, c) -> (a, b, Seq.map nullElement c)
    | R.List elements -> ("", seq [], Seq.map nullElement elements)
    | R.Text str when str = "<NULL-NULL>" -> ("null", seq [Value str], seq [])
    | R.Text str -> ("str", seq [Value str], seq [])
    | _ -> ("", seq [], seq [])

let compareNode (subject: Fable.Import.React.ReactElement) node =
    let nodeName, nodeProps, nodeChildren = extract node
    let subName, subProps, subChildren = extract (subject :?> R.HTMLNode)
    Expect.equal (subject.GetType()) (node.GetType()) "Should have a type of react html node"
    Expect.equal nodeName subName "Should have equal names"
    Expect.sequenceEqual nodeProps subProps "Should have equal props"
    Expect.sequenceEqual nodeChildren subChildren "Should have equal children"