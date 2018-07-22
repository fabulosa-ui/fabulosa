module Tests

open Expecto
// open Hopac
// open Logary.Configuration
// open Logary.Adapters.Facade
// open Logary.Targets

// let logary =
//     Config.create "MyProject.Tests" "localhost"
//     |> Config.targets [ LiterateConsole.create LiterateConsole.empty "console" ]
//     |> Config.processing (Events.events |> Events.sink ["console";])
//     |> Config.build
//     |> run
// LogaryFacadeAdapter.initialise<Expecto.Logging.Logger> logary

[<EntryPoint>]
let main argv =
    runTestsInAssembly defaultConfig argv