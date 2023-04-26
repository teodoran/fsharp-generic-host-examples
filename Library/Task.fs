module Example.Library.Task

open System
open System.Threading
open System.Threading.Tasks

let delay (delay: TimeSpan) (token: CancellationToken) =
    task {
        try
            do! Task.Delay(delay, token)
        with
        | :? TaskCanceledException -> return ()
        | :? ObjectDisposedException -> return ()
        | error -> raise error
    }

let wait = delay Timeout.InfiniteTimeSpan