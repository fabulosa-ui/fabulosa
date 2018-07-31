namespace Fabulosa

module ReactAPIExtensions =

    open Fable.Core
    open Fable.Import.React
    module R = Fable.Helpers.React

    type Children =
    | Single of ReactElement
    | Multiple of array<ReactElement>

    [<Pojo>]
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
        (native.``type``, native.props, getChildren native)

    let mapExtract transform comp =
        let (element, props, children) = extract comp
        transform element props children

    let optionAppend text =
        function
        | Some c -> Some <| c + text
        | None -> Some text            

    let transform element props children value =
        let appended = props.className |> optionAppend value
        R.ofFunction (fun _ -> R.domEl element [] []) {props with className = appended} children   
    



        