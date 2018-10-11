namespace Fabulosa

[<RequireQualifiedAccess>]
module Navbar =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    module Section =

        [<RequireQualifiedAccess>]
        type T = Props * ReactElement list

        let ƒ (section: T) =
            let props, children = section
            props.HTMLProps
            |> addProp (ClassName "navbar-section")
            |> R.section <| children

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Center =

        [<RequireQualifiedAccess>]
        type T = Props * ReactElement list

        let ƒ (center: T) =
            let props, children = center
            props.HTMLProps
            |> addProp (ClassName "navbar-center")
            |> R.section <| children

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Brand =

        [<RequireQualifiedAccess>]
        type T = Props * ReactElement list

        let ƒ (brand: T) =
            let props, children = brand
            props.HTMLProps
            |> addProp (ClassName "navbar-brand")
            |> R.a <| children

        let render = ƒ

    [<RequireQualifiedAccess>]
    type Child<'Brand, 'Section, 'Center> =
    | Brand of 'Brand
    | Section of 'Section
    | Center of 'Center

    [<RequireQualifiedAccess>]
    type private Children<'Brand, 'Section, 'Center> =
        Child<'Brand, 'Section, 'Center> list

    let props =
        { Props.HTMLProps = [] }
        
    [<RequireQualifiedAccess>]
    type T<'Brand, 'Section, 'Center> =
        Props * Children<'Brand, 'Section, 'Center>

    let build
        brandƒ
        sectionƒ
        centerƒ
        (navbar: T<'Brand, 'Section, 'Center>) =
        let props, children = navbar
        props.HTMLProps
        |> addProp (ClassName "navbar")
        |> R.header
        <| Seq.map
            (function
             | Child.Brand brand ->
                 brandƒ brand
             | Child.Section section ->
                 sectionƒ section
             | Child.Center center ->
                 centerƒ center)
            children

    let ƒ = build Brand.ƒ Section.ƒ Center.ƒ
