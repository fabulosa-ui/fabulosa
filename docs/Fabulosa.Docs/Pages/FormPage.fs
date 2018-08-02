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
                            Label.label "Name"
                            Input.input [] [Placeholder "Please enter your name"]
                        ]
                        Form.group [] [
                            Label.label "Phone"
                            Input.input [] [Placeholder "Please enter your phone number"; Type "tel"]
                        ]
                        Form.group [] [
                            Label.label "Time"
                            IconInput.iconInput [IconInput.Position IconInput.Left] [] [
                                Input.input [] [Placeholder "Please enter something"]
                                Icon.i [Icon.Type Icon.Time] [] []
                            ]
                        ]
                        Form.group [] [
                            Label.label "Profile description"
                            Textarea.textarea [Placeholder "Please enter a description"] []
                        ]
                        Form.group [] [
                            Label.label "Contact preferences"
                            Radio.input [] [Name "contact-prefs"] "Call me"
                            Radio.input [] [Name "contact-prefs"] "Text me"
                        ]
                        Form.group [] [
                            Label.label "Profile preferences"
                            Switch.input [] "Link my github account"
                        ]
                        Form.group [] [
                            Checkbox.create [] [] "Remember me"
                            Checkbox.create [] [] "Forget me"
                        ]
                        Anchor.anchor Anchor.defaults [R.str "Submit"]
                    ]
                ]
            ]
        ]
    ]