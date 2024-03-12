namespace Rainbow.NET
open System
open System.Numerics

type Wave(k, N, C: Complex) =
    let π = Math.PI
    let ππ = 2.0 * π
    // normalized C
    let nC = if k = 0 then Complex(C.Real,0.0) else C
    member _.k = k
    member _.N = N
    member _.Omega = if N > 0 then ππ * float k/float N else 0.0
    member _.C:Complex = nC
    member _.Magnitude = nC.Magnitude
    member _.Phase = nC.Phase
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
            let w = wave.Omega in            
            [0..N-1] 
                |> List.map float 
                |> List.map (fun t -> 2.0*C.Magnitude * cos(w * t + C.Phase)) 
                |> List.toArray
    /// Normalize reflected waves
    member wave.Normalize =
        match wave with
        | w when w.Magnitude < Config.TOL -> Wave(0, N, 0.0)
        | w when w.isMedian -> Wave(w.k, w.N, (cos w.Phase) * w.Magnitude, 0.0)
        | w when w.k < 0 ->  Wave(-w.k, w.N, Complex.Conjugate w.C)
        | w when w.k > w.N/2 -> Wave(w.N - w.k, w.N, Complex.Conjugate w.C)
        | w -> w

    override wave.ToString() =
        match wave with
        | me when me.isConstant ->
            $"({k}) -> Const = {nC.Real:f3}"
        | me when me.isMedian ->
            $"({k}) -> Median = {wave.C.Real:f4}"
        | _ -> 
            $"({k}) -> A = {wave.Magnitude:f4} arg = {wave.Phase:f4} C = {nC.Real:f3}{if nC.Imaginary < 0 then '-' else '+'}{abs nC.Imaginary:f3}i"

    new (k, N, A, φ) = Wave(k, N, Complex.FromPolarCoordinates(A, φ))

    static member (*) (k: float, w: Wave) = 
        Wave(w.k, w.N, Complex(k*w.C.Real, k*w.C.Imaginary))            
    static member (+) (w: Wave, z: Wave) = 
        if w.N <> z.N && w.N * z.N > 0 then invalidArg (nameof w) "N value mismatch"
        if w.k <> z.k then invalidArg (nameof w) "k value mismatch"
        w.Change(w.C + z.C)

