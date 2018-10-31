namespace Fabulosa

module Accordion =

    open Fabulosa.Extensions
    open Fabulosa.Icon
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    type AccordionItemOptional =
        | Icon of Icon
        interface IHTMLProp

    type AccordionHeader =
        | Header of string

    type AccordionBody =
        | Body of (ReactElement list)

    type AccordionItemChildren =
        AccordionHeader * AccordionBody

    type AccordionItem =
        HTMLProps * AccordionItemChildren

    let private someIcon (optional: IHTMLProp) =
        match optional with
        | :? AccordionItemOptional as prop ->
            match prop with
            | Icon props -> Some props
        | _ -> None

    let private createIcon opt =
        opt
        |> List.tryPick someIcon
        |> Option.orElse (Some ([], Icon.Kind ArrowRight))
        |> Option.map (fun (iconOpt, iconReq) ->
             (Unmerged iconOpt
              |> addProp (ClassName "mr-1")
              |> merge, iconReq))
        |> Option.get

    let private item ((opt, (Header header, Body body)): AccordionItem) =
        let icn = createIcon opt
        R.details
            [ ClassName "accordion" ]
            [ R.summary
                [ ClassName "accordion-header" ]
                [ icon icn
                  R.RawText "\n"
                  R.str header ]
              R.div
                [ ClassName "accordion-body" ]
                [ R.ul
                     [ ClassName "menu menu-nav"] 
                     [ R.li
                        [ ClassName "menu-item" ]
                        body ] ] ]

    type AccordionChild =
        Item of AccordionItem
    
    type Accordion =
        HTMLProps * AccordionChild list

    let accordion (comp: Accordion) =
        let opt, chi = comp
        R.div
            opt
            (Seq.map
               (fun (Item itm) -> item itm)
               chi)