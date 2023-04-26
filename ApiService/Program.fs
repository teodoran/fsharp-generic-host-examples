module Example.ApiService.Program

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

let args = Environment.GetCommandLineArgs()[1..]
let builder = WebApplication.CreateBuilder(args)
builder.Services.AddHostedService<Worker>() |> ignore

let application = builder.Build()
application.MapGet("/", Func<string>((fun () -> "Hello World!"))) |> ignore
application.Run()