module Example.Library.Timer

open System
open System.Threading
open System.Threading.Tasks

let create (run: DateTime -> unit) =
    new Timer((fun _ -> run DateTime.Now), 0, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan)

let start (period: TimeSpan) (token: CancellationToken) (timer: Timer) =
    if token.IsCancellationRequested
    then Task.CompletedTask
    else
        timer.Change(TimeSpan.Zero, period) |> ignore
        Task.CompletedTask

let stop (token: CancellationToken) (timer: Timer) =
    if token.IsCancellationRequested
    then Task.CompletedTask
    else
        timer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan) |> ignore
        Task.CompletedTask

let everySecond (run: DateTime -> unit) =
    new Timer((fun _ -> run DateTime.Now), 0, TimeSpan.Zero, TimeSpan.FromSeconds 1)