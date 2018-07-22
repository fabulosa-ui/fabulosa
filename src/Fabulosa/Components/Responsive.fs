module Responsive

open ClassNames

type ResponsiveSize =
| ResponsiveXS
| ResponsiveSM
| ResponsiveMD
| ResponsiveLG
| ResponsiveXL

type HideOrShow =
| ResponsiveHide of ResponsiveSize
| ResponsiveShow of ResponsiveSize

let hideOrShowClasses =
    function
    | ResponsiveHide ResponsiveXS -> "hide-xs"
    | ResponsiveHide ResponsiveSM -> "hide-sm"
    | ResponsiveHide ResponsiveMD -> "hide-md"
    | ResponsiveHide ResponsiveLG -> "hide-lg"
    | ResponsiveHide ResponsiveXL -> "hide-xl"
    | ResponsiveShow ResponsiveXS -> "show-xs"
    | ResponsiveShow ResponsiveSM -> "show-sm"
    | ResponsiveShow ResponsiveMD -> "show-md"
    | ResponsiveShow ResponsiveLG -> "show-lg"
    | ResponsiveShow ResponsiveXL -> "show-xl"

let responsiveP hideOrShowProps element elementProps htmlProps children =
    let props = mergeClasses <| htmlProps <| ["responsive"] @ List.map hideOrShowClasses hideOrShowProps
    element elementProps props children

let responsive hideOrShowProps element htmlProps children =
    let props = mergeClasses <| htmlProps <| ["responsive"] @ List.map hideOrShowClasses hideOrShowProps
    element props children