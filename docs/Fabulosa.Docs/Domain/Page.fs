namespace Fabulosa.Docs.Domain

module Page =

    open Fable.Helpers.React.Props
    open Fabulosa
    open ReactElementStringExtensions
    open Fabulosa.Docs.JavascriptMapping

    module R = Fable.Helpers.React
    
    let page header subheader body = 
        [
            Typography.h2 [ClassName "s-title"] [R.str header]
            Typography.p [ClassName "s-description"] [R.str subheader]
            body
        ] 
        |>   R.div [] 
        
    let block title stringfiedCode pageBlock =
        R.div [ClassName "container"]
            [
                Typography.h2 [ClassName "s-title"] [R.str title]
                [pageBlock] |> R.div [ClassName "component-view-container"] 
                    
                R.div [ClassName "code-container"]
                    [
                        [
                            Code.f { Code.defaults with Code = Highlight.fsharp stringfiedCode }
                        ]
                        |> R.pre [ClassName "language-fsharp"] 
                    ]
            ]