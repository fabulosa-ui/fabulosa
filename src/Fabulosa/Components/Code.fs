namespace Fabulosa

module R = Fable.Helpers.React
open R.Props


[<RequireQualifiedAccess>]
module Code =

    type Props = {
        Code: DangerousHtml
        Language: string
    }
    
    let props = {
        Code = { __html = "" }
        Language = "F#"
    }
    
    let ƒ props = 
        R.pre [ClassName "code"; Data ("lang", props.Language)] [
            R.code [DangerouslySetInnerHTML props.Code] []            
        ]
        
    let f = ƒ