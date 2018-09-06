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
    type Props = {
        Hide: Size
        Show: Size
    }

    let defaults = {
        Props.Hide = Size.Unset
        Props.Show = Size.Unset
    }

    let hide =
        function
        | Size.XS -> "hide-xs"
        | Size.SM -> "hide-sm"
        | Size.MD -> "hide-md"
        | Size.LG -> "hide-lg"
        | Size.XL -> "hide-xl"
        | Size.Unset -> ""
        >> ClassName

    let show =
        function
        | Size.XS -> "show-xs"
        | Size.SM -> "show-sm"
        | Size.MD -> "show-md"
        | Size.LG -> "show-lg"
        | Size.XL -> "show-xl"
        | Size.Unset -> ""
        >> ClassName
        

    let ƒ (props: Props) =
        []
        |> addProps
            [ ClassName "responsive"
              hide props.Hide
              show props.Show ]
        |> R.span

    let render = ƒ


