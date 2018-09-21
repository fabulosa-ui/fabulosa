namespace Fabulosa

[<RequireQualifiedAccess>]
module Select =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    module Option =
        
        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: IHTMLProp list }

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let defaults =
            { Props.HTMLProps = [] }

        let ƒ (option: T) =
            let props, children = option
            props.HTMLProps
            |> R.option <| children

        let render = ƒ

    module OptionGroup =
    
        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: IHTMLProp list }

        [<RequireQualifiedAccess>]
        type T = Props * Option.T list

        let defaults =
            { Props.HTMLProps = [] }

        let ƒ (optionGroup: T) =
            let props, children = optionGroup
            props.HTMLProps
            |> R.optgroup
            <| Seq.map Option.ƒ children

        let render = ƒ

    [<RequireQualifiedAccess>]
    type Size =
    | Small
    | Large
    | Unset

    [<RequireQualifiedAccess>]
    type Props =
        { Size: Size
          HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    type Child =
    | OptionGroup of OptionGroup.T
    | Option of Option.T

    [<RequireQualifiedAccess>]
    type Children = Child list

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let defaults =
        { Props.Size = Size.Unset
          Props.HTMLProps = [] }

    let private size =
        function
        | Size.Small -> "select-sm"
        | Size.Large -> "select-lg"
        | Size.Unset -> ""
        >> ClassName

    let private renderChild =
        function
        | Child.OptionGroup (props, children) ->
            OptionGroup.ƒ (props, children)
        | Child.Option (props, children) ->
            Option.ƒ (props, children)

    let ƒ (select: T) =
        let props, children = select
        props.HTMLProps
        |> addProps
            [ ClassName "form-select"
              size props.Size ]
        |> R.select
        <| Seq.map renderChild children

    let render = ƒ
