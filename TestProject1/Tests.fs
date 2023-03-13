module Tests

open System
open Xunit
open FsUnit.Xunit

[<Fact>]
let ``My test`` () =
    let x = 1
    x |> should equal 1