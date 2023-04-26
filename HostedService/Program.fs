module Example.HostedService.Program

open System
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

let args = Environment.GetCommandLineArgs().[1..]
Host.CreateDefaultBuilder(args)
    .ConfigureServices(fun _ services ->
        services
            // .AddHostedService<BrokenWorker>()
            .AddHostedService<BackgroundWorker>()
            // .AddHostedService<ExceptionWorker>()
            // .AddHostedService<HostedWorker>()
        |> ignore)
    .Build()
    .Run()