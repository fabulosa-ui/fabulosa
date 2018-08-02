namespace Fabulosa

[<RequireQualifiedAccess>]
module Table =

    open ClassNames
    module R = Fable.Helpers.React

    type Kind =
    | Striped
    | Hover

    type Prop =
    | Kind of Kind

    let propToClass =
        function
        | Kind Striped -> "table-striped"
        | Kind Hover -> "table-hover"

    let table props =
        ["table"] @ List.map propToClass props
        |> combineProps
        >> R.table

    let thead = R.thead

    let tbody = R.tbody

    [<RequireQualifiedAccess>]
    module Row =

        type Kind =
        | Active

        type Prop =
        | Kind of Kind

        let propToClass =
            function
            | Kind Active -> "active"

    let tr props =
        List.map Row.propToClass props
        |> combineProps
        >> R.tr
    let td = R.td

    let th = R.th