namespace Euler.Main
open Euler.Library.SumOfMultiples
open Euler.Library.EvenFibonacciNumbers
open Euler.Library.LargestPrimeFactor

module Program =
    let main args = 
        printfn "Euler 1 is: %d" (sumOfMultiples3Or5Below 1000)
        printfn "Euler 2 is: %d" (evenFib 4000000)
        printfn "Euler 3 is: %d" (bigP 600851475143L)
        0
    [<EntryPoint>]
    let mainEntryPoint args = main args
