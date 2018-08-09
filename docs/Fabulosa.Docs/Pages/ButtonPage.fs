module ButtonPage

module R = Fable.Helpers.React
open R.Props
open Fabulosa
open Fabulosa.Docs.JavascriptMapping

let buttonKindSnippet = """(* Default Button *)
Button.ƒ Button.defaults [R.str "Default"]

(* Primary Button *)
Button.ƒ {
    Button.defaults with
        Kind = Button.Kind.Primary
} [R.str "Primary"]

(* Link Button *)
Button.ƒ {
    Button.defaults with
        Kind = Button.Kind.Link
} [R.str "Link"]
"""


let buttonSizeSnippet = """(* Small Button *)
Button.ƒ {
    Button.defaults with
        Size = Button.Size.Small
} [R.str "Small"]

(* Medium Button *)
Button.ƒ Button.defaults [R.str "Default"]

(* Large Button *)
Button.ƒ {
    Button.defaults with
        Size = Button.Size.Large
} [R.str "Large"]
"""

let buttonColorSnippet = """(* Success Button *)
Button.ƒ {
    Button.defaults with
        Color = Button.Color.Success
} [R.str "Success"]

(* Error Button *)
Button.ƒ {
    Button.defaults with
        Color = Button.Color.Error
} [R.str "Error"]
"""

let buttonFormatSnippet = """(* Squared Action Button *)
Button.ƒ {
    Button.defaults with
        Format = Button.Format.SquaredAction
        Kind = Button.Kind.Primary
} [ Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Plus } [] ]

(* Round Action Button *)
Button.ƒ {
    Button.defaults with
        Format = Button.Format.RoundAction
} [ Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Plus } [] ]
"""

let buttonStateSnippet = """(* Disabled Button *)
Button.ƒ {
    Button.defaults with
        State = Button.State.Disabled
} [R.str "Disabled"]

(* Active Button *)
Button.ƒ {
    Button.defaults with
        State = Button.State.Active
} [R.str "Active"]

(* Loading Button *)
Button.ƒ {
    Button.defaults with
        State = Button.State.Loading
} [R.str "----"]
"""

let buttonGroupSnippet = """(* Button Group *)
ButtonGroup.ƒ ButtonGroup.defaults [
    Button.ƒ Button.defaults [R.str "First"]
    Button.ƒ Button.defaults [R.str "Second"]
    Button.ƒ Button.defaults [R.str "Third"]
]
"""

let view () =
    Grid.ƒ Grid.defaults [
        R.h2 [ClassName "s-title"]
            [R.str "Buttons"]
        R.p [ClassName "s-description"]
            [R.str "Buttons include simple button styles for actions
                in different types and sizes."]
        R.h4 [ClassName "s-title"]
            [R.str "Kinds"]
        Grid.Row.ƒ {
            Grid.Row.defaults with HTMLProps = [ClassName "docs-demo"]
        } [
            Grid.Column.ƒ {
                Grid.Column.defaults with Size = 12
            } [
                Button.ƒ Button.defaults [R.str "Default"]
                R.RawText "\n"
                Button.ƒ {
                    Button.defaults with
                        Kind = Button.Kind.Primary
                } [R.str "Primary"]
                R.RawText "\n"
                Button.ƒ {
                    Button.defaults with
                        Kind = Button.Kind.Link
                } [R.str "Link"]
            ]
        ]
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Code.ƒ {
                    Code.defaults with 
                        Code = Highlight.fsharp buttonKindSnippet
                }
            ]
        ]
        R.h4 [ClassName "s-title"] [R.str "Sizes"]
        Grid.Row.ƒ {
            Grid.Row.defaults
                with HTMLProps = [ClassName "docs-demo"]
        } [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Button.ƒ {
                    Button.defaults with
                        Size = Button.Size.Small
                } [R.str "Small"]
                R.RawText "\n"
                Button.ƒ Button.defaults [R.str "Default"]
                R.RawText "\n"
                Button.ƒ {
                    Button.defaults with
                        Size = Button.Size.Large
                } [R.str "Large"]
            ]
        ]
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Code.ƒ {
                    Code.defaults with 
                        Code = Highlight.fsharp buttonSizeSnippet
                }
            ]
        ]
        R.h4 [ClassName "s-title"] [R.str "Colors"]
        Grid.Row.ƒ {
            Grid.Row.defaults with HTMLProps = [ClassName "docs-demo"]
        } [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Button.ƒ {
                    Button.defaults with
                        Color = Button.Color.Success
                } [R.str "Success"]
                R.RawText "\n"
                Button.ƒ {
                    Button.defaults with
                        Color = Button.Color.Error
                } [R.str "Error"]
            ]
        ]
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Code.ƒ {
                    Code.defaults with 
                        Code = Highlight.fsharp buttonColorSnippet
                }
            ]
        ]
        R.h4 [ClassName "s-title"] [R.str "Formats"]
        Grid.Row.ƒ {
            Grid.Row.defaults with HTMLProps = [ClassName "docs-demo"]
        } [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Button.ƒ {
                    Button.defaults with
                        Format = Button.Format.SquaredAction
                        Kind = Button.Kind.Primary
                } [ Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Plus } [] ]
                R.RawText "\n"
                Button.ƒ {
                    Button.defaults with
                        Format = Button.Format.RoundAction
                } [ Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Plus } [] ]
            ]
        ]
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Code.ƒ {
                    Code.defaults with 
                        Code = Highlight.fsharp buttonFormatSnippet
                }
            ]
        ]
        R.h4 [ClassName "s-title"] [R.str "States"]
        Grid.Row.ƒ {
            Grid.Row.defaults with HTMLProps = [ClassName "docs-demo"]
        } [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Button.ƒ {
                    Button.defaults with
                        State = Button.State.Disabled
                } [R.str "Disabled"]
                R.RawText "\n"
                Button.ƒ {
                    Button.defaults with
                        State = Button.State.Active
                } [R.str "Active"]
                R.RawText "\n"
                Button.ƒ {
                    Button.defaults with
                        State = Button.State.Loading
                } [R.str "Cool"]
            ]
        ]
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Code.ƒ {
                    Code.defaults with 
                        Code = Highlight.fsharp buttonStateSnippet
                }
            ]
        ]
        R.h4 [ClassName "s-title"] [R.str "Group"]
        Grid.Row.ƒ {
            Grid.Row.defaults with HTMLProps = [ClassName "docs-demo"]
        } [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                ButtonGroup.ƒ ButtonGroup.defaults [
                    Button.ƒ Button.defaults [R.str "First"]
                    R.RawText "\n"
                    Button.ƒ Button.defaults [R.str "Second"]
                    R.RawText "\n"
                    Button.ƒ Button.defaults [R.str "Third"]
                ]
            ]
        ]
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Code.ƒ {
                    Code.defaults with 
                        Code = Highlight.fsharp buttonGroupSnippet
                }
            ]
        ]
    ]
