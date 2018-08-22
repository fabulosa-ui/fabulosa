namespace Fabulosa

module ClassNames =

    open Fable.Helpers.React.Props

    type HTMLProps = IHTMLProp list

    let nonEmpty =
        function
        | "" -> None
        | value -> Some value

    let concatStrings =
        List.choose nonEmpty >> String.concat " "

    let className x = ClassName x :> IHTMLProp

    let combineProps componentClasses htmlProps =
        let classes = concatStrings componentClasses
        htmlProps @ [className classes]