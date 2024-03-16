namespace Rainbow.NET
open System.Diagnostics
[<AutoOpen>]
module DSL =
    let inline sq x:float = x * x
    let (|>>) x f = 
        f x
        x
    let log s x = Debug.WriteLine(sprintf "%s %A" s x)
