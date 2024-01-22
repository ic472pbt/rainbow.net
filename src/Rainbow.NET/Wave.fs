﻿namespace Rainbow.NET
open System
open System.Numerics

type Wave(k, N, C: Complex) =
    let π = Math.PI
    member _.k = k
    member _.N = N
    member _.Omega = if N > 0 then 2.0 * π * float k/float N else 0.0
    member _.C = C
    member _.Magnitude = C.Magnitude
    member _.Phase = C.Phase
    member _.isConstant = k = 0
    member _.isMedian = N % 2 = 0 && k = N/2
    member _.Change newC = Wave(k, N, newC)
    member wave.ToTimeDomain N = 
        match wave with
        | me when me.isConstant ->
            Array.replicate N C.Real
        | me when me.isMedian ->
            [0..N-1] 
                |> List.map float 
                |> List.map (fun t -> C.Magnitude * cos(π * t + C.Phase)) 
                |> List.toArray
        | _ ->
            let w = 2.0 * π * float k/float N in            
            [0..N-1] 
                |> List.map float 
                |> List.map (fun t -> 2.0*C.Magnitude * cos(w * t + C.Phase)) 
                |> List.toArray

    override wave.ToString() =
        match wave with
        | me when me.isConstant ->
            $"({k}) -> Const = {wave.C.Real:f4}"
        | me when me.isMedian ->
            $"({k}) -> Median = {wave.C.Real:f4}"
        | _ -> 
            $"({k}) -> A = {wave.Magnitude:f4} arg = {wave.Phase:f4} C = {C.Real:f3}{if C.Imaginary < 0 then '-' else '+'}{abs C.Imaginary:f3}i"

    new (k, N, A, φ) = Wave(k, N, Complex.FromPolarCoordinates(A, φ))

    static member (*) (k: float, w: Wave) = 
        Wave(w.k, w.N, Complex(k*w.C.Real,k*w.C.Imaginary))            
    static member (+) (w: Wave, z: Wave) = 
        if w.N <> z.N && w.N * z.N > 0 then invalidArg (nameof w) "N value mismatch"
        if w.k <> z.k then invalidArg (nameof w) "k value mismatch"
        w.Change(w.C + z.C)

