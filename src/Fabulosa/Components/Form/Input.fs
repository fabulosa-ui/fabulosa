namespace Fabulosa

module Input =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    type Size =
        | Small
        | Large

    type InputOptional =
        | Size of Size
        interface IHTMLProp

    type Input = HTMLProps

    let private propToClassName (prop: IHTMLProp) =
        match prop with
        | :? InputOptional as opt ->
            match opt with
            | Size Small -> "input-sm"
            | Size Large -> "input-lg"
            |> className
        | _ -> prop

    let input (opt: Input) =
        Unmerged opt
        |> addProp (ClassName "form-input")
        |> map propToClassName
        |> merge
        |> R.input

module IconInput =

    open Fabulosa.Icon
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    module P = R.Props
    open Input

    type IconInputChildInput =
        | Input of Input

    type private IconInputChildIconChild =
        | Icon of Icon

    type IconInputChildIcon =
        | LeftIcon of Icon
        | RightIcon of Icon

    type IconInput = P.HTMLProps * (IconInputChildIcon * IconInputChildInput)

    let private childToClassName =
        function
        | LeftIcon li -> "has-icon-left"
        | RightIcon ri -> "has-icon-right"
        >> P.className

    let private iconChild =
        function
        | LeftIcon li -> li
        | RightIcon ri -> ri

    let iconInput ((opt, (icn, (Input inp))): IconInput) =
        let className = childToClassName icn
        let (icnOpt, icnReq) = iconChild icn
        let icn = 
            (P.Unmerged icnOpt
            |> P.addProp (P.ClassName "form-icon")
            |> P.merge, icnReq)
        R.div [ className ]
            [ input inp
              icon icn ]

module InputGroup =

    open Fabulosa.Extensions
    open Fabulosa.Button
    module R = Fable.Helpers.React
    open R.Props
    open Input
    open Fabulosa.Select
    
    type InputGroupAddonRight =
        | Button of Button option

    type InputGroupAddonLeft =
        | Text of string option
        
    type InputGroupOptional =
        | Inline
        interface IHTMLProp

    type InputGroupChild =
        | Input of Input
        | Select of Select

    type InputGroup =
        HTMLProps * (InputGroupAddonLeft * InputGroupChild list * InputGroupAddonRight)

    let private btn =
        function
        | Button (Some (opt, chi)) ->
            button
                (Unmerged opt
                |> addProp (ClassName "input-group-btn")
                |> merge, chi)
        | _ -> R.ofOption None

    let private txt =
        function
        | Text (Some text) ->
            R.span
                [ ClassName "input-group-addon" ]
                [ R.str text ]
        | _ -> R.ofOption None

    let private propToClassName (prop: IHTMLProp) =
        match prop with
        | :? InputGroupOptional as opt ->
            match opt with
            | Inline -> className "input-inline"
        | _ -> prop

    let inputGroup ((opt, (addl, chi, addr)): InputGroup) =
        Unmerged opt
        |> addProp (ClassName "input-group")
        |> map propToClassName
        |> merge
        |> R.div
        <| [ txt addl
             R.fragment
               []
               (Seq.map
                  (function
                   | Input i -> input i
                   | Select s -> select s)
                  chi)
             btn addr ]
