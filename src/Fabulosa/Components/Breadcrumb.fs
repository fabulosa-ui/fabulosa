namespace Fabulosa

module Breadcrumb =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open Fable.Import.React
    module P = R.Props
    
    type Href = string
        
    type BreadcrumbLinkRequired =
        | Href of Href

    type BreadcrumbLink =
        P.HTMLProps * BreadcrumbLinkRequired * FabulosaText

    let breadcrumbLink ((opt, (Href hrf), (Text txt)): BreadcrumbLink) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "breadcrumb-item")
        |> P.merge
        |> R.div
        <| [ R.a [ P.Href hrf ] [ R.str txt ] ]

    type BreadcrumbTextOptional = P.HTMLProps
    
    type BreadcrumbText =
        BreadcrumbTextOptional * FabulosaText

    let breadcrumbText ((opt, (Text txt)): BreadcrumbText) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "breadcrumb-item")
        |> P.merge
        |> R.div
        <| [ R.str txt ]

    type BreadcrumbElementsOptional = P.HTMLProps
    
    type BreadcrumbElementsChildren = ReactElement list

    type BreadcrumbElements =
        BreadcrumbElementsOptional * BreadcrumbElementsChildren

    let breadcrumbElements ((opt, chi): BreadcrumbElements) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "breadcrumb-item")
        |> P.merge
        |> R.div
        <| chi

    type BreadcrumbOptional = P.HTMLProps
    
    type BreadcrumbChildren =
        | Elements of BreadcrumbElements
        | Link of BreadcrumbLink
        | String of BreadcrumbText

    type Breadcrumb =
        BreadcrumbOptional * BreadcrumbChildren list

    let breadcrumb ((opt, chi): Breadcrumb) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "breadcrumb")
        |> P.merge
        |> R.ul
        <| List.map
            (function
             | Elements elements -> breadcrumbElements elements
             | Link link -> breadcrumbLink link
             | String text -> breadcrumbText text)
            chi
