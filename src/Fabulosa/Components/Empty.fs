namespace Fabulosa

module Empty =

    open Fabulosa.Extensions
    open Fabulosa.Icon
    open Fable.Import.React
    module R = Fable.Helpers.React
    module P = R.Props

    let emptyIcon ((opt, req): Icon) =
        R.div
            [ P.ClassName "empty-icon" ]
            [ icon ([ Size X3 ], req) ]

    type Title = string

    let emptyTitle (comp: Title) =
        R.p
            [ P.ClassName "empty-title h5" ]
            [ R.str comp ]

    type Subtitle = string

    let emptySubtitle (comp: Subtitle) =
        R.p
            [ P.ClassName "empty-subtitle" ]
            [ R.str comp ]

    type Action = ReactElement list

    type EmptyIcon =
        Icon of Icon

    type EmptyTitle =
        Title of Title

    type EmptySubtitle =
        Subtitle of Subtitle

    type EmptyAction =
        Action of Action

    let emptyAction (comp: Action) =
        R.div
            [ P.ClassName "empty-action" ]
            comp

    type EmptyChildren =
        EmptyIcon * EmptyTitle * EmptySubtitle * EmptyAction

    type Empty =
        P.HTMLProps * EmptyChildren

    let empty ((opt, (Icon i, Title t, Subtitle s, Action a)): Empty) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "empty")
        |> P.merge
        |> R.div <|
        [ emptyIcon i
          emptyTitle t
          emptySubtitle s
          emptyAction a ]
