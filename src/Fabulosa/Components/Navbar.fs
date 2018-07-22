module Navbar

module R = Fable.Helpers.React

open ClassNames

let navbarHeader htmlProps children =
    let props = mergeClasses <| htmlProps <| ["navbar"]
    R.header props children

let navbarSection htmlProps children =
    let props = mergeClasses <| htmlProps <| ["navbar-section"]
    R.section props children

let navbarCenter htmlProps children =
    let props = mergeClasses <| htmlProps <| ["navbar-center"]
    R.section props children

let navbarBrand htmlProps children =
    let props = mergeClasses <| htmlProps <| ["navbar-brand"]
    R.a props children