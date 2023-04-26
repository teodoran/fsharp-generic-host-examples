namespace Example.HostedService

open System
open System.Threading
open System.Threading.Tasks
open Example.Library
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

type BrokenWorker(logger: ILogger<BrokenWorker>) =
    inherit BackgroundService()

    override _.ExecuteAsync(token: CancellationToken) =
        logger.LogInformation "Launching 🚫"

        while not token.IsCancellationRequested do
            logger.LogInformation $"Running {DateTime.Now:T}"
            Thread.Sleep 1000

        Task.CompletedTask
