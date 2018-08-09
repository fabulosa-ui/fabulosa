module ButtonPage

module R = Fable.Helpers.React
open R.Props
open Fable.Import.Browser
open Fabulosa
open Fabulosa.Index

let view () =
    R.div [ClassName "container"; Id "buttons"] [
        R.h2 [ClassName "s-title"] [R.str "Buttons"]
        R.p [] [R.str "Buttons include simple button styles for actions in different types and sizes."]
        R.h4 [] [R.str "Kinds"]
        R.div [ClassName "docs-demo columns"] [
            R.div [ClassName "column col-12"] [
                Button.ƒ Button.defaults [R.str "Default"]
                R.RawText "\n"
                Button.ƒ
                    { Button.defaults with
                        Kind = Button.Kind.Primary }
                    [R.str "Primary"]
                R.RawText "\n"
                Button.ƒ
                    { Button.defaults with
                        Kind = Button.Kind.Link }
                    [R.str "Link"]
            ]
        ]
        R.div [] [
            R.h4 [] [R.str "Sizes"]
            Button.ƒ
                { Button.defaults with
                    Size = Button.Size.Small }    
                [R.str "Small"]
            R.RawText "\n"
            Button.ƒ Button.defaults [R.str "Default"]
            R.RawText "\n"
            Button.ƒ
                { Button.defaults with
                    Size = Button.Size.Large }
                [R.str "Large"]
        ]
        R.div [] [
            R.h4 [] [R.str "Colors"]
            Button.ƒ
                { Button.defaults with
                    Color = Button.Color.Success }
                [R.str "Success"]
            R.RawText "\n"
            Button.ƒ
                { Button.defaults with
                    Kind = Button.Kind.Primary }
                [R.str "Default"]
            R.RawText "\n"
            Button.ƒ
                { Button.defaults with
                    Color = Button.Color.Error }
                [R.str "Error"]
        ]
        R.div [] [
            R.h4 [] [R.str "Formats"]
            Button.ƒ
                { Button.defaults with
                    Format = Button.Format.SquaredAction
                    Kind = Button.Kind.Primary }
                [ Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Plus } [] ]
            R.RawText "\n"
            Button.ƒ
                { Button.defaults with
                    Format = Button.Format.RoundAction }
                [ Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Plus } [] ]
        ]
        R.div [] [
            R.h4 [] [R.str "States"]
            Button.ƒ
                { Button.defaults with
                    State = Button.State.Disabled }
                [R.str "Disabled"]
            R.RawText "\n"
            Button.ƒ
                { Button.defaults with
                    State = Button.State.Active }
                [R.str "Active"]
            R.RawText "\n"
            Button.ƒ
                { Button.defaults with
                    State = Button.State.Loading }
                [R.str "Cool"]
        ]
        R.div [] [
            R.h4 [] [R.str "Group"]
            ButtonGroup.ƒ ButtonGroup.defaults [
                Button.ƒ
                    Button.defaults
                    [R.str "First"]
                R.RawText "\n"
                Button.ƒ
                    Button.defaults
                    [R.str "Second"]
            ]
        ]
    ]
