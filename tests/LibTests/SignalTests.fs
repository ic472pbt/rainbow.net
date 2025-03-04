namespace LibTests
module HarmonicsTests =
    open System
    open System.Numerics
    open Rainbow.NET
    open NUnit.Framework
    open FsCheck
    open FsCheck.NUnit

    [<SetUp>]
    let Setup () =
        ()

    [<Property>]
    let ``Mixer node transforms constant`` c =
        let S = Signal.Constant c
        let observed = !^S
        let expected = 2.0 * c * c - 1.0
        observed.GetConstant = 
            expected || Double.IsNaN c
    
    [<Property(MaxTest=10)>]
    let ``Mixer node doubles the phase of the harmonic`` (k:int) (N:int) (P:float) =
        let ak = abs k + 1 // exclude constant
        let C = Complex.FromPolarCoordinates(1.0, P)
        let wave = Wave(ak, N, C)
        (N > 2 && 2 * ak < N/2) ==> // exclude median
                let observed = !^Harmonic(wave)
                let expected = observed.TryGetWave(2*ak)
                expected 
                    |> Option.map (fun w -> 
                        match w with
                        | _ ->
                            let delta = abs(cos w.Phase - cos(2.0*wave.Phase))
                            delta < Config.TOL || 
                            wave.Magnitude < Config.TOL ||
                            w.Magnitude < Config.TOL ||
                            Double.IsNaN wave.Phase || 
                            wave.Magnitude > pown 10.0 8
                       )
                    |> Option.defaultValue (C.Magnitude < Config.TOL)

    [<Test>]
    let ``Mixer node transforms sum of const and a wave`` () =
        let N = 10
        let wave1 = Wave(0, N, Complex(1,0))
        let wave2 = Wave(2, N, Complex(3,4))
        let observed = !^(Harmonic(wave1) + Harmonic(wave2))
        let expected = Signal.Constant 101.0 + 
                        Harmonic(Wave(2, N, Complex(24.0, 32.0))) +
                        Harmonic(Wave(4, N, Complex(-14.0, 48.0)))
        let eq = 
            [ for k in [0;2;4] do
                let wObserved = observed.TryGetWave(k).Value
                let wExpected = expected.TryGetWave(k).Value
                (wObserved.C - wExpected.C).Magnitude < Config.TOL
            ]
        Assert.IsTrue(eq |> List.forall id)

    [<Test>]
    let ``Mixer node transforms sum of a wave and a wave`` () =
        let N = 10
        let wave1 = Wave(1, N, Complex(1,2))
        let wave2 = Wave(2, N, Complex(3,4))
        let observed = !^(Harmonic(wave1) + Harmonic(wave2))
        let expected = Signal.Constant 119.0 + 
                        Harmonic(Wave(1, N, Complex(44.0, -8.0))) +
                        Harmonic(Wave(2, N, Complex(-6.0, 8.0))) +
                        Harmonic(Wave(3, N, Complex(-20.0, 40.0))) +
                        Harmonic(Wave(4, N, Complex(-14.0, 48.0)))
        let eq = 
            [ for k in 0..4 do
                let wObserved = observed.TryGetWave(k).Value
                let wExpected = expected.TryGetWave(k).Value
                (wObserved.C - wExpected.C).Magnitude < Config.TOL
            ]
        Assert.IsTrue(eq |> List.forall id)
    
    [<Test>]
    let ``Mixer node transforms sum of three waves`` () =
        let N = 3
        let wave1 = Wave(0, N, Complex(-1.739,0.0))
        let wave2 = Wave(1, N, Complex(0.702,-1.41))
        (Harmonic(wave1) + Harmonic(wave2)).ToTimeDomain(N)
        let wave3 = Wave(2, N, Complex(3,4))
        let observed = !^(Harmonic(wave1) + Harmonic(wave2))
        let expected = Signal.Constant 29.0 + 
                        Harmonic(Wave(1, N, Complex(11.0, -2.0))) +
                        Harmonic(Wave(2, N, Complex(-1.5, 2.0))) +
                        Harmonic(Wave(3, N, Complex(-5.0, 10.0))) +
                        Harmonic(Wave(4, N, Complex(-3.5, 12.0)))
        let eq = 
            [ for k in 0..4 do
                let wObserved = observed.TryGetWave(k).Value
                let wExpected = expected.TryGetWave(k).Value
                (wObserved.C - wExpected.C).Magnitude < Config.TOL
            ]
        Assert.IsTrue(eq |> List.forall id)
    [<Property>]
    let ``Mixer node calculated DFT output and directly calculated DFT are equal`` (L: float list) =
        match L with
        | [] -> true
        | L when L |> List.exists (Double.IsInfinity) -> true
        | L when L |> List.exists (Double.IsNaN) -> true
        | _ ->
            let mixedSignal = !^Harmonics(L).ToSignal
            let observed = 
                L 
                |> List.mapi (fun i _ ->  
                        mixedSignal.TryGetWave(i) 
                            |> Option.map (fun w -> w.C) 
                            |> Option.defaultValue(new Complex()) 
                )
            let expected =
                (L
                    |> List.map (fun x -> 2.0 * x * x - 1.0)
                    |> (Harmonics >> DFT)).Coefitients
                 |> List.ofArray
            let test =
                List.exists (fun (c: Complex) -> Double.IsNaN c.Magnitude) observed ||
                List.zip observed expected
                    |> List.take (L.Length/2)
                    |> List.forall (fun (o, e) -> (o - e).Magnitude < 0.000001)
            if not test then
                printfn "observed %A" observed
                printfn "expected %A" expected
                printfn "-----"
            test

    [<Property>]
    let ``Collect flatterns all constants`` (L: double list) =
        let compare() =
            let observedSignal =
                L 
                    |> List.map Signal.Constant
                    |> List.reduce (fun a b -> Sum(a,b))
                    |> Signal.Collect
            let observed = observedSignal.GetConstant
            let expected = L |> List.sum
            Double.IsNaN observed || 
            Double.IsInfinity observed || 
            abs(observed - expected) < Config.TOL && 
            match observedSignal with | Harmonic _ -> true | _ -> false

        L.IsEmpty || compare()

    [<Property>]
    let ``Collect flatterns all waves`` (L: Complex list) =
        let compare() =
            let observedSignal =
                L 
                    |> List.map (fun c -> Harmonic(Wave(1, 3, c)))
                    |> List.reduce (fun a b -> Sum(a,b))
                    |> Signal.Collect
            let observed = observedSignal.TryGetWave(1).Value
            let expected = L |> List.reduce (+)
            Double.IsNaN observed.Magnitude || 
            Double.IsInfinity observed.Magnitude || 
            (observed.C - expected).Magnitude < Config.TOL && 
            match observedSignal with 
            | Sum(Harmonic w, Harmonic _) -> w.isConstant && w.C.Real = 0.0 
            | _ -> false

        L.IsEmpty || compare()        