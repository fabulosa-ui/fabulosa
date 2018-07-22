module ClassNames

open Fable.Helpers.React.Props

type HTMLProps = IHTMLProp list

let className = ClassName

let htmlAttr (prop: IHTMLProp) =
    match prop with
    | :? HTMLAttr as attr -> Some attr
    | _ -> None

let htmlClassName =
    function
    | ClassName name -> Some name
    | _ -> None

let htmlClasses props =
    List.choose htmlAttr props
    |> List.choose htmlClassName

let mergeClasses (htmlProps: HTMLProps) componentClasses =
    let userClasses = htmlClasses <| htmlProps
    let merged = userClasses @ componentClasses |> String.concat " "
    htmlProps @ [ClassName merged]