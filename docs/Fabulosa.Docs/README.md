## Docs

Fabulosa docs are generated with FSharp.Formatting from F# scripts using the FSharp.Literate package.
Each page should be located in the `pages` directory, and can include accompanying demos.
The demos use the `React.mountById` helper to inject fabulosa components into that specific element in the generated doc page.

To get add a doc page, you need to:

1. Have all packages from paket installed
2. Run `(mono) .paket/paket.exe generate-load-scripts --framekwork net46`
3. Create the new F# script under the `pages` folder
4. (Optional) Create any demos you may need inside `pages`
4. Add the new page to `webpack.config.js`, inside the pages array
5. Run `fsharpi docs/Fabulosa.Docs/Generate.fsx`

#### Example

```fsharp
// newpage.fsx

(*** define: my-sample ***)
let hello = printfn "Hello, World!"

(** // Some markdown here
## A New Page

This is a new page
*)

(*** include: my-sample ***) // Code snippet from above appears here

(**
<span class="my-demo"></span> // Demo goes here
*)
```

```fsharp
// NewPageDemo.fs

open Renderer 

let myButton =
    Button.ƒ
        Button.defaults
        [R.str "Demo Button"]

(*
tryMount is just a helper to ignore errors from mounting
to a non-existing id, as all these will be all bundled together
*)
tryMount "my-demo" myButton
```
