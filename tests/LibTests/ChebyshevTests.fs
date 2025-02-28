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