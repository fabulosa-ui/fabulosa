namespace Fabulosa.Extensions

open Fable.Helpers.React.Props

module Fable =
    module Helpers =
        module React =
            module Props =
                type HTMLProps = IHTMLProp list

                let nonEmpty =
                    function
                    | "" -> None
                    | value -> Some value

                let concatStrings =
                    List.choose nonEmpty
                    >> String.concat " "

                let htmlAttrs (prop: IProp) =
                    match prop with
                    | :? HTMLAttr as htmlAttr -> Some htmlAttr
                    | _ -> None

                let combineProp (prop: IHTMLProp) (htmlProp: IHTMLProp) =
                    match prop :?> HTMLAttr, htmlProp :?> HTMLAttr with
                    | ClassName a, ClassName b -> (true, ClassName <| concatStrings [a;b] :> IHTMLProp)
                    | Style a, Style b -> (true, Style <| a @ b :> IHTMLProp)
                    | _ -> (false, htmlProp)

                let addProp (prop: IHTMLProp) (htmlProps: IHTMLProp list) =
                    let len = htmlProps |> List.length
                    if len > 0 then
                        htmlProps |> List.map
                            (fun htmlProp ->
                                let (combined, newProp) = combineProp prop htmlProp
                                if combined then newProp
                                else htmlProp
                            )
                    else [prop]

                let addProps (props: HTMLProps) (htmlProps: HTMLProps) =
                    props |> List.fold (fun acc prop -> acc |> addProp prop) htmlProps 