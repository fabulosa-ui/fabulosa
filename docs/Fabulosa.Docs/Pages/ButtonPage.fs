module ButtonPage

module R = Fable.Helpers.React
open R.Props
open Fable.Import.Browser
open Fabulosa

let view () =
    R.div [ClassName "buttons"] [
        R.h2 [] [R.str "Buttons"]
        R.p [] [R.str "Buttons include simple button styles for actions in different types and sizes."]
        R.div [] [
            R.h4 [] [R.str "Kinds"]
            Button.button
                Button.defaults
                [R.str "Default"]
            Button.button
                { Button.defaults with
                    Kind = Button.Kind.Primary
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Primary"]
            Button.button
                { Button.defaults with
                    Kind = Button.Kind.Link
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Link"]
        ]
        R.div [] [
            R.h4 [] [R.str "Sizes"]
            Button.button
                { Button.defaults with
                    Size = Button.Size.Small
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }    
                [R.str "Small"]
            Button.button
                Button.defaults
                [R.str "Default"]
            Button.button
                { Button.defaults with
                    Size = Button.Size.Large
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Large"]
        ]
        R.div [] [
            R.h4 [] [R.str "Colors"]
            Button.button
                { Button.defaults with
                    Color = Button.Color.Success
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Success"]
            Button.button
                { Button.defaults with
                    Kind = Button.Kind.Primary
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Default"]
            Button.button
                { Button.defaults with
                    Color = Button.Color.Error
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Error"]
        ]
        R.div [] [
            R.h4 [] [R.str "Formats"]
            Button.button
                { Button.defaults with
                    Format = Button.Format.SquaredAction
                    Kind = Button.Kind.Primary
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [Icon.i [Icon.Type Icon.Plus] [] []]
            Button.button
                { Button.defaults with
                    Format = Button.Format.RoundAction
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [Icon.i [Icon.Type Icon.Plus] [] []]
        ]
        R.div [] [
            R.h4 [] [R.str "States"]
            Button.button
                { Button.defaults with
                    State = Button.State.Disabled
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Disabled"]
            Button.button
                { Button.defaults with
                    State = Button.State.Active
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Active"]
            Button.button
                { Button.defaults with
                    State = Button.State.Loading
                    HTMLProps = [OnClick (fun e -> e |> console.log)] }
                [R.str "Cool"]
        ]
    ]