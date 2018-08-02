namespace Fabulosa

module ClassNames =

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

    let htmlClasses =
        List.choose htmlAttr
        >> List.choose htmlClassName

    let nonEmpty =
        function
        | "" -> None
        | a -> Some a

    let concatStrings =
        List.choose nonEmpty >> String.concat " "

    let className x = ClassName x :> IHTMLProp

    let combineProps componentClasses htmlProps =
        let htmlClasses =  htmlClasses htmlProps
        let classes =  concatStrings <| htmlClasses @ componentClasses
        htmlProps @ [className classes]