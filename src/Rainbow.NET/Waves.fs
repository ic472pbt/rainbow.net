namespace Rainbow.NET
open System
open System.Numerics
open System.Collections.Generic
open System.Diagnostics
open System.Text
        
    type DFT(dftInit: Complex []) =
        static let π = Math.PI
        let dft = dftInit
        let length = Seq.length dft
        let N = (float)length
            
        new(ts: seq<float>) =
            let length = Seq.length ts
            let N = (float)length
            let fourier i =
                let ω = 2.0 * π * (float)i/N
                let a = ts |> Seq.mapi (fun n el -> el * cos(ω * (float)n)) |> Seq.sum
                let b = ts |> Seq.mapi (fun n el -> el * sin(ω * (float)n)) |> Seq.sum
                Complex(a/N,-b/N)
            let dft: Complex [] = Array.init length fourier
            DFT(dft)
            
        member _.Item i = dft[i]
        member _.GetSlice(a: int option, b: int option) = dft.[a.Value..b.Value]
        member _.DFT = dft
        member _.Fundament = (2.0 * π) / N

            
    and Harmonics(f: Complex[]) =
        let N = Seq.length f
        let dft = DFT(f)
        new(x: seq<float>) =
            Harmonics(DFT(x).DFT)
        
        override _.ToString() = 
            let sb = new StringBuilder()
            for k = 0 to N/2 do
                if k = 0 then
                    sb.AppendLine $"({k}) -> Const = {dft[k].Real:f3}"
                elif k = N/2 then
                    sb.AppendLine $"({k}) -> Median = {dft[k].Real:f4}"
                else
                    sb.AppendLine $"({k}) -> A = {dft[k].Magnitude:f4} arg = {dft[k].Phase:f4} C = {dft[k].Real:f3}{if dft[k].Imaginary < 0 then '-' else '+'}{abs dft[k].Imaginary:f3}i"
                |> ignore
            sb.ToString()

        member _.Length = N
        member _.Dft = dft.DFT
        member _.Item i = Seq.item i f
        member _.Omega = (*) dft.Fundament
        member _.Original = 
            seq{
                for i = 0 to dft.DFT.Length - 1 do
                    let mutable x = 0.0
                    for k = 1 to dft.DFT.Length - 1 do
                        let w = dft[k]
                        x <- x + w.Magnitude * cos(dft.Fundament * (float)(k * i) + w.Phase)
                    yield x/2.0 + dft[0].Real
            }

        static member Constant N (c:float) = Seq.replicate N c |> Harmonics
        static member (+)(h1: Harmonics, h2: Harmonics) =
            Array.map2 (+) h1.Dft h2.Dft |> Harmonics
        static member (*)(k: float, h: Harmonics) =
            Harmonics(h.Dft |> Array.map (fun c -> Complex(c.Real*k, c.Imaginary*k)))        
        static member (!^)(h: Harmonics) =
            h.Original 
                |> Seq.map (sq >> (*)2.0 >> (+)(-1.0))
                |> Harmonics

        interface seq<Complex> with
            member _.GetEnumerator() = dft.DFT.GetEnumerator()
            member _.GetEnumerator() = (Seq.cast<Complex> dft.DFT).GetEnumerator()         
    

    
