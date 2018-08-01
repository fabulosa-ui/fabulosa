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
        Button.textButton "text"
            |> transform
            Button.propToClass
            [Button.Size Button.Small; Button.Kind Button.Primary]
        Button.button
            [Button.Kind Button.Default]
            [OnClick (fun event -> event.target |> console.log)]
            [R.str "Default"]
        Button.button
            [Button.Kind Button.Primary]
            [OnClick (fun event -> event.target |> console.log)]
            [R.str "Primary"]
        Button.button
            [Button.Kind Button.Link]
            [OnClick (fun event -> event.target |> console.log)]
            [R.str "Link"]
    ]