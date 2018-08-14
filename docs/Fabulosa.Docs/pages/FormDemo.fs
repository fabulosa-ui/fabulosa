namespace Fabulosa.Docs

module FormDemo =

    open Fabulosa
    module R = Fable.Helpers.React
    open R.Props

    let input =
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ {
                Label.defaults with Text = "Name"
            }
            Input.ƒ {
                Input.defaults with
                    HTMLProps = [Placeholder "Please enter your name"]
            }
        ]

    let textarea =
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ {
                Label.defaults with Text = "Description"
            }
            Textarea.ƒ {
                Textarea.defaults with
                    HTMLProps = [Placeholder "Please enter a description"]
            } []
        ]

    let select =
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ {
                Label.defaults with Text = "Language"
            }
            Select.ƒ Select.defaults [
                Select.Option.ƒ Select.Option.defaults [R.str "English"]
                Select.Option.ƒ Select.Option.defaults [R.str "Spanish"]
                Select.Option.ƒ Select.Option.defaults [R.str "Assembly"]
            ]
        ]

    let render () =
        Renderer.tryMount "form-input-demo" input
        Renderer.tryMount "form-select-demo" select
        Renderer.tryMount "form-textarea-demo" textarea