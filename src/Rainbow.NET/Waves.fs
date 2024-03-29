﻿namespace Rainbow.NET
open System
open System.Numerics
open System.Collections.Generic
open System.Diagnostics

        
    type DFT(s: Harmonics) =
        let π = Math.PI
        let dft: Complex [] = Array.zeroCreate s.Length
        let N = (float)s.Length
        do for i = 0 to s.Length - 1 do
            let ω = 2.0 * π * (float)i/N
            let a = s |> Seq.mapi (fun n el -> el * cos(ω * (float)n)) |> Seq.sum
            let b = s |> Seq.mapi (fun n el -> el * sin(ω * (float)n)) |> Seq.sum
            dft[i] <- Complex(a/N,-b/N)
        member _.Item i = dft[i]
        member _.GetSlice(a: int option, b: int option) = dft[a.Value..b.Value]
        member _.Coefitients = dft
            
    and Harmonics(x: seq<float>) =
        let N = Seq.length x
        let signal: float [] = x |> Seq.toArray

        member _.Length = N
        member _.Item i = Seq.item i x
        member me.ToSignal = 
            let dft = DFT(me)
            let uLimit = N/2 // if N % 2 = 0 then N/2 + 1 else N/2 
            match  
                dft[0..uLimit] 
                    |> Array.mapi (fun k el ->
                                    if el.Magnitude < Config.TOL then 
                                        None 
                                    else 
                                        Some <| Signal.FromComplex(k,N,el)) 
                    |> Array.choose id
            with 
            | [||] -> Signal.Zero
            | A -> A |> Array.reduce (+) 
                
        interface seq<float> with
            member _.GetEnumerator() = signal.GetEnumerator()
            member _.GetEnumerator() = (Seq.cast<float> x).GetEnumerator()         
    

    
