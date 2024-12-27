namespace Euler.Tests
open FsCheck
open Xunit

module Euler_1 =
    open Euler.Library.SumOfMultiples
    [<Fact(Skip = "Done testing")>]
    let ``f(10) = 23`` () =
        Assert.Equal(23, sumOfMultiples3Or5Below 10)

    [<Fact(Skip = "Done testing")>]
    let ``Property Test: f(x) = 0 for x <= 0`` () =
        let genNegativeOrZero = Gen.choose (-1000, 0) |> Arb.fromGen
        let prop = Prop.forAll genNegativeOrZero (fun (x: int) -> sumOfMultiples3Or5Below x = 0)
        Check.One({ Config.Default with MaxTest=100 }, prop)
        //Check.Quick prop

    [<Fact(Skip = "Done testing")>]
    let ``Property Test: f(x) > x for x >= 6`` () =
        let genGreaterThanOrEqual6 = Gen.choose (6, 1000) |> Arb.fromGen
        let prop = Prop.forAll genGreaterThanOrEqual6 (fun (x: int) -> sumOfMultiples3Or5Below x > x)
        Check.One({ Config.Default with MaxTest=100 }, prop)

module Euler_2 = 
    open Euler.Library.EvenFibonacciNumbers
    [<Fact(Skip = "Done testing")>]
    let ``f(10) = sum(2;8;34;)`` () =
        Assert.Equal([2;8;34;] |> List.sum, evenFib 10)
    // Not many useful properties..

module Euler_3 =
    open Euler.Library.LargestPrimeFactor
    [<Fact>]
    let ``f(13195) = 29`` () =
        Assert.Equal(29L, bigP 13195L)
    [<Fact>]
    let ``f(600851475143) = 6857`` () =
        Assert.Equal(6857L, bigP 600851475143L)