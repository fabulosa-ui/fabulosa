namespace Fabulosa

module ClassNames =

    open Fable.Helpers.React.Props
    
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

    let className =
        function
        | ClassName name -> Some name
        | _ -> None

    let withoutClassName (prop: IHTMLProp) =
        match prop with
        | :? HTMLAttr as htmlAttr ->
            match htmlAttr with
            | ClassName _ -> false
            | _ -> true
        | _ -> true
        
    let addClasses componentClasses (htmlProps: HTMLProps): HTMLProps =
        let classes = concatStrings componentClasses
        let htmlPropsAttrs = Seq.choose htmlAttrs htmlProps
        let concat existing = existing + " " + classes 
        if htmlPropsAttrs
            |> Seq.choose className
                |> Seq.length > 0 then
            let merged =
                htmlPropsAttrs
                |> Seq.tryPick className
                |> Option.map concat
            let filteredHtmlProps =
                htmlProps
                |> Seq.filter withoutClassName
            match merged with
            | Some className ->
                (filteredHtmlProps
                |> Seq.cast<IHTMLProp>
                |> List.ofSeq)
                @ [ClassName className]
            | _ -> htmlProps
        else
            htmlProps @ [ClassName classes]
