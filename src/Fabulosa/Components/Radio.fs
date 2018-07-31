namespace Fabulosa

module Radio =

    module R = Fable.Helpers.React
    open R.Props

    let input htmlProps label =
        let inputProps: IHTMLProp list = [Type "radio"]
        let props = htmlProps @ inputProps
        R.label [ClassName "form-radio"] [
            R.input props
            R.i [ClassName "form-icon"] []
            R.str label
        ]