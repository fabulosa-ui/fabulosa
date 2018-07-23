module GridPage

module R = Fable.Helpers.React
open Fable.Helpers.React.Props

open Grid
open Fable.Import.React

let cols: seq<ReactElement> = seq {
    for n in 1 .. 11 do
        yield Columns.columns [] [] [
            Column.column [ Column.Size n ] [] [
                R.div [ Style [ Background "#eee" ] ] [ R.str ("c " + n.ToString()) ]
            ]
            Column.column [ Column.Size (12 - n) ] [] [
                R.div [ Style [ Background "#eee" ] ] [ R.str ("c " + (12 - n).ToString()) ]
            ]
        ]
}

let view () =
    Grid.grid [] (Seq.toList cols)