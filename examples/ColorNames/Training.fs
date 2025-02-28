//#r "nuget: FSharp.Data"
//#r "nuget: MathNet.Numerics"
//#r "nuget: FSharp.Collections.ParallelSeq"
module Training
    open System
    open FSharp.Data
    open System.Numerics
    open MathNet.Numerics.IntegralTransforms
    open FSharp.Collections.ParallelSeq


    let inline (|>>) x f =
        let y = f x
        printfn "%A" y
        y
    type colors = CsvProvider<"color_names.csv">
    let trainCsv = colors.Load("color_names.csv")
    let N = pown 2 24
    let n = trainCsv.Cache().Rows |> Seq.length
    let X = Array.init N (fun _ -> Complex(-1.0, 0.0))
    
    trainCsv.Cache().Rows 
        |> Seq.iteri (fun i r ->
            let address = (r.``Red (8 bit)`` <<< 16) + (r.``Green (8 bit)`` <<< 8) + r.``Blue (8 bit)`` 
            if X[address].Real = -1.0 then X[address] <- Complex(float i, 0.0)
    )
    // spread
    let selectRange startIndex =
        let mutable i = startIndex + 1
        if i >= X.Length then None
        else
            while i < X.Length && X[i].Real = -1.0 do
                i <- i + 1
            Some i
    let fillRange startIndex endIndex =
        let mid = (startIndex + endIndex) / 2
        if mid > startIndex && mid < endIndex then
            for i = startIndex + 1 to mid do X[i] <- X[startIndex]
            // if X[endIndex].Real = -1.0 then 
            //    for i = mid + 1 to endIndex do X[i] <- X[startIndex]
            //else
            for i = mid + 1 to endIndex - 1 do X[i] <- X[endIndex]
    let spread() =
        let rec innerLoop startIndex endIndex =
            match endIndex with
            | None -> ()
            | Some eIdx -> 
                fillRange startIndex eIdx
                innerLoop eIdx (selectRange eIdx)
        innerLoop 0 (selectRange 0)
    spread()
    Fourier.Forward(X, FourierOptions.AsymmetricScaling)

    //let Y = Array.init<Complex> (N/2-1) (fun i -> X[i+1])
    let M = Array.map (fun (el: Complex) -> el.Magnitude) X
    let P = Array.map (fun (el: Complex) -> el.Phase) X

    let colorNames =
        trainCsv.Cache().Rows
            |> Seq.mapi (fun i r -> i, r.Name)
            |> Map.ofSeq        
    let evaluateWith (M:float[]) (P:float[]) R G B = 
        let address = float R * 4096.0 + float G * 16.0 + 0.0625 * float B
        let pi = 32.0 * Math.PI
        let floatN = float N
        let index =
            M                 
                |> PSeq.mapi (fun i m ->
                    if m <> 0.0 then
                         let fi = (((pi*(float i) * address)/floatN + P[i]) % (2.0 * Math.PI))
                         let a = m * (1.0 - (pown fi 2) * 0.5 + (pown fi 4) / 24.0 - 
                                        (pown fi 6) / 720.0 + (pown fi 8) / (720.0 * 56.0) - 
                                        (pown fi 10) / (7200.0 * 7.0 * 72.0) + (pown fi 12) / (7200.0 * 72.0 * 77.0 * 12.0))
                         // printfn "%f" <| ((pi*(float i) * address)/floatN + P[i]) % Math.PI
                         a
                       // m * cos ((pi*(float i) * address)/floatN + P[i])
                    else
                        m
                   )
                |> PSeq.sum
  //              |> (*)2.0
  //              |> (+)X[0].Real
        printfn "%f" (index/floatN)
        let colorNumber = 
            (index * 1.0/floatN)
            |> round
            |> int
        // let name =            
        //    colorNames.TryFind(colorNumber) |> Option.defaultValue "unknown" 
        // printfn "%s" name
        colorNumber
    let evaluate = evaluateWith M P

    let verify (M:float[]) (P:float[]) =
        let matchings =
            trainCsv.Cache().Rows 
               // |> Seq.take 50
                |> Seq.mapi (fun i r -> 
                    let ev = evaluateWith M P (r.``Red (8 bit)``) (r.``Green (8 bit)``) (r.``Blue (8 bit)``)
                    if i = ev then 
                        1
                    else 
                        match trainCsv.Cache().Rows |> Seq.tryItem ev with
                        | None -> 
                            printfn "%i not found" ev
                            0
                        | Some rAlt when rAlt.``Red (8 bit)`` =  (r.``Red (8 bit)``) && 
                                        rAlt.``Green (8 bit)`` = (r.``Green (8 bit)``) &&
                                        rAlt.``Blue (8 bit)`` = (r.``Blue (8 bit)``) -> 1
                        | _ -> 
                            printfn "expected %i %s got %i" i r.Name ev
                            0
                   )
                |> Seq.sum
        (float)matchings/(float n)*100.0

    // let Mc = M |> Array.sortDescending
    // let Mcopy: float [] = M |> Array.map (fun el -> if el >= Mc[800000] then el else 0.0)
    
    // let eval = evaluateWith Mcopy P
    evaluate 166 166 166;;
    verify M P