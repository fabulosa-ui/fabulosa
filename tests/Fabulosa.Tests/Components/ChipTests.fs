module ChipTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Chip tests" [

        test "Chip default" {
            Chip.ƒ
                Chip.defaults 
                []
            |> ReactNode.unit
            |> hasUniqueClass "chip"
        }

        test "Chip html props" {
            Chip.ƒ
                { Chip.defaults with 
                    HTMLProps = [ClassName "custom"] }
                []
            |> ReactNode.unit
            |> hasClass "chip custom"
        }

        test "Chip removable" {
            let onRemove = ignore
            printfn "%A" onRemove
            Chip.ƒ
                { Chip.defaults with
                    Removable = true
                    OnRemove = onRemove }
                []
            |> ReactNode.unit
            |> hasDescendentProp (OnClick onRemove)
        }

        // test "Chip with children" {
        //     let body = R.p [] [R.str "Body" ]
        //     let footer = Button.ƒ Button.defaults [R.str "Footer"]
        //     let imageProps =
        //         { Media.Image.defaults with
        //             HTMLProps = [Src "bla.png"] }
        //     let image = Media.Image.ƒ imageProps |> ReactNode.unit
        //     Chip.ƒ
        //         Chip.defaults
        //         []
        //     |> ReactNode.unit
        //     |> ignore
        // }
    ]