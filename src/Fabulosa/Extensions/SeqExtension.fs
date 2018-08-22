namespace Fabulosa.Extensions

module Seq =
    open System
    open System.Text
    let join (delim: string) (items: seq<string>) =
        String.Join(delim, Seq.toArray items)
                