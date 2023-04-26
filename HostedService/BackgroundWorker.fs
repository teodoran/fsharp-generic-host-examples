namespace Example.HostedService

open System.Threading
open Example.Library
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

type BackgroundWorker(logger: ILogger<BackgroundWorker>) =
    inherit BackgroundService()

    override _.ExecuteAsync(token: CancellationToken) =
        task {
            logger.LogInformation "Launching 🚀"

            let timer = Timer.everySecond (fun now -> logger.LogInformation $"Running {now:T}")

            do! Task.wait token

            logger.LogInformation "Cleaning Up 🧹"
            timer.Dispose()

            logger.LogInformation "Quitting 👋"
        }
