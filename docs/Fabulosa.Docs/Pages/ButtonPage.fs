module ButtonPage

module R = Fable.Helpers.React
open R.Props
open Fable.Import.Browser
open Fabulosa
open Fabulosa.Index

let view () =
    R.div [ClassName "buttons"] [
        Fi Button.defaults [R.str "Fi Button"]

        R.h2 [] [R.str "Buttons"]
        R.p [] [R.str "Buttons include simple button styles for actions in different types and sizes."]
        R.div [] [
            R.h4 [] [R.str "Kinds"]
            Responsive.ƒ { Responsive.defaults with Hide = Responsive.Size.XS } [
                Button.ƒ Button.defaults [R.str "Default"] ]
            Button.ƒ
                { Button.defaults with
                    Kind = Button.Kind.Primary
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Primary"]
            Button.ƒ
                { Button.defaults with
                    Kind = Button.Kind.Link
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Link"]
        ]
        R.div [] [
            R.h4 [] [R.str "Sizes"]
            Button.ƒ
                { Button.defaults with
                    Size = Button.Size.Small
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }    
                [R.str "Small"]
            Button.ƒ Button.defaults [R.str "Default"]
            Button.ƒ
                { Button.defaults with
                    Size = Button.Size.Large
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Large"]
        ]
        R.div [] [
            R.h4 [] [R.str "Colors"]
            Button.ƒ
                { Button.defaults with
                    Color = Button.Color.Success
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Success"]
            Button.ƒ
                { Button.defaults with
                    Kind = Button.Kind.Primary
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Default"]
            Button.ƒ
                { Button.defaults with
                    Color = Button.Color.Error
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Error"]
        ]
        R.div [] [
            R.h4 [] [R.str "Formats"]
            Button.ƒ
                { Button.defaults with
                    Format = Button.Format.SquaredAction
                    Kind = Button.Kind.Primary
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [ Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Plus } [] ]
            Button.ƒ
                { Button.defaults with
                    Format = Button.Format.RoundAction
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [ Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Plus } [] ]
        ]
        R.div [] [
            R.h4 [] [R.str "States"]
            Button.ƒ
                { Button.defaults with
                    State = Button.State.Disabled
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Disabled"]
            Button.ƒ
                { Button.defaults with
                    State = Button.State.Active
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Active"]
            Button.ƒ
                { Button.defaults with
                    State = Button.State.Loading
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Cool"]
        ]
    ]