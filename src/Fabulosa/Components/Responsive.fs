namespace Fabulosa

[<RequireQualifiedAccess>]
module Responsive =

    open ClassNames

    type Size =
    | XS
    | SM
    | MD
    | LG
    | XL

    type Props =
    | Hide of Size
    | Show of Size

    let propToClass =
        function
        | Hide XS -> "hide-xs"
        | Hide SM -> "hide-sm"
        | Hide MD -> "hide-md"
        | Hide LG -> "hide-lg"
        | Hide XL -> "hide-xl"
        | Show XS -> "show-xs"
        | Show SM -> "show-sm"
        | Show MD -> "show-md"
        | Show LG -> "show-lg"
        | Show XL -> "show-xl"

    let responsiveP props element elementProps =
        ["responsive"] @ List.map propToClass props
        |> combineProps
        >> element elementProps

    let responsive props element =
        ["responsive"] @ List.map propToClass props
        |> combineProps
        >> element
