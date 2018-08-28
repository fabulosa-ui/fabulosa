namespace Fabulosa

module List =
    let cast<'a> = Seq.cast<'a> >> List.ofSeq 

module ClassNames =

    open Fable.Helpers.React.Props

    type HTMLProps = IHTMLProp list

    let nonEmpty =
        function
        | "" -> None
        | value -> Some value

    let concatStrings =
        List.choose nonEmpty >> String.concat " "

    let htmlAttrs (prop: IProp) =
        match prop with
        | :? HTMLAttr as htmlAttr -> Some htmlAttr
        | _ -> None

    let appendToClassName htmlAttr newClassName =
        match htmlAttr with
        | ClassName className ->
            ClassName (className + " " + newClassName)
        | somethingElse -> somethingElse

    let hasClasses =
        function
        | ClassName _ -> true
        | _ -> false

    let combineProps componentClasses htmlProps =
        let classes = concatStrings componentClasses
        if List.exists hasClasses (htmlProps |> List.cast<HTMLAttr>) then
            List.map
                (fun htmlAttr -> (classes |> appendToClassName htmlAttr) :> IHTMLProp)
                (List.ofSeq <| Seq.cast<HTMLAttr> htmlProps)
        else htmlProps @ [ClassName classes]