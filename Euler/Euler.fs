namespace Euler.Library

// 1. (new concepts: List operations like List.filer and List.sum)
module SumOfMultiples =
    let sumOfMultiples3Or5Below max =
        [ 1 .. max - 1 ] |> List.filter (fun x -> x % 3 = 0 || x % 5 = 0) |> List.sum

// 2. (new concepts: Recursive Match Looping)
module EvenFibonacciNumbers =
    let evenFib n =
        let rec loop a b acc =
            match a with
            | _ when a > n -> acc
            | _ when a % 2 = 0 -> loop b (a + b) (acc + a)
            | _ -> loop b (a + b) acc

        loop 0 1 0

// 3. (new concepts: Int64, while to rec conversions, tail calls)
module LargestPrimeFactor =
    [<TailCall>] // This will give a compiler warning if the recursion is non-tail call optimizable
    let rec trialDivLoop (a: int64) (acc: int64) =
        match a with
        | _ when a % acc = 0 -> acc
        | _ -> trialDivLoop a (acc + int64 (1))

    let trialDiv (n: int64) = trialDivLoop n 2

    [<TailCall>]
    let rec bigPLoop a acc =
        let trial = trialDiv a

        match trial with
        | _ when trial = a -> trial
        | _ -> bigPLoop (a / trial) (if acc > trial then acc else trial)

    let bigP (n: int64) = bigPLoop n 1

// 4. (new concepts: Int to string, reversing strings, checking string equality, lazy seq syntax)
module LargestPalindromeProduct =
    let isPalindrome (n: int) =
        n.ToString() = System.String(n.ToString() |> Seq.rev |> Array.ofSeq)

    let largestPalindromeProduct () =
        seq {
            for i in 999..-1..100 do
                for j in 999..-1..100 do
                    yield i * j
        }
        |> Seq.filter isPalindrome // Filters to Palindromes
        |> Seq.max
