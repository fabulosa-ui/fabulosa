module GridPage

module R = Fable.Helpers.React
open R.Props
open Fabulosa

open Fable.Import.React

let cols: seq<ReactElement> = seq {
    for n in 1 .. 11 do
        yield Grid.Row.ƒ
            { Grid.Row.defaults with Gapless = true } [
            Grid.Column.ƒ { Grid.Column.defaults with Size = n } [
                R.div [ Style [ Background "#f8f9fa" ] ] [ R.str ("c " + n.ToString()) ]
            ]
            Grid.Column.ƒ { Grid.Column.defaults with Size = (12 - n) } [
                R.div [ Style [ Background "#f8f9fa" ] ] [ R.str ("c " + (12 - n).ToString()) ]
            ]
        ]
}

let view () =
    R.div [] [
        R.h2 [ClassName "s-title"] [R.str "Grid"]
        R.p [] [R.str "Layout includes flexbox based responsive grid system with 12 columns."]
        Grid.ƒ Grid.defaults (Seq.toList cols)
    ]