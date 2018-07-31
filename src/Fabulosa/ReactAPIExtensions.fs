namespace Fabulosa

module ReactAPIExtensions =

    open Fable.Import.React

    type Children =
    | Single of ReactElement
    | Multiple of array<ReactElement>

    type NativeProps = {
        children: Children option
        className: string option
    }

    type NativeReactElement = {
        ``type``: string
        props: NativeProps;
    }

    let getClasses element =
        match element.props.className with
        | Some className -> className
        | None -> ""

    let getChildren element =
        match element.props.children with
        | Some element ->
            match element with
            | Single child -> [child]
            | Multiple children  -> Array.toList children
        | None -> []

    let extract (element: ReactElement) =
        let native = unbox<NativeReactElement> element
        (native.``type``, getClasses native, getChildren native)
    



        