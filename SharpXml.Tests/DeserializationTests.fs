﻿namespace SharpXml.Tests

module DeserializationTests =

    open System
    open NUnit.Framework

    open SharpXml
    open SharpXml.Tests.TestHelpers
    open SharpXml.Tests.Types

    let deserialize<'a> input =
        XmlSerializer.DeserializeFromString<'a>(input)

    [<Test>]
    let deserialize01() =
        let out = deserialize<TestClass>("<testClass><v1>42</v1><v2>bar</v2></testClass>")
        out.V1 |> should equal 42
        out.V2 |> should equal "bar"