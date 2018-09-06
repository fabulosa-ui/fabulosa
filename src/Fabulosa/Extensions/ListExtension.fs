namespace Fabulosa.Extensions

module List =
    let cast<'a> = Seq.cast<'a> >> List.ofSeq 