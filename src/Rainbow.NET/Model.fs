namespace Rainbow.NET
open System
open System.IO
open System.Collections.Generic
open System.Text
open System.Diagnostics

type Node =
    | Bias of float
    | Var of string
    | Mul of float * Node
    | Add of Node * Node
    | Dub of Node
    | Color of string*string*int
    with
        override me.ToString() =
            let rec innerLoop n =
                match n with
                | Bias b -> b, abs(b).ToString("F3")
                | Var v -> 1.0, $"[{v}]"
                | Mul(a,n) -> 
                    if abs a < Config.TOL then 
                        0.0, "" 
                    elif abs(abs a - 1.0) < Config.TOL then
                        let aLoop = innerLoop n
                        a * (fst aLoop), $"{snd aLoop}"
                    else 
                        let aLoop = innerLoop n
                        a * fst aLoop, $"{abs (a * fst aLoop):f3} * {snd aLoop}"
                | Add(a,b) ->                
                    let aLoop, bLoop = innerLoop a, innerLoop b
                    if abs (fst aLoop) < Config.TOL then
                        if (abs <| fst(bLoop)) < Config.TOL then 
                            0.0, String.Empty 
                        elif fst bLoop > 0.0 then fst bLoop, $"{snd bLoop}"
                        else fst bLoop, $"{snd bLoop}"
                    else 
                        if (abs <| fst(bLoop)) < Config.TOL then 
                            fst aLoop, $"{snd aLoop}" 
                        elif fst bLoop > 0.0 then fst aLoop, $"{snd aLoop} + {snd bLoop}"
                        else fst aLoop, $"{snd aLoop} - {snd bLoop}"
                    //fst aLoop, $"{snd aLoop}" + if (abs <| fst(bLoop)) < Config.TOL then String.Empty elif fst bLoop > 0.0 then $" + {snd bLoop}" else $" - {snd bLoop}"
                | Dub n -> 
                    let aLoop = innerLoop n 
                    let sign = if (abs <| fst(aLoop)) < Config.TOL then String.Empty elif fst aLoop > 0.0 then " + " else " - "
                    1.0, $"^2({sign}{snd aLoop})"
                | Color(a,b,c) -> 1.0, "C"
            let aLoop = innerLoop me
            if (abs <| fst(aLoop)) < Config.TOL then String.Empty elif fst aLoop > 0.0 then $"{snd aLoop}" else $"-{snd aLoop}"
        static member (+)(n1: Node, n2: Node) = Add(n1, n2)
        static member (-)(n1: Node, n2: Node) = Add(n1, -n2)
        static member (*)(k: float, n: Node) = 
            match n with
            | Bias b -> Bias(k*b)
            | Var v -> Mul(k, Var v)
            | Mul(a,n) -> Mul(k*a, n)
            | Add(a,b) -> Add(Mul(k,a), Mul(k,b))
            | Dub n -> Mul(k, Dub(n))
            | Color(a,b,c) -> Mul(k, Color(a,b,c))
        static member (~-)(n: Node) =
            match n with
            | Bias b -> Bias(-b)
            | Var v -> Mul(-1.0, Var v)
            | Mul(k,n) -> Mul(-k, n)
            | Add(a,b) -> Add(-a,-b)
            | Dub n -> Mul(-1.0, Dub(n))
            | Color(a,b,c) -> Mul(-1.0, Color(a,b,c))


type NodeType = Input of Signal | Node of Signal 
    with 
        member me.AsSignal = match me with | Input s | Node s -> s
        member me.isInput = match me with | Input _ -> true | _ -> false

type Model(N: int) =
    let inputs = Dictionary<string, NodeType>()
    let nodes = Dictionary<string, Node>()
    let output = Dictionary<string,Signal>()
    with
        /// The number of waves available in the model N/2
        member _.HalfN = N/2 + 1
        /// Nodes in the model
        member _.Nodes = nodes
        member me.LoadData(fileName:string) =
            use file = File.OpenText fileName
            let varNames = 
                file.ReadLine().Split ' '
            let vars = Dictionary<int, float list>()
            varNames |> Array.iteri (fun i _ -> vars.Add(i,[]))
            while not (file.EndOfStream) do
                file.ReadLine().Split ' ' 
                    |> Array.map Double.Parse
                    |> Array.iteri (fun i v -> vars[i] <- v::vars[i])                
            let inputs =
                varNames[0..varNames.Length - 2]
                    |> Array.mapi (fun i v -> me.CreateInput(List.rev vars[i], v))
            inputs, me.CreateOutput(vars[varNames.Length - 1], varNames[varNames.Length - 1])
        member _.CreateInput(series:IEnumerable<float>, name: string) = 
            inputs.Add(name, Harmonics(series).ToSignal |> Input)
            let debugString = sprintf "-> input var %s added signal \n%O" name inputs[name].AsSignal
            printfn "%s" debugString; Debug.WriteLine(debugString)
            inputs[name].AsSignal
        member _.Inputs = inputs
        member _.CreateOutput(series:IEnumerable<float>, name: string) = 
            output.Add(name, Harmonics(series).ToSignal)
            printfn "-> output var %s added signal \n%O" name output[name]
            output[name]
        member _.Outputs = output
        member my.CreateNode(node, name) = 
            nodes.Add(name, node)
            inputs.Add(name, my.nodeAsSignal node |> Node)
            printfn "-> input var %s added signal \n%O" name inputs[name].AsSignal
            inputs[name].AsSignal                
        member _.nodeAsSignal node = 
            let rec innerLoop = function
                | Color(outpName, name, k) -> 
                    match output[outpName].TryGetWave k with
                    | Some wave ->
                        let w = wave.Omega
                        let φ = wave.Phase
                        2.0 * wave.Magnitude * Harmonics(inputs[name].AsSignal.ToTimeDomain(N) |> Array.map ((*)w >> (+)φ >> cos)).ToSignal
                    | None -> failwith $"target wave k = {k} not found in {outpName}"
                | Bias c -> Signal.Constant c
                | Var name -> 
                    let varSignal = inputs[name].AsSignal
                    varSignal
                | Mul(k, n) -> k * innerLoop n
                | Add(a, b) -> Sum(innerLoop a, innerLoop b)
                | Dub(n) -> !^(innerLoop n |> Signal.Collect)
            innerLoop node |> Signal.Collect
        member _.Evaluate(x: IEnumerable<float>) =
            let rec innerLoop (inputsValues:Map<string, float>) = function
                | Color(outpName, name, k) -> 
                    match output[outpName].TryGetWave k with
                    | Some wave ->
                        let w = wave.Omega
                        let φ = wave.Phase
                        2.0 * wave.Magnitude * (inputsValues[name] |> ((*)w >> (+)φ >> cos))
                    | _ -> failwith $"target wave k = {k} not found in {outpName}"
                | Bias c -> c
                | Var name -> inputsValues[name]
                | Mul(k, n) -> k * innerLoop inputsValues n
                | Add(a, b) -> innerLoop inputsValues a + innerLoop inputsValues b
                | Dub(n) -> let v = innerLoop inputsValues n in 2.0*v*v - 1.0
            let rec eval (map:Map<string, float>) (L:KeyValuePair<string, NodeType> list) = 
                match L, map.Count with
                | [], _ -> map
                | h::t, n when h.Value.isInput -> 
                    eval (map.Add(h.Key, x |> Seq.item n)) t
                | h::t, _ ->
                    eval (map.Add(h.Key, innerLoop map (nodes[h.Key]))) t                        
                
            eval Map.empty (inputs |> List.ofSeq)