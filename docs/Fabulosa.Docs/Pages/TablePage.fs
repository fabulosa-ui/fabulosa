module TablePage

module R = Fable.Helpers.React
open R.Props
open Fabulosa

let view () =
    R.div [ClassName "container"] [
        R.h2 [ClassName "s-title"] [R.str "Table"]
        R.p [] [R.str "Tables include default styles for tables and data sets."]
        Table.ƒ { Table.defaults with Kind = Table.Kind.Striped } [
            Table.Head.ƒ Table.Head.defaults [
                Table.Row.ƒ Table.Row.defaults [
                    Table.TitleColumn.ƒ Table.TitleColumn.defaults [R.str "Column 1"]
                    Table.TitleColumn.ƒ Table.TitleColumn.defaults [R.str "Column 2"]
                    Table.TitleColumn.ƒ Table.TitleColumn.defaults [R.str "Column 3"]
                ]
            ]
            Table.Body.ƒ Table.Body.defaults [
                Table.Row.ƒ Table.Row.defaults [
                    Table.Column.ƒ Table.Column.defaults [R.str "Value 1"]
                    Table.Column.ƒ Table.Column.defaults [R.str "Value 2"]
                    Table.Column.ƒ Table.Column.defaults [R.str "Value 3"]
                ]
                Table.Row.ƒ Table.Row.defaults [
                    Table.Column.ƒ Table.Column.defaults [R.str "Value 4"]
                    Table.Column.ƒ Table.Column.defaults [R.str "Value 5"]
                    Table.Column.ƒ Table.Column.defaults [R.str "Value 6"]
                ]
                Table.Row.ƒ Table.Row.defaults [
                    Table.Column.ƒ Table.Column.defaults [R.str "Value 7"]
                    Table.Column.ƒ Table.Column.defaults [R.str "Value 8"]
                    Table.Column.ƒ Table.Column.defaults [R.str "Value 9"]
                ]
            ]
        ]
    ]