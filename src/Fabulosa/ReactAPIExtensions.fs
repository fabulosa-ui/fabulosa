namespace Fabulosa

module ReactAPIExtensions =

    open Fable.Import.React
    open Fable.Core

    [<Import("cloneElement", from="react")>]
    let cloneElement (element: ReactElement) (props: obj) ([<ParamList>] children: obj) = jsNative