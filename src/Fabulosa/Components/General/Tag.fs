namespace Fabulosa

module R = Fable.Helpers.React
open R.Props
open Fabulosa.Extensions

[<RequireQualifiedAccess>]
module Tag =

    [<RequireQualifiedAccess>]
    type Color =
    | Default
    | Primary
    | Secondary
    | Success
    | Warning
    | Error

    type Props = {
        Rounded: bool
        Color: Color
    }
    
    let defaults = {
        Rounded = false
        Color = Color.Default
    }
    
    let private getClassOfColor =
        function
        | Color.Default -> ""
        | Color.Primary -> "label-primary"
        | Color.Secondary -> "label-secondary"
        | Color.Success -> "label-success"
        | Color.Warning -> "label-warning"
        | Color.Error -> "label-error"
        
    let private getClassOfRounded =
        function
        | true -> "label-rounded"
        | false -> ""
        
    let private getClasses color rounded = 
        ([ "label"; getClassOfRounded rounded; getClassOfColor color ]
        |> Seq.join " ").Trim()
        
        
    let ƒ props = 
        R.span [ClassName (getClasses props.Color props.Rounded)]
        
    let f = ƒ