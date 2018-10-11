namespace Fabulosa

[<RequireQualifiedAccess>]
module Table =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    module Column =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = [] }

        let ƒ (column: T) =
            let props, children = column
            props.HTMLProps
            |> R.td <| children

        let render = ƒ

    [<RequireQualifiedAccess>]
    module TitleColumn =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = [] }

        let ƒ (titleColumn: T) =
            let props, children = titleColumn
            props.HTMLProps
            |> R.th <| children

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Row =

        [<RequireQualifiedAccess>]
        type Active = bool

        [<RequireQualifiedAccess>]
        type Props =
            { Active: Active
              HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type Child<'Column, 'TitleColumn> =
        | Column of 'Column
        | TitleColumn of 'TitleColumn

        [<RequireQualifiedAccess>]
        type Children<'Column, 'TitleColumn> =
            Child<'Column, 'TitleColumn> list

        [<RequireQualifiedAccess>]
        type T<'Column, 'TitleColumn> =
            Props * Children<'Column, 'TitleColumn>

        let props =
            { Props.Active = false
              Props.HTMLProps = [] }

        let private active =
            function
            | true -> "active"
            | false -> ""
            >> ClassName

        let private columns =
            function
            | Child.Column column -> Column.ƒ column
            | Child.TitleColumn column -> TitleColumn.ƒ column

        let build columnƒ titleColumnƒ (row: T<'Column, 'TitleColumn>) =
            let props, children = row
            props.HTMLProps
            |> addProp (active props.Active)
            |> R.tr
            <| List.map
                (function
                 | Child.Column column -> columnƒ column
                 | Child.TitleColumn column -> titleColumnƒ column)
                children

        let ƒ = build Column.ƒ TitleColumn.ƒ

    [<RequireQualifiedAccess>]
    module Head =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type Children<'Row> = 'Row list

        [<RequireQualifiedAccess>]
        type T<'Row> = Props * Children<'Row>

        let props =
            { Props.HTMLProps = [] }

        let build rowƒ (head: T<'Row>) =
            let props, children = head
            props.HTMLProps
            |> R.thead
            <| List.map rowƒ children

        let ƒ = build Row.ƒ

    [<RequireQualifiedAccess>]
    module Body =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type Children<'Row> = 'Row list

        [<RequireQualifiedAccess>]
        type T<'Row> = Props * Children<'Row>

        let props =
            { Props.HTMLProps = [] }

        let build rowƒ (body: T<'Row>) =
            let props, children = body
            props.HTMLProps
            |> R.tbody
            <| List.map rowƒ children

        let ƒ = build Row.ƒ

    [<RequireQualifiedAccess>]
    type Kind =
    | Striped
    | Hover
    | Unset

    [<RequireQualifiedAccess>]
    type Props =
        { Kind: Kind
          HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Child<'Head, 'Body> =
    | Head of 'Head
    | Body of 'Body

    [<RequireQualifiedAccess>]
    type Children<'Head, 'Body> =
        Child<'Head, 'Body> list

    [<RequireQualifiedAccess>]
    type T<'Head, 'Body> =
        Props * Children<'Head, 'Body>

    let props =
        { Props.Kind = Kind.Unset
          Props.HTMLProps = [] }

    let private kind =
        function
        | Kind.Striped -> "table-striped"
        | Kind.Hover -> "table-hover"
        | Kind.Unset -> ""
        >> ClassName

    let build headƒ bodyƒ (table: T<'Head, 'Body>) =
        let props, children = table
        props.HTMLProps
        |> addProps
            [ ClassName "table"
              kind props.Kind ]
        |> R.table
        <| List.map
            (function
             | Child.Head head -> headƒ head
             | Child.Body body -> bodyƒ body)
            children

    let ƒ = build Head.ƒ Body.ƒ
