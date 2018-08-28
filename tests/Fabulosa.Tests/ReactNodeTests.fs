module ReactNodeTests

    open Fable.Import.React
    module R = Fable.Helpers.React
    open ReactNode
    open R.Props
    open Expecto

    [<Tests>]
    let reactNodeTests =
        testList "React Node T" [

            test "find returns empty when no matching descendents are provided" {
                let simpleNode = R.span [] [R.span [] []]
                let simpleDiv = R.div [] []
                
                let subject = ReactNode.unit simpleNode
                let descendent = ReactNode.unit simpleDiv

                let found = subject |> ReactNode.find descendent
                Expect.isEmpty found "Should not find what isn't there"
            }
            
            test "find returns does not return the root node itself" {
                let simpleNode = R.div [] []
                
                let subject = ReactNode.unit simpleNode
                let itself = ReactNode.unit simpleNode

                let found = subject |> ReactNode.find itself
                Expect.isEmpty found "Should not find itself"
            }
             
            test "find returns a subnodes" {
                let root = R.div [] [
                   R.span [] [
                       R.p [] [
                           R.p [] []
                       ]
                   ]
                   R.p [] []
                ]

                let subject = root |> ReactNode.unit
                let descendent = R.p [] [] |> ReactNode.unit

                let found = subject |> ReactNode.find descendent 
                Expect.equal (found |> Seq.length) 2 ""
            }
            
            test "a find a returns a subnodes as children" {
                let root = R.div [] [
                    R.span [] [
                       R.p [] [
                            R.p [] []
                            R.p [] []
                        ]
                    ]
                    R.p [] []
                    R.p [] []
                ]

                let subject = ReactNode.unit root
                let descendent = ReactNode.unit <| R.p [] []

                let found = subject |> ReactNode.find descendent
                Expect.equal (found |> Seq.length) 4 "Should find all descendents"
             }

            test "find returns subnodes matching on props" {
                let func = fun (e: MouseEvent) -> Fable.Import.JS.console.log e
                
                let root = R.div [] [
                    R.span [] [
                       R.p [] [
                           R.p [ClassName "class-one"; OnClick func] []
                           R.p [] []
                       ]
                    ]
                    R.p [Id "id"; ClassName "class-one"] []
                    R.p [] []
                ]

                let subject = ReactNode.unit root
                let descendent1 = ReactNode.unit <| R.p [ClassName "class-one"; OnClick func] []
                let descendent2 = ReactNode.unit <| R.p [Id "id"; ClassName "class-one"] []
                
                let found1 = subject |> ReactNode.find descendent1
                
                Expect.equal (found1 |> Seq.length) 1 "Should find with props correctly"

                let found2 = subject |> ReactNode.find descendent2

                Expect.equal (found2 |> Seq.length) 1 "Should find with props correctly"
            }

            test "node text should be mapped correctly" {
                let root = R.div [] [
                    R.RawText "Qué voy a hacer"
                    R.span [] [
                        R.str "Je ne sais pas"
                        R.RawText "Qué voy a hacer"
                        R.div [] [
                            R.RawText "Je ne sais plus"
                        ]
                        R.str "Qué voy a hacer"
                    ]
                    R.RawText "Je suis perdu"
                    R.fragment [] [
                        R.str "Qué horas son, mi corazón"
                    ]
                ]
                let subject = root |> ReactNode.unit |> ReactNode.text
                let str =
                    [ "Qué voy a hacer Je ne sais pas"
                      "Qué voy a hacer Je ne sais plus"
                      "Qué voy a hacer Je suis perdu"
                      "Qué horas son, mi corazón" ] |> String.concat " "
                Expect.equal subject str "Strings should equal"
            }
        ]