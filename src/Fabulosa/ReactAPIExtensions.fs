namespace Fabulosa

module ReactAPIExtensions =

    open Fable.Import.React

    type ObjectOrArray =
    | Obj of ReactElement
    | Arr of array<ReactElement>

    type NativeProps = {
        children: ObjectOrArray option
        className: string option
    }

    type NativeReactElement = {
        ``type``: string
        props: NativeProps;
    }

    let getClasses nativeElement =
        match nativeElement.props.className with
        | Some c -> c
        | None -> ""

    let getChildren nativeElement =
        match nativeElement.props.children with
        | Some element ->
            match element with
            | Obj c -> [c]
            | Arr a  -> Array.toList a
        | None -> []

    let extract (element: ReactElement) =
        let native = unbox<NativeReactElement> element
        (native.``type``, getClasses native, getChildren native)
    



        