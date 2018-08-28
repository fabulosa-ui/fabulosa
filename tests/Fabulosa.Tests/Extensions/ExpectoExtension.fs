module Expect

    open Expecto
    module R = Fable.Helpers.React
    open R.Props
    open Fabulosa.Extensions
    
    let bind f e = 
        try 
            f e
            e
        with 
        | x -> raise x

    let (>>=) m f = bind f m

    let hasUniqueClass expectedClasses element = 
        let actualClasses = element |> ReactNode.className
        Expect.equal expectedClasses actualClasses
            (sprintf "hasUniqueClass should contain %s only. Found %s" expectedClasses actualClasses)
                
    let containsClassName (expectedClassName: string) element =
        let actualClassName = 
            element 
            |> ReactNode.className
        let actualClasses = actualClassName.Split() |> Seq.ofArray |> Seq.filter (String.isNotEmpty)
        let expectedClasses = expectedClassName.Split() |> Seq.ofArray |> Seq.filter (String.isNotEmpty)
        
        Expect.containsAll expectedClasses actualClasses "Classes mismatch"
        
    let containsProp (prop: IProp) element =
        let propSequence = element |> ReactNode.props
        Expect.contains propSequence prop "Prop not found"
        
    let containsChild expectedMatches child parent =
        let foundNodes = ReactNode.find child parent
        Expect.equal expectedMatches (Seq.length foundNodes) "Number of children found mismatch"
    
    let containsText expectedText element =
        let text = element |> ReactNode.text
        Expect.equal expectedText text "Text value mismatch"
