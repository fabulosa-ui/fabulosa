module Home

module R = Fable.Helpers.React

open R.Props

let view () =
    R.div [ClassName "container"] [
        R.h2 [ClassName "s-title"] [R.str "Home"]
        R.p [] [R.str "Spectre CSS components for fable."]
    ]