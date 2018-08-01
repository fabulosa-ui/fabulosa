namespace Fabulosa

module ReactAPIExtensions =

    open Fable.Core
    open Fable.Core.JsInterop

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

    let optionAppend (text: string) =
        function
        | Some c -> Some <| c + " " + text
        | None -> Some text


    let transform element mapping prop =
        let (``type``, props, children) = extract element
        let value = mapping prop
        
        Fable.Import.Browser.console.log "original"
        Fable.Import.Browser.console.log element
        let appended = props.className |> optionAppend value
        printf "%O" appended
               
        let xx = R.createElement(``type``, {props with className = appended}, props.children)
                
        
        Fable.Import.Browser.console.log "stuff"
        Fable.Import.Browser.console.log xx
        
        xx
    



        