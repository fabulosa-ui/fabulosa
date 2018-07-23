module GridPage

module R = Fable.Helpers.React
open Fable.Helpers.React.Props

open Grid
open Fable.Import.React

let cols: seq<ReactElement> = seq {
    for n in 1 .. 11 do
        yield columns [] [] [
            column [ ColumnSize n ] [] [
                R.div [ Style [ Background "#eee" ] ] [ R.str ("c " + n.ToString()) ]
            ]
            column [ ColumnSize (12 - n) ] [] [
                R.div [ Style [ Background "#eee" ] ] [ R.str ("c " + (12 - n).ToString()) ]
            ]
        ]
}

let view () =
    grid [] (Seq.toList cols)