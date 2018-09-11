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

    let private filterEmpty (classes: string) =
        classes.Split()
        |> Seq.ofArray
        |> Seq.filter (String.isNotEmpty)

    let private parseDependent (expected: string) (node: ReactNode.T) =
        let actual = node |> ReactNode.descendentClassName
        (actual |> filterEmpty, expected |> filterEmpty)

    let hasUniqueClass expectedClasses node = 
        let actualClasses = node |> ReactNode.className
        Expect.equal expectedClasses actualClasses
            (sprintf "hasUniqueClass should contain %s only. Found %s" expectedClasses actualClasses)

    let hasClass (expected: string) node =
        let actual = node |> ReactNode.className |> filterEmpty
        Expect.containsAll actual (expected |> filterEmpty) "Classes mismatch"

    let hasDescendentClass (expectedClassName: string) (node: ReactNode.T) =
        let actualDescendentsClasses, expectedClasses = parseDependent expectedClassName node
        Expect.containsAll actualDescendentsClasses expectedClasses "Classes mismatch"

    let hasOrderedDescendentClass multiplier (expected: string) (node: ReactNode.T) =
        let multiplied = String.replicate multiplier (expected + " ")
        let actual, expectedClasses = parseDependent multiplied node
        Expect.sequenceContainsOrder actual expectedClasses "Classes mismatch"

    let hasProp (prop: IProp) node =
        let props = node |> ReactNode.props
        Expect.contains (Seq.map string props) (string prop) "Prop not found"

    let hasDescendentProp (prop: IProp) node =
        let props = node |> ReactNode.descendentProps
        Expect.contains (Seq.map string props) (string prop) "Prop not found"

    let hasChild expectedMatches child parent =
        let foundNodes = ReactNode.find child parent
        Expect.equal expectedMatches (Seq.length foundNodes) "Number of children found mismatch"

    let hasText expectedText node =
        let text = node |> ReactNode.descendentText
        Expect.equal expectedText text "Text value mismatch"
