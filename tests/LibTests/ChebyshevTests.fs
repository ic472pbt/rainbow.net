namespace LibTests
module ChebyshevTests =
    open System
    open System.Numerics
    open Rainbow.NET
    open NUnit.Framework
    open FsCheck
    open FsCheck.NUnit

    [<Literal>]
    let maxN = 20

    [<SetUp>]
    let Setup () =
        ()

    [<Test>]
    let symmetryProperty ([<Range(1,1,maxN)>] n) =
        for k = 0 to n do
            let leftSide = Chebyshev.C n k
            let rightSide = Chebyshev.C n (n - k)
            Assert.AreEqual(leftSide, rightSide)

    [<Test>]
    let sumProperty ([<Range(1,1,maxN)>] n) =
        for k = 1 to n do
            let leftSide = Chebyshev.C n k
            let rightSide = Chebyshev.C (n-1) (k-1) + Chebyshev.C (n-1) k
            Assert.AreEqual(leftSide, rightSide)

    [<Test>]
    let totalNumberProperty ([<Range(1,1,maxN)>] n) =
        let total = [0..n] |> List.sumBy (fun k -> Chebyshev.C n k)
        Assert.AreEqual(total, pown 2 n)

    [<Test>]
    let evenSumProperty ([<Range(1,1,maxN)>] n) =
        let total = [0..n] |> List.sumBy (fun k -> Chebyshev.C n (2*k))
        Assert.AreEqual(total, pown 2 (n-1))

    [<Test>]
    let sumEqualsOneProperty ([<Range(1,1,maxN)>] n:int) =
        Chebyshev.T(n).Coeffs |> List.sum |> (fun s -> Assert.AreEqual(s, 1))

    [<Test>]
    let localProperties ([<Range(0,1,maxN)>] n:int) =
        Assert.AreEqual(Chebyshev.T(n).Eval(1), 1)        
        Assert.AreEqual(Chebyshev.T(n).Eval(-1), pown -1 n)        
        Assert.AreEqual(Chebyshev.T(2*n).Eval(0), pown -1 n)
        Assert.AreEqual(Chebyshev.T(2*n+1).Eval(0), 0)

    [<Test>]
    let parityProperty ([<Range(0,1,maxN)>] n:int) =
        let x = 0.3
        if n % 2 = 0 then
            Assert.AreEqual(Chebyshev.T(n).Eval(x), Chebyshev.T(n).Eval(-x))
        else
            Assert.AreEqual(Chebyshev.T(n).Eval(x), -Chebyshev.T(n).Eval(-x))