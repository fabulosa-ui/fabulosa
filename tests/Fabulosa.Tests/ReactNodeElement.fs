module ReactNodeElement

    module R = Fable.Helpers.React
    open R.Props
    open Fabulosa.Extensions

    let nullElement el =
        if el <> null then 
            el
        else 
            R.str "<NULL-NULL>"

    let isNull x = x = null

    let extract =
        function
        | R.Node (a, b, c) -> (a, b, Seq.map nullElement c)
        | R.List elements -> ("", seq [], Seq.map nullElement elements)
        | R.Text str when str = "<NULL-NULL>" -> ("null", seq [Value str], seq [])
        | R.Text str -> ("<STRING>", seq [Value str], seq [])
        | R.RawText str -> ("<STRING>", seq [Value str], seq [])
        | _ -> ("", seq [], seq [])
