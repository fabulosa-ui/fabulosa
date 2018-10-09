namespace Fabulosa

[<RequireQualifiedAccess>]
module Select =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    module Option =
        
        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: IHTMLProp list }

        [<RequireQualifiedAccess>]
        type Children = string

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = [] }

        let build (option: T) =
            let props, children = option
            props.HTMLProps
            |> R.option
            <| [ R.str children ]

        let ƒ = build

    module OptionGroup =
    
        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: IHTMLProp list }

        [<RequireQualifiedAccess>]
        type T<'Option> = Props * 'Option list

        let props =
            { Props.HTMLProps = [] }

        let build optionƒ (optionGroup: T<'Option>) =
            let props, children = optionGroup
            props.HTMLProps
            |> R.optgroup
            <| Seq.map optionƒ children

        let ƒ = build Option.ƒ

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
    type Child<'Group, 'Option> =
    | Group of 'Group
    | Option of 'Option

    [<RequireQualifiedAccess>]
    type Children<'Group, 'Option> =
        Child<'Group, 'Option> list

    [<RequireQualifiedAccess>]
    type T<'Group, 'Option> =
        Props * Children<'Group, 'Option>

    let props =
        { Props.Size = Size.Unset
          Props.HTMLProps = [] }

    let private size =
        function
        | Size.Small -> "select-sm"
        | Size.Large -> "select-lg"
        | Size.Unset -> ""
        >> ClassName

    let build groupƒ optionƒ (select: T<'Group, 'Option>) =
        let props, children = select
        props.HTMLProps
        |> addProps
            [ ClassName "form-select"
              size props.Size ]
        |> R.select
        <| Seq.map
            (function
             | Child.Group group -> groupƒ group
             | Child.Option option -> optionƒ option)
            children

    let ƒ = build OptionGroup.ƒ Option.ƒ
