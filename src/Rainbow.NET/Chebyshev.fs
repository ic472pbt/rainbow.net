namespace Rainbow.NET
module Chebyshev =
    let C n k =
        if k > n then 0
        elif k = 0 || k = n then 1
        else
            let k = min k (n - k) // Use symmetry C(n, k) = C(n, n-k) to reduce calculations
            seq {1..k} 
                |> Seq.fold (fun acc i -> acc * (n - i + 1) / i) 1
    
    type T(coeffs: int list) =
        new (n: int) =
            let rec compute (tn:T) (tn1:T) k =
                if k = n then tn
                else
                    let tn2 = tn
                    let tn1' = (!*)(2 * tn1) + (-1 * tn2)
                    compute tn1 tn1' (k + 1)
            let newT =
                if n = 0 then [1]      // T_0(x) = 1
                elif n = 1 then [0; 1] // T_1(x) = x
                else (compute (T([1])) (T([0; 1])) 0).Coeffs
            T(newT)
        member _.Coeffs = coeffs
        member _.FloatCoeffs = coeffs |> List.map float
        /// Evaluate a polynomial at a given x using Horner's rule
        member T.Eval (x: float) =  List.foldBack (fun coef acc -> acc * x + coef) T.FloatCoeffs 0.0

        /// Polynomial multiplication by a scalar
        static member (*) (c, p: T) = List.map ((*) c) p.Coeffs |> T
        /// Polynomial multiplication by a monomial (x^1)
        static member (!*) (p: T) = 0 :: p.Coeffs |> T
        /// Polynomial addition
        static member (+) (p1: T, p2: T) =
            let len = max (List.length p1.Coeffs) (List.length p2.Coeffs)
            let p1' = List.append p1.Coeffs (List.replicate (len - List.length p1.Coeffs) 0)
            let p2' = List.append p2.Coeffs (List.replicate (len - List.length p2.Coeffs) 0)
            List.map2 (+) p1' p2' |> T