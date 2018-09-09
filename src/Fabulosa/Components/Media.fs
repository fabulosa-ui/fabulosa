namespace Fabulosa

module Media =
    [<RequireQualifiedAccess>]
    module Caption =

        open Fabulosa.Extensions
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
        
        let getClasses (props: Props) =
            getClassOfTextDirection props.TextDirection
            |> List.append ["figure-caption"]
            |> String.concat " "
            |> ClassName
           
        let ƒ (props: Props) =
            (props.HTMLProps |> addProp (getClasses props), props.Text)
            ||> R.figcaption
    
        let render = ƒ
    
    module Image =

        open Fabulosa.Extensions
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
            >> String.concat " "
            >> ClassName
            
        let ƒ (props: Props) =
            props.HTMLProps 
            |> addProp (getClassOfKind props.Kind)
            |> R.img
    
        let render = ƒ
    
    module Figure =
        open Fabulosa.Extensions
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
                |> addProp (ClassName "figure")
                |> R.figure
        
            figureComponent [
                Image.ƒ props.Image
                Caption.ƒ props.Caption
            ]    
            
        let render = ƒ

    module Video =
        open ClassNames
        module R = Fable.Helpers.React
        open Fable.Import.React
        open Fable.Helpers
        open R.Props
        
        type Ratio =
        | Ratio16x9
        | Ratio4x3
        | Ratio1x1
        
        type Kind =
        | Embedded of ReactElement
        | Source of string
        
        [<RequireQualifiedAccess>]
        type Props = {
           Ratio: Ratio
           Kind: Kind
        }
        
        let defaults: Props = {
            Ratio = Ratio16x9
            Kind = Source ""
        }
        
        let getClassOfRatio =
            function 
            | Ratio16x9 -> ["video-responsive-16-9"]
            | Ratio4x3 -> ["video-responsive-4-3"]
            | Ratio1x1 -> ["video-responsive-1-1"]
            
        let ƒ (props: Props) =
            let (parent, propsOfKind, children) =
                match props.Kind with
                | Source source -> R.video, seq [Src source], []
                | Embedded element -> R.iframe, seq [], [element]
            
            propsOfKind 
            |> Seq.append [ClassName "video-responsive"] 
            |> Seq.cast
            |> List.ofSeq
            |> addClasses (getClassOfRatio props.Ratio)
            |> parent 
            <| children
            
        let render = ƒ
