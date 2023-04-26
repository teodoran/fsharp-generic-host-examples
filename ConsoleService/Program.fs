module Example.ConsoleService.Program

open Example.Library
open Microsoft.Extensions.Logging

let logger = Logger.create ()
logger.LogInformation "Launching 🚀"

let timer = Timer.everySecond (fun now -> logger.LogInformation $"Service Running {now:T}")
System.Console.ReadKey () |> ignore

logger.LogInformation "Cleaning Up 🧹"
timer.Dispose()

logger.LogInformation "Quitting 👋"
