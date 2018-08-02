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
            Button.button Button.defaults [R.str "Default"]
            Button.button {
                Button.defaults with
                    Kind = Button.Primary
                    HTMLProps = [OnClick (fun e -> e |> console.log)] } [R.str "Primary"]
            Button.button {
                Button.defaults with
                    Kind = Button.Link
                    HTMLProps = [OnClick (fun e -> e |> console.log)] } [R.str "Link"]
        ]
        R.div [] [
            R.h4 [] [R.str "Sizes"]
            Button.button {
                Button.defaults with
                    Size = Button.Small
                    HTMLProps = [OnClick (fun e -> e |> console.log)] } [R.str "Small"]
            Button.button Button.defaults [R.str "Default"]
            Button.button {
                Button.defaults with
                    Size = Button.Large
                    HTMLProps = [OnClick (fun e -> e |> console.log)] } [R.str "Large"]
        ]
        R.div [] [
            R.h4 [] [R.str "Colors"]
            Button.button {
                Button.defaults with
                    Color = Button.Success
                    HTMLProps = [OnClick (fun e -> e |> console.log)] } [R.str "Success"]
            Button.button {
                Button.defaults with
                    Kind = Button.Primary
                    HTMLProps = [OnClick (fun e -> e |> console.log)] } [R.str "Default"]
            Button.button {
                Button.defaults with
                    Color = Button.Error
                    HTMLProps = [OnClick (fun e -> e |> console.log)] } [R.str "Error"]
        ]
        R.div [] [
            R.h4 [] [R.str "Formats"]
            Button.button {
                Button.defaults with
                    Format = Button.SquaredAction
                    HTMLProps = [OnClick (fun e -> e |> console.log)] } [R.str "+"]
            Button.button {
                Button.defaults with
                    Format = Button.RoundAction
                    HTMLProps = [OnClick (fun e -> e |> console.log)] } [R.str "+"]
        ]
        R.div [] [
            R.h4 [] [R.str "States"]
            Button.button {
                Button.defaults with
                    State = Button.Disabled
                    HTMLProps = [OnClick (fun e -> e |> console.log)] } [R.str "Disabled"]
            Button.button {
                Button.defaults with
                    State = Button.Active
                    HTMLProps = [OnClick (fun e -> e |> console.log)] } [R.str "Active"]
            Button.button {
                Button.defaults with
                    State = Button.Loading
                    HTMLProps = [OnClick (fun e -> e |> console.log)] } [R.str "Loading"]
        ]
    ]