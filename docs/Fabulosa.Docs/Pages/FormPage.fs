module FormPage

module R = Fable.Helpers.React
open R.Props
open Fabulosa

let view () =
    Fable.Helpers.React.div [] [
        R.h2 [] [R.str "Forms"]
        R.p [] [R.str "Forms provide the most common control styles used in forms, including input, textarea, select, checkbox, radio and switch."]
        Grid.grid [] [
            Grid.row [] [] [
                Grid.column [Grid.Column.Size 4] [] [
                    Fable.Helpers.React.form [] [
                        Form.group [] [
                            Label.label [] [Fable.Helpers.React.str "Name"]
                            Input.input [] [Placeholder "Please enter your name"]
                        ]
                        Form.group [] [
                            Label.label [] [Fable.Helpers.React.str "Phone"]
                            Input.input [] [Placeholder "Please enter your phone number"; Type "tel"]
                        ]
                        Form.group [] [
                            Label.label [] [R.str "Profile description"]
                            Textarea.textarea [Placeholder "Please enter a description"] []
                        ]
                        Form.group [] [
                            Label.label [] [R.str "Contact preferences"]
                            Checkbox.input [] "Call me"
                            Checkbox.input [] "Text me"
                        ]
                        Form.group [] [
                            Label.label [] [R.str "Profile preferences"]
                            Switch.input [] "Link my github account"
                        ]
                        Button.anchor [Button.Kind Button.Primary] [Style [MarginTop 10]] [R.str "Submit"]
                    ]
                ]
            ]
        ]
    ]