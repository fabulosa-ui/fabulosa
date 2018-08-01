namespace Fabulosa

module ReactAPIExtensions =

    open Fable.Core
    open Fable.Import.React
    module R = Fable.Helpers.React

    [<Pojo>]
    type NativeProps = {
        children: obj option
        className: string
    }

    [<Pojo>]
    type NativeReactElement = {
        ``type``: string
        props: NativeProps
    }

    let getChildren =
        function
        | Some object -> object
        | None -> [] :> obj

    let extractProps (element: ReactElement) =
        let native = unbox<NativeReactElement> element
        (native.``type``, native.props, getChildren <| native.props.children)

    let transform mapping props element =
        let (elType, elProps, elChilren) = extractProps element
        let appended =
            [elProps.className]
            @ List.map mapping props
            |> String.concat " "
        R.createElement (elType, {elProps with className = appended}, elChilren)