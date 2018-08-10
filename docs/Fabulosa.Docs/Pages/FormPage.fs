module FormPage

module R = Fable.Helpers.React
open R.Props
open Fabulosa
open Fabulosa.Docs.JavascriptMapping

let inputSnippet = """(* First Name Input *)
Label.ƒ { Label.defaults with Text = "First Name" }
Input.ƒ {
    Input.defaults with
        HTMLProps = [Placeholder "Please enter your first name"]
}

(* Time Input With Icon *)
Label.ƒ { Label.defaults with Text = "Time" }
IconInput.ƒ {
    IconInput.defaults with
        InputProps =
            { Input.defaults with
                HTMLProps = [Placeholder "Please enter a time"] }
        IconProps = { Icon.defaults with Kind = Icon.Kind.Time }
}
"""

let textareaSnippet = """(* Description Textarea *)
Label.ƒ { Label.defaults with Text = "Description" }
Textarea.ƒ {
    Textarea.defaults with
        HTMLProps = [Placeholder "Please enter a description"]
}
"""

let selectSnippet = """(* Choose Animal Select *)
Label.ƒ { Label.defaults with Text = "Choose Animal" }
Select.ƒ Select.defaults [
    Select.Option.ƒ Select.Option.defaults [R.str "Dog"]
    Select.Option.ƒ Select.Option.defaults [R.str "Cat"]
    Select.Option.ƒ Select.Option.defaults [R.str "Parrot"]
]
"""

let crsSnippet = """(* Contact Preferences Radio *)
Label.ƒ { Label.defaults with Text = "Contact preferences" }
Radio.ƒ {
    Radio.defaults with
        HTMLProps = [Name "contact-prefs"]
        Text = "Call me"
}
Radio.ƒ {
    Radio.defaults with
        HTMLProps = [Name "contact-prefs"]
        Text = "Text me"
}

(* Login Options Checkbox *)
Label.ƒ { Label.defaults with Text = "Login Options" }
Checkbox.ƒ { Checkbox.defaults with Text = "Remember me" }

(* Profile Preferences Switch*)
Label.ƒ { Label.defaults with Text = "Profile preferences" }
Switch.ƒ { Switch.defaults with Text = "Link my github account" }
"""

let inputGroupSnippet = """(* Website Input Group *)
Label.ƒ { Label.defaults with Text = "Email Address" }
InputGroup.ƒ {
    InputGroup.defaults with
        AddonLeft = InputGroup.AddonLeft.Text "https://"                                        
        AddonRight = InputGroup.AddonRight.Button
            ( { Button.defaults with Kind = Button.Kind.Primary },
            [R.str "Validate"] )
} [
    Input.ƒ {
        Input.defaults with
            HTMLProps = [Placeholder "Please enter website address"]
    }
]

(* Search Engine Input Group *)
Label.ƒ { Label.defaults with Text = "Search Engine" }
InputGroup.ƒ {
    InputGroup.defaults with
        AddonLeft = InputGroup.AddonLeft.Text "https://"                                        
        AddonRight = InputGroup.AddonRight.Button
            ( Button.defaults, [
                Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Search } []
                R.str "Search"
            ] )
} [
    Select.ƒ Select.defaults [
        Select.Option.ƒ Select.Option.defaults [R.str "google.com"]
        Select.Option.ƒ Select.Option.defaults [R.str "yahoo.com"]
        Select.Option.ƒ Select.Option.defaults [R.str "duckduckgo.com"]
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
                    Label.ƒ { Label.defaults with Text = "Time" }
                    IconInput.ƒ {
                        IconInput.defaults with
                            InputProps =
                                { Input.defaults with
                                    HTMLProps = [Placeholder "Please enter a time"] }
                            IconProps = { Icon.defaults with Kind = Icon.Kind.Time }
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
        R.h4 [ClassName "s-title"]
            [R.str "Textarea"]
        Grid.Row.ƒ {
            Grid.Row.defaults with HTMLProps = [ClassName "docs-demo"]
        } [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Form.Group.ƒ Form.Group.defaults [
                    Label.ƒ { Label.defaults with Text = "Description" }
                    Textarea.ƒ {
                        Textarea.defaults with
                            HTMLProps = [Placeholder "Please enter a description"]
                    } []
                ]
            ]
        ]
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Code.ƒ {
                    Code.defaults with 
                        Code = Highlight.fsharp textareaSnippet
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
        R.h4 [ClassName "s-title"] [R.str "Radio, Checkbox and Switch"]
        Grid.Row.ƒ {
            Grid.Row.defaults with HTMLProps = [ClassName "docs-demo"]
        } [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Form.Group.ƒ Form.Group.defaults [
                    Label.ƒ { Label.defaults with Text = "Contact preferences" }
                    Radio.ƒ {
                        Radio.defaults with
                            HTMLProps = [Name "contact-prefs"]
                            Text = "Call me"
                    }
                    Radio.ƒ {
                        Radio.defaults with
                            HTMLProps = [Name "contact-prefs"]
                            Text = "Text me"
                    }
                    Label.ƒ { Label.defaults with Text = "Login Options" }
                    Checkbox.ƒ { Checkbox.defaults with Text = "Remember me" }
                    Label.ƒ { Label.defaults with Text = "Profile preferences" }
                    Switch.ƒ { Switch.defaults with Text = "Link my github account" }
                ]
            ]
        ]
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Code.ƒ {
                    Code.defaults with 
                        Code = Highlight.fsharp crsSnippet
                }
            ]
        ]
        R.h4 [ClassName "s-title"] [R.str "Input Group"]
        Grid.Row.ƒ {
            Grid.Row.defaults with HTMLProps = [ClassName "docs-demo"]
        } [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Form.Group.ƒ Form.Group.defaults [
                    Label.ƒ { Label.defaults with Text = "Website" }
                    InputGroup.ƒ {
                        InputGroup.defaults with
                            AddonLeft = InputGroup.AddonLeft.Text "https://"                                        
                            AddonRight = InputGroup.AddonRight.Button
                                ( { Button.defaults with Kind = Button.Kind.Primary },
                                [R.str "Validate"] )
                    } [
                        Input.ƒ {
                            Input.defaults with
                                HTMLProps = [Placeholder "Please enter website address"]
                        }
                    ]
                    Label.ƒ { Label.defaults with Text = "Search Engine" }
                    InputGroup.ƒ {
                        InputGroup.defaults with
                            AddonLeft = InputGroup.AddonLeft.Text "https://"                                        
                            AddonRight = InputGroup.AddonRight.Button
                                ( Button.defaults, [
                                    Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Search } []
                                    R.RawText "\n"
                                    R.str "Search"
                                ] )
                    } [
                        Select.ƒ Select.defaults [
                            Select.Option.ƒ Select.Option.defaults [R.str "google.com"]
                            Select.Option.ƒ Select.Option.defaults [R.str "yahoo.com"]
                            Select.Option.ƒ Select.Option.defaults [R.str "duckduckgo.com"]
                        ]
                    ]
                ]
            ]
        ]
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ { Grid.Column.defaults with Size = 12 } [
                Code.ƒ {
                    Code.defaults with 
                        Code = Highlight.fsharp inputGroupSnippet
                }
            ]
        ]
    ]
