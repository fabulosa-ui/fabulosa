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
        let actualDescendentsClasses =
            Seq.collect (ReactNode.className >> (fun descendentClass ->
                descendentClass.Split()
                |> Seq.ofArray
                |> Seq.filter (String.isNotEmpty))) node.Children
        let expectedClasses =
            expectedClassName.Split()
            |> Seq.ofArray
            |> Seq.filter (String.isNotEmpty)
        Expect.containsAll actualDescendentsClasses expectedClasses "Classes mismatch"
        
    let hasProp (prop: IProp) node =
        let propSequence = node |> ReactNode.props
        Expect.contains propSequence prop "Prop not found"
        
    let hasChild expectedMatches child parent =
        let foundNodes = ReactNode.find child parent
        Expect.equal expectedMatches (Seq.length foundNodes) "Number of children found mismatch"
    
    let hasText expectedText node =
        let text = node |> ReactNode.text
        Expect.equal expectedText text "Text value mismatch"
