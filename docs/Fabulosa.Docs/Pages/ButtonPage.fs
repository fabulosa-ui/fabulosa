module ButtonPage

open Responsive
open Fable.Helpers.React.Props
open Fable.Import.Browser

module R = Fable.Helpers.React

let view () =
    R.div [] [
        responsiveP [ResponsiveHide ResponsiveSM] Button.button
            [Button.ButtonSize Button.ButtonSmall; Button.ButtonKind Button.ButtonPrimary]
            [OnClick (fun event -> event.target |> console.log)]
            [R.str "TEXT"]
    ]