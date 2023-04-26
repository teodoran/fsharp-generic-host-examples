namespace Example.HostedService

open System
open System.Threading
open Example.Library
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

type ExceptionWorker(logger: ILogger<ExceptionWorker>) =
    inherit BackgroundService()

    let random = new Random()

    override _.ExecuteAsync(token: CancellationToken) =
        task {
            logger.LogInformation "Launching 💣"

            while not token.IsCancellationRequested do
                if random.NextDouble() >= 0.7
                then
                    logger.LogInformation $"Exception 💥"
                    failwith "Oh no!"
                else
                    logger.LogInformation $"Continuing"
                    do! Task.delay (TimeSpan.FromSeconds 1) token
        }
