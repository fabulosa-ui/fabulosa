namespace Fabulosa.Extensions

module Seq =

    open System

    open System.Linq

    let equals a b = Enumerable.SequenceEqual(a, b)

    let join (delim: string) (items: seq<string>) =
        String.Join(delim, Seq.toArray items)
                
        