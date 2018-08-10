module Home

module R = Fable.Helpers.React
open R.Props
open Fabulosa

let view () =
    Grid.ƒ Grid.defaults [
        R.h2 [ClassName "s-title"] [R.str "Home"]
        R.p [ClassName "s-description"] [R.str "Spectre CSS components for fable."]
    ]