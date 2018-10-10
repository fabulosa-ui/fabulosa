namespace Fabulosa

[<RequireQualifiedAccess>]
module Breadcrumb =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    module Item =

        [<RequireQualifiedAccess>]
        type Link =
            { Href: string
              Text: string }

        [<RequireQualifiedAccess>]
        type Children = 
        | Elements of ReactElement list
        | Link of Link
        | Text of string

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }    

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = [] }

        let private renderChildren =
            function
            | Children.Text t -> [R.fragment [] [R.str t]]
            | Children.Link l -> [R.a [Href l.Href] [R.str l.Text]]
            | Children.Elements e -> e 

        let ƒ (item: T) = 
            let props, children = item
            props.HTMLProps
            |> addProp (ClassName "breadcrumb-item")
            |> R.li
            <| renderChildren children

        let render = ƒ

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children<'Item> = 'Item list

    [<RequireQualifiedAccess>]
    type T<'Item> = Props * Children<'Item>

    let props =
        { Props.HTMLProps = [] }

    let build itemƒ (breadcrumb: T<'Item>) =
        let props, children = breadcrumb
        props.HTMLProps
        |> addProp (ClassName "breadcrumb")
        |> R.ul
        <| List.map itemƒ children

    let ƒ = build Item.ƒ
