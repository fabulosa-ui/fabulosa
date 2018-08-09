module FormPage

module R = Fable.Helpers.React
open R.Props
open Fabulosa
open Fabulosa.Docs.JavascriptMapping

let inputSnippet = """(* Form Group *)
Form.Group.ƒ Form.Group.defaults [

    (* First Name Input *)
    Label.ƒ { Label.defaults with Text = "First Name" }
    Input.ƒ {
        Input.defaults with
            HTMLProps = [Placeholder "Please enter your first name"]
    }

    (* Last Name Input *)
    Label.ƒ { Label.defaults with Text = "Last Name" }
    Input.ƒ {
        Input.defaults with
            HTMLProps = [Placeholder "Please enter your last name"]
    }
]
"""

let selectSnippet = """(* Form Group *)
Form.Group.ƒ Form.Group.defaults [

    (* Choose Animal Select *)
    Label.ƒ { Label.defaults with Text = "Choose Animal" }
    Select.ƒ Select.defaults [
        Select.Option.ƒ Select.Option.defaults [R.str "Dog"]
        Select.Option.ƒ Select.Option.defaults [R.str "Cat"]
        Select.Option.ƒ Select.Option.defaults [R.str "Parrot"]
    ]
]
"""

let view () =
    Grid.ƒ Grid.defaults [
        R.h2 [ClassName "s-title"]
            [R.str "Forms"]
        R.p [ClassName "s-description"]
            [R.str "Forms provide the most common control styles used
                in forms, including input, textarea, select,
                checkbox, radio and switch."]
        R.h4 [ClassName "s-title"]
            [R.str "Input"]
        Grid.Row.ƒ {
            Grid.Row.defaults with HTMLProps = [ClassName "docs-demo"]
        } [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Form.Group.ƒ Form.Group.defaults [
                    Label.ƒ { Label.defaults with Text = "First Name" }
                    Input.ƒ {
                        Input.defaults with
                            HTMLProps = [Placeholder "Please enter your first name"]
                    }
                    Label.ƒ { Label.defaults with Text = "Last Name" }
                    Input.ƒ {
                        Input.defaults with
                            HTMLProps = [Placeholder "Please enter your last name"]
                    }
                ]
            ]
        ]
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Code.ƒ {
                    Code.defaults with 
                        Code = Highlight.fsharp inputSnippet
                }
            ]
        ]
        R.h4 [ClassName "s-title"] [R.str "Select"]
        Grid.Row.ƒ {
            Grid.Row.defaults with HTMLProps = [ClassName "docs-demo"]
        } [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Form.Group.ƒ Form.Group.defaults [
                    Label.ƒ { Label.defaults with Text = "Choose Animal" }
                    Select.ƒ Select.defaults [
                        Select.Option.ƒ Select.Option.defaults [R.str "Dog"]
                        Select.Option.ƒ Select.Option.defaults [R.str "Cat"]
                        Select.Option.ƒ Select.Option.defaults [R.str "Parrot"]
                    ]
                ]
            ]
        ]
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Code.ƒ {
                    Code.defaults with 
                        Code = Highlight.fsharp selectSnippet
                }
            ]
        ]
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ { Label.defaults with Text = "Time" }
            IconInput.ƒ
                { IconInput.defaults with
                    InputProps =
                        { Input.defaults with
                            HTMLProps = [Placeholder "Please enter something"] };
                    IconProps = { Icon.defaults with Kind = Icon.Kind.Time } }
        ]
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ { Label.defaults with Text = "Profile description" }
            Textarea.ƒ
                { Textarea.defaults with
                    HTMLProps = [Placeholder "Please enter a description"] } []
        ]
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ { Label.defaults with Text = "Contact preferences" }
            Radio.ƒ
                { Radio.defaults with
                    HTMLProps = [Name "contact-prefs"];
                    Text = "Call me" }
                
            Radio.ƒ
                { Radio.defaults with
                    HTMLProps = [Name "contact-prefs"];
                    Text = "Text me" }
        ]
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ { Label.defaults with Text = "Profile preferences" }
            Switch.ƒ { Switch.defaults with Text = "Link my github account" }
        ]
        Form.Group.ƒ Form.Group.defaults [
            Checkbox.ƒ { Checkbox.defaults with Text = "Remember me" }
            Checkbox.ƒ { Checkbox.defaults with Text = "Forget me" }
        ]
        Form.Group.ƒ Form.Group.defaults [
            InputGroup.ƒ
                { InputGroup.defaults with
                    AddonLeft = InputGroup.AddonLeft.Text "someprefix/"                                        
                    AddonRight = InputGroup.AddonRight.Button
                        ( { Button.defaults with Kind = Button.Kind.Primary },
                        [R.str "Save"] )
                } [
                    Select.ƒ Select.defaults [
                        Select.Option.ƒ Select.Option.defaults [R.str "Option 1"]
                        Select.Option.ƒ Select.Option.defaults [R.str "Option 2"]
                    ]
                    Input.ƒ { Input.defaults with HTMLProps = [Placeholder "Enter text"] }
                ]
        ]
        Anchor.ƒ Anchor.defaults [R.str "Submit"]
    ]
