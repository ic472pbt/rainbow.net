namespace Rainbow.NET
open System.Numerics
    type Signal =
        | Empty
        | Harmonic of Wave
        | Sum of Signal * Signal
        with
            member me.ToTimeDomain N =
                let rec innerLoop (acc: float []) = function
                    | Empty -> acc
                    | Harmonic w -> 
                        Array.map2 (+) acc (w.ToTimeDomain N)
                    | Sum(w, z) -> 
                        let a = innerLoop acc w
                        innerLoop a z                        
                innerLoop (Array.zeroCreate N) me
            member me.TryGetWave(k) =
                let rec innerLoop = function
                    | Empty -> None
                    | Harmonic h when h.k = k -> Some h
                    | Sum(w, z) -> innerLoop w |> Option.orElseWith (fun () -> innerLoop z)
                    | _ -> None
                innerLoop me
            override s.ToString() =
                let rec innerLoop (acc: System.Text.StringBuilder) = function
                    | Empty -> acc
                    | Harmonic w -> Printf.bprintf acc "\t%A\n" w; acc
                    | Sum(z, w) -> (innerLoop acc z, w) ||> innerLoop
                (innerLoop (System.Text.StringBuilder()) s).ToString()
            static member Constant (c: float) = Wave(0, 0, c) |> Harmonic
            static member Zero = Signal.Constant 0.0
            static member (+) (x, y) = 
                match x,y with
                | Empty, x | x, Empty -> 
                    x
                | Harmonic w, Harmonic z when w.k = z.k -> 
                    w + z |> Harmonic |> Signal.Normalize
                | x, y -> 
                    Sum(x, y)
            static member (-) (x: Signal, y: Signal) = x + (-1.0)*y
            static member (*) (k:float, H: Signal) = 
                match H with
                | Empty -> Empty
                | Harmonic w -> Harmonic(k*w)
                | Sum(x, y) -> k*x + k*y
            static member (*) (w:Signal, z: Signal) = 
                match w, z with
                | Empty, x | x, Empty -> x
                | x, Sum(y, z) | Sum(y, z), x -> x*y + x*z
                | Harmonic w, Harmonic z | Harmonic z, Harmonic w when w.isConstant ->
                    Harmonic <| Wave(z.k, z.N, z.C * w.C)
                | Harmonic w, Harmonic z -> 
                    Sum(
                        Harmonic <| Wave(w.k + z.k, w.N, w.Magnitude * z.Magnitude * 0.5, w.Phase + z.Phase) |> Signal.Normalize, 
                        Harmonic <| Wave(w.k - z.k, w.N, w.Magnitude * z.Magnitude * 0.5, w.Phase - z.Phase) |> Signal.Normalize
                       )
            static member (!^) x = 
                match x with
                | Empty -> Empty
                | Harmonic w when w.isMedian -> 
                    2.0 * w.Magnitude * w.Magnitude - 1.0 |> Signal.Constant
                | Harmonic w when w.N % 2 = 0 && w.k * 2 = w.N/2 -> 
                    let a2 = 4.0*w.Magnitude*w.Magnitude in 
                    let fi2 = w.Phase * 2.0
                    if abs(a2*cos(fi2)) < Config.TOL then
                        a2 - 1.0 |> Signal.Constant
                    else
                        Sum (a2 - 1.0 |> Signal.Constant, Wave(w.k * 2, w.N, a2 * cos fi2, 0.0) |> Harmonic)
                | Harmonic w -> 
                    let a2 = w.Magnitude*w.Magnitude in 
                    let h = Harmonic <| Wave(w.k * 2, w.N, a2, w.Phase * 2.0) |> Signal.Normalize
                    Sum(a2 - 1.0 |> Signal.Constant, h) |> Signal.Collect
                | Sum(A, B) -> 
                    !^A  + !^B + 4.0 * A * B + Signal.Constant 1.0
                        |> Signal.Collect
            static member Normalize (w: Signal) = 
                match w with
                | Harmonic h when h.Magnitude < Config.TOL -> Signal.Zero
                | Harmonic w when w.k < 0 ->
                    Harmonic <| Wave(-w.k, w.N, Complex.Conjugate w.C)
                | Harmonic w when w.k > w.N/2 ->
                    Harmonic <| Wave(w.N - w.k, w.N, Complex.Conjugate w.C)
                | _ -> w
            static member FromComplex(k: int, N: int, re: float, im: float) = Signal.FromComplex(k,N,Complex(re,im))
            static member FromComplex(k: int, N: int, C: Complex) = 
                match k with
                | k when k < N/2 -> Harmonic <| Wave(k, N, C)
                | k -> Harmonic <| Wave(N-k, N, Complex.Conjugate C) // mirroring
            static member Collect (h: Signal) =
               let rec innerLoop (acc: Map<int, Signal>) = function
                   | Empty -> acc               
                   | Harmonic w -> acc.Change(w.k, (function | None -> Some(Harmonic w) | Some V -> Some(V + Harmonic w)))
                   | Sum(x, y) -> 
                        let accX = innerLoop Map.empty x
                        let accY = innerLoop Map.empty y
                        Map.fold (fun (acc: Map<int, Signal>) key el -> acc.Change(key, (function | None -> Some(el) | Some V -> Some(V + el)))) accX accY
               h 
                |> innerLoop Map.empty 
                |> Map.fold (fun acc _ el -> let nel = el |> Signal.Normalize in Sum(acc, nel)) Empty

