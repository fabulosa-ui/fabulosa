﻿module ToastPage

open Fabulosa
open Fabulosa.Docs
open Fabulosa.Button
open Fabulosa.Toast
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer
open Microsoft.FSharp.Core
open Fable.Helpers.React.ReactiveComponents

type State =
    { Opened: bool }

type Message = 
    | Toggle

type Dispatch = Message -> unit

let init _ =
    { Opened = false }

let update message state =
    match message with 
    | Toggle ->
        { state with Opened = not state.Opened }

let toggler dispatch opened =
    button
        ([ ButtonOptional.Kind Kind.Primary
           P.OnClick
             (fun _ ->
                dispatch Toggle
                Fable.Import.JS.setTimeout
                  (fun () -> dispatch Toggle)
                  3000 |> ignore)
           P.Disabled opened ],
         [ R.str "Open" ])

let trigger dispatch opened =
    button
        ([ ButtonOptional.Kind Kind.Primary
           P.OnClick (fun _ -> dispatch Toggle)
           P.Disabled opened ],
         [ R.str "Open" ])

(*** define: toast-default-sample ***)
let def = toast ([], Text "Default toast")
(*** define: toast-primary-sample ***)
let primary dispatch =
    toast
        ([ Color Primary
           OnRequestClose (fun _ -> dispatch Toggle ) ],
         Text "You can close me!")
(*** hide ***)

let defaultView (model: Model<unit, State>) dispatch =
    let renderToast =
        if model.state.Opened then
            def
        else R.ofOption None
    R.div [] 
        [ toggler dispatch model.state.Opened
          renderToast ]

let primaryView (model: Model<unit, State>) dispatch =
    let renderToast =
        if model.state.Opened then
            primary dispatch
        else R.ofOption None
    R.div [] 
        [ trigger dispatch model.state.Opened
          renderToast ]

let demo view  =
    R.reactiveCom init update view "" () []

(*** hide ***)
let render () =
    tryMount "toast-default-demo" <| demo defaultView
    tryMount "toast-primary-demo" <| demo primaryView
    tryMount "toast-params-table"
        (PropTable.paramTable
            (Some typeof<ToastOptional>)
            None
            (Some typeof<FabulosaText>))
(**

<div id="toast">

<h2 class="s-title">Toast</h2>

Toasts are used to show alert
or information to users

#### Paramaters

<div class="props-table" id="toast-params-table"></div>

#### Example

A simple toast component with all defaults.

<div class="demo" id="toast-default-demo"></div>

*)
(*** include: toast-default-sample ***)
(**

#### Primary & Closeable

A toast with primary color
that you can close

<div class="demo" id="toast-primary-demo"></div>

*)
(*** include: toast-primary-sample ***)
(**

</div>

*)