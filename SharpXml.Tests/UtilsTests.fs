﻿namespace SharpXml.Tests

module UtilsTests =

    open System
    open NUnit.Framework

    open SharpXml.Attempt
    open SharpXml.Tests.TestHelpers

    [<Test>]
    let attempt01() =
        let runs = ref 0
        let func v = fun () -> runs := !runs + 1; v
        let result = attempt {
            let! v1 = func None
            let! v2 = func None
            let! v3 = func <| Some 20
            v3 }
        result |> should equal (Some 20)
        !runs |> should equal 3

    [<Test>]
    let attempt02() =
        let runs = ref 0
        let func v = fun () -> runs := !runs + 1; v
        let result = attempt {
            let! v1 = func None
            let! v2 = func <| Some 42
            let! v3 = func None
            v3 }
        result |> should equal (Some 42)
        !runs |> should equal 2

    [<Test>]
    let attempt03() =
        let runs = ref 0
        let func v = fun () -> runs := !runs + 1; v
        let result = attempt {
            let! v1 = func None
            let! v2 = func None
            let! v3 = func None
            v3 }
        result |> should equal None
        !runs |> should equal 3

    [<Test>]
    let attempt04() =
        let runs = ref 0
        let func v = fun () -> runs := !runs + 1; v
        let result = attempt {
            let! v1 = func None
            let! v2 = if false then func None else func <| Some 400
            let! v3 = func None
            let! v4 = func None
            v4 }
        result |> should equal (Some 400)
        !runs |> should equal 2