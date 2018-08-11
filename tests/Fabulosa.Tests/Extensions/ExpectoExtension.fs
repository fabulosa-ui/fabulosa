namespace Fabulosa.Tests.Extensions

open Expecto

module Expect =
    let containsToString sequence subject errorMes=
        (sequence
        |> Seq.map (fun x -> x.ToString())
        |> Seq.contains (subject.ToString())
        |> Expect.isTrue) errorMes
