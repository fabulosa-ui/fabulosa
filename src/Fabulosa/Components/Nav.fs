namespace Fabulosa

module rec Nav =

    open Fabulosa.Extensions
    open Fable.Helpers.React.Props
    open Fable.Import.React
    module R =  Fable.Helpers.React


    module Item =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps
              Href: string
              Text: string }

        [<RequireQualifiedAccess>]
        type T = Props

        let props =
            { Props.HTMLProps = []
              Props.Href = "#"
              Props.Text = "" }

        let ƒ (item: T) =
            R.li
                [ ClassName "nav-item" ]
                [ R.a
                    [ Href item.Href ]
                    [ R.str item.Text ] ]

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Child<'Item> =
    | Item of 'Item
    | Nav of Props * Child<'Item> seq
              
    [<RequireQualifiedAccess>]
    type Children<'Item> = Child<'Item> seq

    [<RequireQualifiedAccess>]
    type T<'Item> = Props * Children<'Item>

    let props =
        { Props.HTMLProps = [] }

    let build itemƒ (nav: T<'Item>) =
        let props, children = nav
        props.HTMLProps
        |> addProp (ClassName "nav")
        |> R.ul
        <| Seq.map
            (function
             | Child.Item props ->
                 itemƒ props
             | Child.Nav (props, children) ->
                 build itemƒ (props, children))
             children

    let ƒ: T<Item.T> -> ReactElement = build Item.ƒ