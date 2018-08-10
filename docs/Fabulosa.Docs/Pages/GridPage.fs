module GridPage

module R = Fable.Helpers.React
open R.Props
open Fabulosa
open Fabulosa.Docs.JavascriptMapping
open Fable.Import.React

let gridSnippet = """(* Grid *)
Grid.ƒ Grid.defaults [
    Grid.Row.ƒ Grid.Row.defaults [
        Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
            R.str "My Column" 
        ]
    ]
]
"""

let cols: seq<ReactElement> = seq {
    for n in 1 .. 11 do
        yield Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = n } [
                R.div [ClassName "docs-grid-page-col"]
                    [ R.str ("col-" + n.ToString()) ]
            ]
            Grid.Column.ƒ { Grid.Column.defaults with Size = (12 - n) } [
                R.div [ClassName "docs-grid-page-col"]
                    [ R.str ("col-" + (12 - n).ToString()) ]
            ]
        ]
}

let view () =
    Grid.ƒ Grid.defaults [
        R.h2 [ClassName "s-title"] [R.str "Grid"]
        R.p [ClassName "s-description"] [R.str "Layout includes flexbox based responsive grid system with 12 columns."]
        Grid.ƒ Grid.defaults (Seq.toList cols)
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Code.ƒ {
                    Code.defaults with 
                        Code = Highlight.fsharp gridSnippet
                }
            ]
        ]
    ]