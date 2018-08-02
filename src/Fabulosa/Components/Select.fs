namespace Fabulosa

[<RequireQualifiedAccess>]
module Select =

    open ClassNames

    module R = Fable.Helpers.React

    type Size =
    | Small
    | Large

    type Prop =
    | Size of Size

    let propToClass =
        function
        | Size Small -> "select-sm"
        | Size Large -> "select-lg"

    let select props =
        ["form-select"]
        @ List.map propToClass props
        |> combineProps
        >> R.input

    let option = R.option

    let optGroup = R.optgroup