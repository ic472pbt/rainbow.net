namespace Rainbow.NET
module Chebyshev =
    let C n k =
        if k > n then 0
        elif k = 0 || k = n then 1
        else
            let k = min k (n - k) // Use symmetry C(n, k) = C(n, n-k) to reduce calculations
            seq {1..k} 
                |> Seq.fold (fun acc i -> acc * (n - i + 1) / i) 1
