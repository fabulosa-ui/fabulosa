namespace Fabulosa

module Media =
    [<RequireQualifiedAccess>]
    module Caption =
        open ClassNames
        module R = Fable.Helpers.React
        open Fable.Import.React
    
        open R.Props
        type TextDirection =
        | Left
        | Center
        | Right
    
        [<RequireQualifiedAccess>]
        type Props = {
            TextDirection: TextDirection
            Text: ReactElement list
            HTMLProps: IHTMLProp list
        }
    
        let defaults: Props = {
            TextDirection = Center
            Text = []
            HTMLProps = []
        }
        
        let getClassOfTextDirection =
            function 
            | Left -> ["text-left"]
            | Center -> ["text-center"]
            | Right -> ["text-right"]
        
        let getClasses (props: Props) = getClassOfTextDirection props.TextDirection |> List.append ["figure-caption"] 
           
        let ƒ (props: Props) =
            (props.HTMLProps |> combineProps (getClasses props), props.Text)
            ||> R.figcaption
    
        let render = ƒ
    
    module Image =
        open ClassNames
        module R = Fable.Helpers.React
        open Fable.Import.React
        open Fable.Helpers
        open R.Props

        type Kind =
        | Responsive
        | Contain
        | Cover
    
        type Props = {
            Kind: Kind
            HTMLProps: IHTMLProp list
        }
    
        let defaults: Props = {
            Kind = Responsive
            HTMLProps = []
        }
        
        let getClassOfKind =
            function 
            | Responsive -> ["img-responsive"]
            | Contain -> ["img-fit-contain"]
            | Cover -> ["img-fit-cover"]
            
        let ƒ (props: Props) =
            props.HTMLProps 
            |> combineProps (getClassOfKind props.Kind)
            |> R.img
    
        let render = ƒ
    
    module Figure =
        open ClassNames
        module R = Fable.Helpers.React
        open Fable.Import.React
        
        open Fable.Helpers
        
        open R.Props
        type Kind =
        | Responsive
        | Contain
        | Cover
        
        [<RequireQualifiedAccess>]
        type Props = {
            Image: Image.Props
            Caption: Caption.Props
            HTMLProps: IHTMLProp list
        }
        
        let defaults: Props = {
            Image = Image.defaults
            Caption = Caption.defaults
            HTMLProps = []
        }
        
        let getClassOfKind =
            function 
            | Responsive -> ["img-responsive"]
            | Contain -> ["img-fit-contain"]
            | Cover -> ["img-fit-cover"]
            
        let ƒ (props: Props) =
            let figureComponent = 
                props.HTMLProps
                |> combineProps ["figure"]
                |> R.figure
        
            figureComponent [
                Image.ƒ props.Image
                Caption.ƒ props.Caption
            ]    
            
        let render = ƒ
