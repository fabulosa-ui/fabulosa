module Home

module R = Fable.Helpers.React

open Fable.Helpers.React.Props

let view () =
    R.div [ClassName "container"] [
        R.h1 [] [R.str "Home"]
    ]