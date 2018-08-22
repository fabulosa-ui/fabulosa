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

    let radio =
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ {
                Label.defaults with Text = "Gender"
            }
            Radio.ƒ {
                Radio.defaults with
                    Text = "Male"
                    HTMLProps = [Name "gender"]
            }
            Radio.ƒ {
                Radio.defaults with
                    Text = "Female"
                    HTMLProps = [Name "gender"]
            }
        ]

    let checkbox =
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ {
                Label.defaults with Text = "Login Preferences"
            }
            Checkbox.ƒ {
                Checkbox.defaults with
                    Text = "Remember Me"
                    HTMLProps = [Name "remember-me"]
            }
        ]

    let switch =
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ {
                Label.defaults with Text = "Email Preferences"
            }
            Switch.ƒ {
                Switch.defaults with
                    Text = "Send me promotional emails"
            }
        ]

    let sizes =
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ {
                Label.defaults with
                    Text = "Small"
                    Size = Label.Size.Small
            }
            Input.ƒ {
                Input.defaults with
                    HTMLProps = [Placeholder "Please enter a value"]
                    Size = Input.Size.Small
            }
            Label.ƒ {
                Label.defaults with
                    Text = "Large"
                    Size = Label.Size.Large
            }
            Select.ƒ {
                Select.defaults with
                    Size = Select.Size.Large
            } [
                Select.Option.ƒ Select.Option.defaults [R.str "Large"]
            ]
        ]

    let validation =
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ {
                Label.defaults with Text = "Valid Input"
            }
            Input.ƒ {
                Input.defaults with
                    HTMLProps = [Placeholder "Please enter a value"]
            } |> Validation.ƒ <| Validation.Kind.Success "This input is valid."
            Label.ƒ {
                Label.defaults with Text = "Invalid Input"
            }
            Input.ƒ {
                Input.defaults with
                    HTMLProps = [Placeholder "Please enter a value"]
            } |> Validation.ƒ <| Validation.Kind.Error "This input is invalid."
        ]

    let inputGroup =
        Form.Group.ƒ Form.Group.defaults [
            Label.ƒ { Label.defaults with Text = "Email Address" }
            InputGroup.ƒ InputGroup.defaults [
                Input.ƒ {
                    Input.defaults with
                        HTMLProps = [Placeholder "Please enter email address"]
                }
                Select.ƒ Select.defaults [
                    Select.Option.ƒ Select.Option.defaults [R.str "@gmail.com"]
                    Select.Option.ƒ Select.Option.defaults [R.str "@hotmail.com"]
                ]
            ]
            Label.ƒ { Label.defaults with Text = "Website" }
            InputGroup.ƒ {
                InputGroup.defaults with
                    AddonLeft = InputGroup.AddonLeft.Text "https://"                                        
                    AddonRight = InputGroup.AddonRight.Button
                        ( Button.defaults, [
                            R.str "Save"
                            R.RawText "\n"
                            Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Check } []
                        ] )
            } [
                Input.ƒ {
                    Input.defaults with
                        HTMLProps = [Placeholder "Please enter website address"]
                }
            ]
        ]

    let render () =
        Renderer.tryMount "form-input-demo" input
        Renderer.tryMount "form-select-demo" select
        Renderer.tryMount "form-textarea-demo" textarea
        Renderer.tryMount "form-radio-demo" radio
        Renderer.tryMount "form-checkbox-demo" checkbox
        Renderer.tryMount "form-switch-demo" switch
        Renderer.tryMount "form-sizes-demo" sizes
        Renderer.tryMount "form-validation-demo" validation
        Renderer.tryMount "form-input-group-demo" inputGroup