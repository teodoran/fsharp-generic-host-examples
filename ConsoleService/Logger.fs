module Example.ConsoleService.Logger

open Microsoft.Extensions.Logging

type private Says = class end

let create () =
    LoggerFactory
        .Create(fun builder -> builder.AddConsole() |> ignore)
        .CreateLogger<Says>()
        :> ILogger