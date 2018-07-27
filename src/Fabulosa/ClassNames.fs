module ClassNames

open Fable.Helpers.React.Props
open Fable

type HTMLProps = IHTMLProp list

let htmlAttr: IHTMLProp -> HTMLAttr option =
    function
    | :? HTMLAttr as attr -> Some attr
    | _ -> None

let htmlClassName =
    function
    | ClassName name -> Some name
    | _ -> None

let htmlClasses: IHTMLProp list -> string list =
    List.choose htmlAttr
    >> List.choose htmlClassName

let concatStrings: string list -> string = String.concat " "

let className x = ClassName x :> IHTMLProp

let addClassesToProps componentClasses htmlProps =
    let htmlClass = concatStrings <| htmlClasses htmlProps
    let componentClass = concatStrings componentClasses
    htmlProps @ [className <| htmlClass + componentClass ]