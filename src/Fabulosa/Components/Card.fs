﻿namespace Fabulosa

module Card =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props
    open Fabulosa.Media.Image

    type Text = string

    type ReactElements = ReactElement list

    type HeaderTitle =
        Title of Text

    type HeaderSubTitle =
        SubTitle of Text

    type HeaderChildren =
        HeaderTitle * HeaderSubTitle

    type Header =
        HTMLProps * HeaderChildren

    let cardHeader (c: Header) =
        let opt, (Title title, SubTitle subTitle) = c
        Unmerged opt
        |> addProp (ClassName "card-header")
        |> merge
        |> R.div
        <| [ R.div
              [ ClassName "card-title h5" ]
              [ R.str title ]
             R.div
              [ ClassName "card-subtitle text-gray" ]
              [ R.str subTitle ] ]

    type Body = HTMLProps * ReactElements

    let cardBody (c: Body) =
        let opt, chi = c
        if not (List.isEmpty chi) then
            Unmerged opt
            |> addProp (ClassName "card-body")
            |> merge
            |> R.div <| chi
        else
            R.ofOption None

    type Footer =
        HTMLProps * ReactElements

    let cardFooter (c: Footer) =
        let opt, chi = c
        if not (List.isEmpty chi) then
            Unmerged opt
            |> addProp (ClassName "card-footer")
            |> merge
            |> R.div <| chi
        else
            R.ofOption None

    type CardHeader =
        Header of Header

    type CardBody =
        Body of Body

    type CardFooter =
        Footer of Footer

    type CardImage =
        Image of Image

    type CardChildren =
        CardImage * CardHeader * CardBody * CardFooter
        
    type Card =
        HTMLProps * CardChildren

    let card (comp: Card) =
        let opt, (Image i, Header h, Body b, Footer f) = comp
        Unmerged opt
        |> addProp (ClassName "card")
        |> merge
        |> R.div <|
        [ cardHeader h
          R.div [ ClassName "card-image" ] [ image i ]
          cardBody b
          cardFooter f ]
