module Expect
    open Expecto
    module R = Fable.Helpers.React
    open R.Props
    open Fabulosa.Extensions

    let (|>!) node func =
        try 
            func node
            node
        with 
        | x -> raise x

    let private parseDependent (expectedClassName: string) (node: ReactNode.T) =
        let descendentClasses = node |> ReactNode.classNames
        let actualDescendentsClasses =
            descendentClasses.Split()
            |> Seq.ofArray
            |> Seq.filter (String.isNotEmpty)
        let expectedClasses =
            expectedClassName.Split()
            |> Seq.ofArray
            |> Seq.filter (String.isNotEmpty)
        (actualDescendentsClasses, expectedClasses)

    let hasUniqueClass expectedClasses node = 
        let actualClasses = node |> ReactNode.className
        Expect.equal expectedClasses actualClasses
            (sprintf "hasUniqueClass should contain %s only. Found %s" expectedClasses actualClasses)
                
    let hasClass (expectedClassName: string) node =
        let actualClassName = 
            node 
            |> ReactNode.className
        let actualClasses =
            actualClassName.Split()
            |> Seq.ofArray
            |> Seq.filter (String.isNotEmpty)
        let expectedClasses =
            expectedClassName.Split()
            |> Seq.ofArray
            |> Seq.filter (String.isNotEmpty)
        Expect.containsAll actualClasses expectedClasses "Classes mismatch"

    let hasDescendentClass (expectedClassName: string) (node: ReactNode.T) =
        let actualDescendentsClasses, expectedClasses = parseDependent expectedClassName node
        Expect.containsAll actualDescendentsClasses expectedClasses "Classes mismatch"

    let hasOrderedDescendentClass multiplier (expectedClassName: string) (node: ReactNode.T) =
        let multiplied = String.replicate multiplier (expectedClassName + " ")
        let actualDescendentsClasses, expectedClasses = parseDependent multiplied node
        Expect.sequenceContainsOrder actualDescendentsClasses expectedClasses "Classes mismatch"

    let hasProp (prop: IProp) node =
        let propSequence = node |> ReactNode.props
        Expect.contains propSequence prop "Prop not found"
        
    let hasChild expectedMatches child parent =
        let foundNodes = ReactNode.find child parent
        Expect.equal expectedMatches (Seq.length foundNodes) "Number of children found mismatch"
    
    let hasText expectedText node =
        let text = node |> ReactNode.text
        Expect.equal expectedText text "Text value mismatch"
