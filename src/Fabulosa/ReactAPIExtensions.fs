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
        | Some c -> c
        | None -> ""

    let getChildren element =
        match element.props.children with
        | Some element ->
            match element with
            | Single c -> [c]
            | Multiple a  -> Array.toList a
        | None -> []

    let extract (element: ReactElement) =
        let native = unbox<NativeReactElement> element
        (native.``type``, getClasses native, getChildren native)
    



        