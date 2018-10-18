﻿module ModalTests

open Expecto
open Fabulosa
open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Expect
open ReactNode

[<Tests>]
let headerTests =
    testList "Modal Header tests" [
        test "renders with text" {
            let child = R.div [P.ClassName "modal-title h5"] [R.str "Ciro 12"] |> ReactNode.unit 
            let header = Modal.Header.props, Modal.Header.Children.Text "Ciro 12"
            
            header
            |> Modal.Header.ƒ 
            |> ReactNode.unit
            |> hasChild 1 child
        }
        
        test "renders with element" {
            let complexChildContent = R.div [P.ClassName "h1"] [R.str  "Cirão da Massa"]
            let child = complexChildContent |> ReactNode.unit 
            let header = Modal.Header.props, Modal.Header.Children.Elements [complexChildContent]
        
            header
            |> Modal.Header.ƒ
            |> ReactNode.unit
            |> hasChild 1 child
        }
        
        test "renders props" {
            let complexChildContent = R.div [P.ClassName "h1"] [R.str  "Cirão da Massa"]
            let child = complexChildContent |> ReactNode.unit 
            let props = { Modal.Header.props with HTMLProps = [P.Id "hello-world"] } 
            let header = props, Modal.Header.Children.Elements [complexChildContent]
        
            header
            |> Modal.Header.ƒ 
            |> ReactNode.unit
            |>! hasProp (P.Id "hello-world")
            |> hasChild 1 child
        }
    ]

[<Tests>]
let footerTests =    
    testList "Modal Footer" [
        test "renders with element" {
            let content = R.div [P.ClassName "h1"] [R.str  "Cirão da Massa"]
            let child = content |> ReactNode.unit 
            let footer = Modal.Footer.props, Modal.Footer.Children.Elements [content] 
        
            footer
            |> Modal.Footer.ƒ 
            |> ReactNode.unit
            |>! hasUniqueClass "modal-footer"
            |> hasChild 1 child
        }
        
        test "renders with buttons" {
            let buttons: Button list = [
                [ Kind Primary ], [R.str "Submit"]
                [ Kind Link ], [R.str "Close"]
            ]
            let primaryButton = buttons.[0] |> button |> ReactNode.unit 
            let linkButton = buttons.[1] |> button |> ReactNode.unit 
            let footer = Modal.Footer.props, Modal.Footer.Children.Buttons buttons
        
            footer
            |> Modal.Footer.ƒ 
            |> ReactNode.unit
            |>! hasUniqueClass "modal-footer"
            |>! hasChild 1 primaryButton
            |> hasChild 1 linkButton
        }
        
        test "renders props" {
            let complexChildContent = R.div [P.ClassName "h1"] [R.str  "Cirão da Massa"]
            let child = complexChildContent |> ReactNode.unit 
            let props = { Modal.Footer.props with HTMLProps = [P.Id "hello-world"] } 
            let footer = props, Modal.Footer.Children.Elements [complexChildContent]
        
            footer
            |> Modal.Footer.ƒ 
            |> ReactNode.unit
            |>! hasProp (P.Id "hello-world")
            |> hasChild 1 child
        }
    ]
    
[<Tests>]
let modalTests =    
    testList "Modal" [
        test "renders default props" {
              let modal = (Modal.props, Modal.children) |> Modal.ƒ |> ReactNode.unit

              modal
              |>! hasClass "modal active"
              |>! hasDescendentClass "modal-overlay modal-container modal-body"
              |>! hasNoDescendentClass "modal-header modal-footer"
              |> hasText ""
        }
        
        test "renders props" {
            let props =  { Modal.props with HTMLProps = [P.Id "pele"] }
            (props, Modal.children)
            |> Modal.ƒ
            |> ReactNode.unit
            |>! hasProp (P.Id "pele")
            |>! hasClass "modal active"
            |>! hasDescendentClass "modal-container"
            |>! hasDescendentClass "modal-body"
            |> hasText ""
        }
        
        test "configures OnClose overlay" {
            let happyFunction parms = ()
            let overlay = R.a [P.ClassName "modal-overlay"; P.OnClick happyFunction] []
            let buttonClose = R.a [P.ClassName "btn btn-clear float-right"; P.OnClick happyFunction] []

            let props =
                { Modal.props with
                    OnRequestClose = happyFunction |> Some }
            (props, Modal.children)
            |> Modal.ƒ
            |> ReactNode.unit
            |>! hasClass "modal active"
            |>! hasChild 1 (overlay |> ReactNode.unit)
            |>! hasChild 1 (buttonClose |> ReactNode.unit)
            |>! hasDescendentClass "modal-header"
            |>! hasDescendentClass "modal-container"
            |>! hasDescendentClass "modal-body"
            |> hasText ""
        }
        
        test "configures size" {
            let propsSmall =  { Modal.props with Size = Modal.Size.Small }
            let propsMedium =  { Modal.props with Size = Modal.Size.Medium }
            let propsLarge =  { Modal.props with Size = Modal.Size.Large }
            
            (propsSmall, Modal.children)
            |> Modal.ƒ
            |> ReactNode.unit
            |> hasClass "modal active modal-sm"
            
            (propsMedium, Modal.children)
            |> Modal.ƒ
            |> ReactNode.unit 
            |> hasClass "modal active"
            
            (propsLarge, Modal.children)
            |> Modal.ƒ 
            |> ReactNode.unit 
            |> hasClass "modal active modal-lg"
        }
        
        test "renders body contents" {
            let babyLookAtThisBody = R.str "I work out!"
            let children = { Modal.children with Body = [babyLookAtThisBody] }
            
            (Modal.props, children)
            |> Modal.ƒ  
            |> ReactNode.unit
            |> hasChild 1 (babyLookAtThisBody |> ReactNode.unit)
        }
        
        test "renders header contents" {
            let headerConfig = Modal.Header.props, (Modal.Header.Text "Ciro 12")
            let headerChild = headerConfig |> Modal.Header.ƒ |> ReactNode.unit
            let children = { Modal.children with Header = Some headerConfig }
            
            (Modal.props, children)
            |> Modal.ƒ  
            |> ReactNode.unit
            |>! hasDescendentClass "modal-header"
            |> hasChild 1 headerChild
        }
    ]
    