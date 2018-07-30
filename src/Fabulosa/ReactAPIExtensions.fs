namespace Fabulosa

module ReactAPIExtensions =

    open Fable.Import.React
    open Fable.Core

    type ObjectOrArray<'a> =
    | Obj of 'a
    | Arr of array<'a>

    type NativeProps<'a> = {
        children: ObjectOrArray<'a> option
        className: string option
    }

    type NativeReactElement = {
        props: NativeProps<NativeReactElement>;
    }

    [<Import("cloneElement", from="react")>]
    let cloneElement (element: ReactElement) (props: obj) ([<ParamList>] children: obj) = jsNative

    let asNative (element: ReactElement) =
        unbox<NativeReactElement> element