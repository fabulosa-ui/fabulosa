module BreadcrumbTests

open Expecto
open Fabulosa
open Fabulosa.Breadcrumb
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Breadcrumbs" [
        test "display an empty container by default" {
            breadcrumb ([], [])
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb"
            |> hasNoChildren
        }
        
        test "receives HTMLProps" {
            breadcrumb ([ P.Id "hello-world" ], [])
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb"
            |>! hasProp (P.Id "hello-world")
            |> hasNoChildren
        }

        test "renders children" {
            let text = ([], Text "Ciro > Haddad")
            let link = ([], Href "cirogomes.com.br", Text "Ciro Gomes")
            let elements = ([], [ R.div [ P.ClassName "find-me" ] [] ])
            let children = 
                [ String text
                  Link link
                  Elements elements ]
            breadcrumb ([], children)
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb"
            |>! hasChild 1 (breadcrumbText text |> ReactNode.unit)
            |>! hasChild 1 (breadcrumbLink link |> ReactNode.unit)
            |> hasChild 1 (breadcrumbElements elements |> ReactNode.unit)

        }

    ]

[<Tests>]
let breadcrumbItemsTest =    
    testList "Breadcrumb items tests" [
        test "breadcrumb text defaults" {
            breadcrumbText ([], Text "Pele")
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb-item"
            |> hasText "Pele"
        }

        test "breadcrumb text optional props" {
            breadcrumbText ([ P.ClassName "custom" ], Text "Pele")
            |> ReactNode.unit
            |>! hasClass "breadcrumb-item custom"
            |> hasText "Pele"
        }

        test "breadcrumb link defaults" {
            breadcrumbLink ([], Href "#abc", Text "Pele")
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb-item"
            |>! hasDescendentProp (P.Href "#abc")
            |> hasText "Pele"
        }

        test "breadcrumb link optional props" {
            breadcrumbLink ([ P.ClassName "custom" ], Href "#abc", Text "Pele")
            |> ReactNode.unit
            |>! hasClass "breadcrumb-item custom"
            |>! hasDescendentProp (P.Href "#abc")
            |> hasText "Pele"
        }

        test "breadcrumb elements defaults" {
            let child = R.a [] [ R.str "Text" ]
            breadcrumbElements ([], [ child ])
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb-item"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "breadcrumb elements optional props" {
            breadcrumbElements ([ P.ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "breadcrumb-item custom"
        }
    ]