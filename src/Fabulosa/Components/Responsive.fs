namespace Fabulosa

[<RequireQualifiedAccess>]
module Responsive =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    type Size =
    | XS
    | SM
    | MD
    | LG
    | XL
    | Unset

    [<RequireQualifiedAccess>]
    type Props =
        { Hide: Size
          Show: Size }

    [<RequireQualifiedAccess>]
    type T = Props * ReactElement list

    let props =
        { Props.Hide = Size.Unset
          Props.Show = Size.Unset }

    let private hide =
        function
        | Size.XS -> "hide-xs"
        | Size.SM -> "hide-sm"
        | Size.MD -> "hide-md"
        | Size.LG -> "hide-lg"
        | Size.XL -> "hide-xl"
        | Size.Unset -> ""
        >> ClassName

    let private show =
        function
        | Size.XS -> "show-xs"
        | Size.SM -> "show-sm"
        | Size.MD -> "show-md"
        | Size.LG -> "show-lg"
        | Size.XL -> "show-xl"
        | Size.Unset -> ""
        >> ClassName

    let build (responsive: T) =
        let props, children = responsive
        []
        |> addProps
            [ ClassName "responsive"
              hide props.Hide
              show props.Show ]
        |> R.span <| children

    let ƒ = build
