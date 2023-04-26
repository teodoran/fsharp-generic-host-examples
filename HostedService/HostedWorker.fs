namespace Example.HostedService

open System
open System.Threading
open Example.Library
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

type HostedWorker(logger: ILogger<HostedWorker>) =
    let timer = Timer.create (fun now -> logger.LogInformation $"Running {now:T}")

    interface IHostedService with
        member _.StartAsync(token: CancellationToken) =
            task {
                logger.LogInformation "Launching 🚀"
                do! Timer.start (TimeSpan.FromSeconds 1) token timer
            }

        member _.StopAsync(token: CancellationToken) =
            task {
                do! Timer.stop token timer
                logger.LogInformation "Quitting 👋"
            }

    interface IDisposable with
        member _.Dispose() =
            logger.LogInformation "Cleaning Up 🧹"
            timer.Dispose()
