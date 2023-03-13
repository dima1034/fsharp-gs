open System

[<EntryPoint>]
let main argv =
    printfn "Hello from F#!"
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code