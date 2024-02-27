open Rainbow.NET

let model = Model(8)
// Three inputs boolean function example. 
// define inputs
//let X1 = model.CreateInput([-1.0; 1.0; -1.0; 1.0;-1.0; 1.0;-1.0; 1.0;], "x1")
//let X2 = model.CreateInput([-1.0; 1.0; 1.0; -1.0;-1.0; 1.0; 1.0; -1.0;], "x2")
//let X3 = model.CreateInput([-1.0; -1.0; -1.0; -1.0; 1.0; 1.0; 1.0; 1.0;], "x3")

let X1 = model.CreateInput([1.0; 2.0; 3.0; 4.0; 5.0; 6.0; 7.0; 8.0;], "x1")
let X2 = model.CreateInput([2.0; 3.0; 4.0; 5.0; 6.0; 7.0; 8.0; 1.0;], "x2")
let X3 = model.CreateInput([3.0; 4.0; 5.0; 6.0; 7.0; 8.0; 1.0; 2.0;], "x3")

// define non-linear node
let N = model.CreateNode(-Dub(0.25 * (Var "x1" + Var "x2")) - 0.25 * Var "x2" - Bias(3.0/4.0), "n")
// time reconstruction
let T = model.CreateNode(2.0 * Var "x3" + 0.5 * Var "x1" + Var "x2" + 4.0 * Var "n" + Bias(3.5), "t")


// ----------- solutions ---------------

// One-hot XOR solution. Detect there is exactly one high input
let Y = model.CreateOutput([-1.0; -1.0; 1.0; 1.0; 1.0; -1.0; -1.0; -1.0;], "y")
let HXOR = model.CreateNode(-Bias(0.25) - 0.25 * Var "x1" + Var "n" + Color("y", "t", 1) + Color("y", "t", 3), "hxor")

// AND gate. Detect all inputs are high.
let Y1 = model.CreateOutput([-1.0; -1.0; -1.0; -1.0; -1.0; 1.0; -1.0; -1.0;], "y1")
let AND = model.CreateNode(-Bias(0.75) + 0.25*Var "x1" - Var "n" + Color("y1", "t", 1)  + Color("y1", "t", 3), "and")

// TWO ones detector. Detect there are exactly two high inputs.
let Y2 = model.CreateOutput([-1.0; 1.0; -1.0; -1.0; -1.0; -1.0; 1.0; 1.0;], "y2")
let TWO = model.CreateNode(-Bias(0.25) + 0.25*Var "x1" + Var "n" + 0.5 * Var "x2" + Color("y2", "t", 1)  + Color("y2", "t", 3), "two")

// XOR parity check. Detect the number of high inputs is odd.
let Y3 = model.CreateOutput([-1.0; -1.0; 1.0; 1.0; 1.0; 1.0; -1.0; -1.0;], "y3")
let XOR = model.CreateNode(Color("y3", "t", 1)  + Color("y3", "t", 3), "xor")

// Random values
let rnd = [let R = System.Random() in for _ = 0 to 7 do yield R.NextDouble()]
let Y4 = model.CreateOutput(rnd, "y4")

let bias = Y4.TryGetWave 0 |> Option.map (fun w -> w.C.Real) |> Option.defaultValue 0.0 |> Bias 
let k1 = Y4.TryGetWave 4 |> Option.map (fun w -> w.C.Magnitude * cos(w.C.Phase)) |> Option.defaultValue 0.0
let h2 = Y4.TryGetWave 2 |> Option.map (fun w -> w.C) |> Option.defaultValue (System.Numerics.Complex(0.0, 0.0))
let x2complex = X2.TryGetWave 2 |> Option.map (fun w -> w.C) |> Option.defaultValue (System.Numerics.Complex(0.0, 0.0))
let ncomplex = N.TryGetWave 2 |> Option.map (fun w -> w.C) |> Option.defaultValue (System.Numerics.Complex(0.0, 0.0))
let det = x2complex.Real * ncomplex.Imaginary - ncomplex.Real * x2complex.Imaginary
let k2 = (h2.Real * ncomplex.Imaginary - ncomplex.Real * h2.Imaginary)/det
let k3 = (x2complex.Real * h2.Imaginary - h2.Real * x2complex.Imaginary)/det

let RND = model.CreateNode(bias - k1 * Var "x1" + k2 * Var "x2" + k3 * Var "n" + Color("y4", "t", 1)  + Color("y4", "t", 3), "rnd")

let L =
    [
        [-1.0; -1.0; -1.0]
        [1.0; 1.0; -1.0]
        [-1.0; 1.0; -1.0]
        [1.0; -1.0; -1.0]
        [-1.0; -1.0; 1.0]
        [1.0; 1.0; 1.0]
        [-1.0; 1.0; 1.0]
        [1.0; -1.0; 1.0]
    ]
printfn "HXOR"
L |> List.iter (fun t -> printfn "%A -> %f" t (model.Evaluate(t)["hxor"]))
printfn "AND"
L |> List.iter (fun t -> printfn "%A -> %f" t (model.Evaluate(t)["and"]))
printfn "TWO"
L |> List.iter (fun t -> printfn "%A -> %f" t (model.Evaluate(t)["two"]))
printfn "XOR"
L |> List.iter (fun t -> printfn "%A -> %f" t (model.Evaluate(t)["xor"]))
printfn "RND"
L |> List.iteri (fun i t -> let ev = model.Evaluate(t) in printfn "%A -> %f expected %f" t (ev["rnd"]) (rnd[i]) )
