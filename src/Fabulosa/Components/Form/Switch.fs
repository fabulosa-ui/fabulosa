namespace Fabulosa

module Switch =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    type SwitchChildren =
        Text of string

    type Switch = HTMLProps * SwitchChildren

    let switch ((opt, (Text txt)): Switch) =
        R.label [ ClassName "form-switch" ]
            [ R.input (Type "checkbox" :> IHTMLProp :: opt)
              R.i [ ClassName "form-icon" ] []
              R.str txt ]
