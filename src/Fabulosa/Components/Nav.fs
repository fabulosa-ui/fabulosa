namespace Fabulosa

module rec Nav =

    open Fabulosa.Extensions
    open Fable.Helpers.React.Props
    module R = Fable.Helpers.React

    type NavItem =
        HTMLProps * FabulosaText

    let navItem ((opt, (Text txt)): NavItem) =
        R.li
            [ ClassName "nav-item" ]
            [ R.a opt [ R.str txt ] ]

    type NavChild =
    | Item of NavItem
    | Nav of HTMLProps * NavChild seq

    type Nav = HTMLProps * NavChild seq

    let nav ((opt, chi): Nav) =
        Unmerged opt
        |> addProp (ClassName "nav")
        |> merge
        |> R.ul
        <| Seq.map
            (function
             | Item item -> navItem item
             | Nav (sOpt, sChi) -> nav (sOpt, sChi))
            chi
