module ButtonPage

module R = Fable.Helpers.React
open R.Props
open Fable.Import.Browser
open Fabulosa
open Fabulosa.ReactAPIExtensions

let view () =
    R.div [ClassName "buttons"] [
        R.h2 [] [R.str "Buttons"]
        R.p [] [R.str "Buttons include simple button styles for actions in different types and sizes."]
        Button.button Button.Defaults []
        Button.button {
            Button.Defaults with
                Kind = Button.Default
                HTMLProps = [OnClick (fun e -> e |> console.log)] } []
        Button.button {
            Button.Defaults with
                Kind = Button.Primary
                HTMLProps = [OnClick (fun e -> e |> console.log)] } []
        Button.button {
            Button.Defaults with
                Kind = Button.Link
                HTMLProps = [OnClick (fun e -> e |> console.log)] } []
    ]