module Button

open ClassNames
module R = Fable.Helpers.React

type ButtonKind =
| ButtonDefault
| ButtonPrimary
| ButtonLink

type ButtonColor =
| ButtonSuccess
| ButtonError

type ButtonSize =
| ButtonSmall
| ButtonLarge

type ButtonState =
| ButtonDisabled
| ButtonActive
| ButtonLoading

type ButtonFormat =
| ButtonSquaredAction
| ButtonRoundAction

type ButtonProp =
| ButtonKind of ButtonKind
| ButtonColor of ButtonColor
| ButtonSize of ButtonSize
| ButtonState of ButtonState
| ButtonFormat of ButtonFormat

let buttonClasses =
    function
    | ButtonKind ButtonDefault -> "btn-default"
    | ButtonKind ButtonPrimary -> "btn-primary"
    | ButtonKind ButtonLink -> "btn-link"
    | ButtonColor ButtonSuccess -> "btn-success"
    | ButtonColor ButtonError -> "btn-error"
    | ButtonSize ButtonSmall -> "btn-sm"
    | ButtonSize ButtonLarge -> "btn-lg"
    | ButtonState ButtonDisabled -> "disabled"
    | ButtonState ButtonLoading -> "loading"
    | ButtonFormat ButtonSquaredAction -> "btn-action"
    | ButtonFormat ButtonRoundAction -> "btn-action circle"
    | _ -> ""

let button buttonProps htmlProps children =
    let props = mergeClasses <| htmlProps <| ["btn"] @ List.map buttonClasses buttonProps
    R.button props children