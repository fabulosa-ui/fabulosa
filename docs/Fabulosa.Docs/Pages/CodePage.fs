module CodePage
open Fable.Helpers
open Fable.Helpers.React.Props
open Fabulosa

open ReactElementStringExtensions
open Fabulosa.Docs.JavascriptMapping
open Fabulosa.Docs.Domain
open Fabulosa.Docs.JavascriptMapping


module R = Fable.Helpers.React

let p = ofString Typography.p
  
let html = """ 
<!-- code snippets -->
<button class="btn">
 Submit
</button>
""" 
  
  
let htmlCodeExampleInFsharp  = """
let code  = @"<!-- code snippets -->
<button class='btn'>
 Submit
</button>"

let myCustomComponent = Code.ƒ {
    Code.defaults with 
        Code = Highlight.html html
        Language = "HTML"
        
}      
"""  

let fsharpCode = """
let myFsharpCode = @"type Yolo = {
    Blah = string
}

let x y z = z y

type Bam = 
| B1
| B2
"

let myCustomComponent = Code.ƒ {
    Code.defaults with 
        Code = Highlight.fsharp htmlCodeExampleInFsharp
        
}  
"""
  
let codePage = 
    R.div []
        [
            "Dependencies" |> ofString Typography.h2  
            
            R.str "This component has a dependency on "
            R.a [Href "Code is used for styling inline and multiline code snippets."] [R.str "highlight.js"]
            R.str ". Make sure highlight.js is present in your page."
                
            "Usage" |> ofString Typography.h2
                        
            Code.ƒ { 
                Code.defaults with Code = Highlight.fsharp fsharpCode 
            }                  
            
            Code.ƒ {
                Code.defaults with 
                    Code = Highlight.fsharp htmlCodeExampleInFsharp
                    
            }  
             
            Code.ƒ {
                Code.defaults with 
                    Code = Highlight.html html
                    Language = "HTML"
            }      
            
            Tag.ƒ Tag.defaults [R.str "Hello world"]
            Tag.ƒ { Tag.defaults with Color = Tag.Color.Primary} [R.str "Hello world"]
            Tag.ƒ { Tag.defaults with Color = Tag.Color.Secondary} [R.str "Hello world"]
            Tag.ƒ { Tag.defaults with Color = Tag.Color.Error ; Rounded = true} [R.str "Hello world"]
            Tag.ƒ { Tag.defaults with Color = Tag.Color.Success} [R.str "Hello world"]
            
            Media.Image.ƒ { Media.Image.defaults with HTMLProps = [Src "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRWT_FoABNj68ph1976sAxKZkP7UhR0PzbBCfTYHOkGXeU7V6H_"]}
            
            R.div [] [
                Media.Image.ƒ { 
                    Media.Image.defaults with 
                        Kind = Media.Image.Kind.Contain
                        HTMLProps = [Src "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRWT_FoABNj68ph1976sAxKZkP7UhR0PzbBCfTYHOkGXeU7V6H_"]
                }
            ]
            
            R.div [] [
                Media.Figure.ƒ { Media.Figure.defaults with  
                    Image = { Media.Image.defaults with 
                        Kind = Media.Image.Kind.Contain
                        HTMLProps = [Src "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRWT_FoABNj68ph1976sAxKZkP7UhR0PzbBCfTYHOkGXeU7V6H_"]
                    }
                    Caption = { Media.Caption.defaults with Text = [R.str "Hello, Scarlett"]}
                }
                
            ]
            
        ]

    
let view () = 
    Page.page
        "Code"
        "Code is used for styling inline and multiline code snippets."
        codePage
    