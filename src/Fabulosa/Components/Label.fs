namespace Fabulosa

[<RequireQualifiedAccess>]
module Label =

    open ClassNames

    module R = Fable.Helpers.React

    type Size =
    | Small
    | Large

    type Prop =
    | Size of Size

    let propToClass =
        function
        | Size Small -> "input-sm"
        | Size Large -> "input-lg"

    let create props htmlProps str =
        let labelProps =
            combineProps
            <| ["form-label"] @ List.map propToClass props
            <| htmlProps
        R.label labelProps [R.str str]

    let label text =
        create [] [] text