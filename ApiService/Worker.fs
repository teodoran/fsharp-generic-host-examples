namespace Example.ApiService

open System
open System.Threading
open Example.Library
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

type Worker(logger: ILogger<Worker>) =
    inherit BackgroundService()

    override _.ExecuteAsync(token: CancellationToken) =
        task {
            logger.LogInformation "Launching 🚀"

            while not token.IsCancellationRequested do
                logger.LogInformation $"Running {DateTime.Now:T}"
                do! Task.delay (TimeSpan.FromSeconds 1) token

            logger.LogInformation "Quitting 👋"
        }
