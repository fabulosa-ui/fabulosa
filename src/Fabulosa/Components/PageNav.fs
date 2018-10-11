namespace Fabulosa

module PageNav =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Action =
    | Link of string
    | OnPageChanged of (int -> unit)

    [<RequireQualifiedAccess>]
    type Item =
        { Title: string
          SubTitle: string
          Action: Action }

    [<RequireQualifiedAccess>]
    type Children =
        { Prev: Item option
          Next: Item option }

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.HTMLProps = [] }

    let children =
        { Children.Prev = Some
            { Item.Title = ""
              Item.SubTitle = "Previous"
              Item.Action = Action.Link "" }
          Children.Next = Some
            { Item.Title = ""
              Item.SubTitle = "Next"
              Item.Action = Action.Link "" } }

    let action kind (item: Item): HTMLProps =
        match item.Action with
        | Action.Link href ->
            [ Href href ]
        | Action.OnPageChanged fn ->
            [ OnClick
                (fun _ ->
                    if kind = "prev" then
                        fn -2
                    else fn -1) ]

    let private child kind (item: Item option) =
        match item with
        | Some item ->
            R.li
                [ ClassName ("page-item page-" + kind) ]
                [ R.a
                    (action kind item)
                    [ R.div
                        [ ClassName "page-item-subtitle" ]
                        [ R.str item.SubTitle ]
                      R.div
                        [ ClassName "page-item-title h5" ]
                        [ R.str item.Title ] ] ]
        | None -> R.ofOption None

    let build (pageNav: T) =
        let props, children = pageNav
        props.HTMLProps
        |> addProp (ClassName "pagination")
        |> R.ul
        <| [ child "prev" children.Prev
             child "next" children.Next ]

    let ƒ = build
