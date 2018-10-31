namespace Fabulosa

module Chip =

    open Fable.Import.React
    open Fabulosa.Extensions
    open Fabulosa.Avatar
    module R = Fable.Helpers.React
    module P = R.Props

    type ChipOptional =
        | OnRemove of (MouseEvent -> unit)
        | Avatar of AvatarChildren
        interface P.IHTMLProp

    type Chip =
        P.HTMLProps * FabulosaText

    let private pick fn (props: P.HTMLProps) =
        props |> List.tryPick fn

    let private onRemove =
        fun (prop: P.IHTMLProp) ->
            match prop with
            | :? ChipOptional as opt ->
                match opt with
                | OnRemove fn ->
                    Some (R.a
                      [ P.ClassName "btn btn-clear"
                        P.Role "button"
                        P.OnClick fn ] [])
                | _ -> None
            | _ -> None
        |> pick

    let private avatar =
        fun (prop: P.IHTMLProp) ->
            match prop with
            | :? ChipOptional as opt ->
                match opt with
                | Avatar chi ->
                    Some (avatar ([ Size Small ], chi))
                | _ -> None
            | _ -> None
        |> pick

    let chip ((opt, (Text text)): Chip) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "chip")
        |> P.merge
        |> R.div <|
        [ R.ofOption (avatar opt)
          R.str text
          R.ofOption (onRemove opt) ]
