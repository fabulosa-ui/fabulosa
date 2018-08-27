namespace Fabulosa.Tests.Extensions

open Expecto
module R = Fable.Helpers.React
open R.Props
open Fabulosa.Tests.Extensions

module Expect =

    open Fabulosa.Extensions
    
    let bind f e = 
        try 
            f e
            e
        with 
        | x -> raise x
    
    let hasUniqueClass expectedClasses element = 
        let actualClasses = element |> ReactNode.className
        Expect.equal expectedClasses actualClasses
            (sprintf "hasUniqueClass should contain %s only. Found %s" expectedClasses actualClasses)
    
    let hasUniqueClassBind expectedClasses = hasUniqueClass expectedClasses |> bind
    
    let containsClassName (expectedClassName: string) element =
        let actualClassName = 
            element 
            |> ReactNode.className
        let actualClasses = actualClassName.Split() |> Seq.ofArray |> Seq.filter (String.isNotEmpty)
        let expectedClasses = expectedClassName.Split() |> Seq.ofArray |> Seq.filter (String.isNotEmpty)
        
        Expect.containsAll expectedClasses actualClasses "Classes mismatch"
        
    let containsClassNameBind expectedClassName = containsClassName expectedClassName |> bind
    
    let containsProp (prop: IProp) element =
        let propSequence = element |> ReactNode.props
        Expect.contains propSequence prop "Prop not found"
    
    let containsPropBind prop = containsProp prop |> bind
    
    let containsChild expectedMatches child parent =
        let foundNodes = ReactNode.find child parent
        Expect.equal expectedMatches (Seq.length foundNodes) "Number of children found mismatch"
    
    let containsChildBind expectedMatches child = 
        containsChild expectedMatches child |> bind
    
    let containsText expectedText element =
        let text = element |> ReactNode.text
        Expect.equal expectedText text "Text value mismatch"
        
    let containsTextBind expectedText = containsText expectedText |> bind
