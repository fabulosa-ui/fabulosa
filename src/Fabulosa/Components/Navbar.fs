namespace Fabulosa

[<RequireQualifiedAccess>]
module Navbar =

    module R = Fable.Helpers.React

    open ClassNames

    let header =
        ["navbar"]
        |> combineProps
        >> R.header

    let section =
        ["navbar-section"]
        |> combineProps
        >> R.section

    let center =
        ["navbar-center"]
        |> combineProps
        >> R.section

    let brand  =
        ["navbar-brand"]
        |> combineProps
        >> R.a