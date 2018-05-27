using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class OrderFileReaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldDetectNotExistingPath()
        {
            var parser = new Mock<IOrderParser>();
            var modifier = new Mock<IOrderModifier>();

            var reader = new OrderFileReader("imaginaryDir.txt", parser.Object, modifier.Object);
        }

        [TestMethod]
        [DeploymentItem("./Files/TwoLines_FraudulentSecond.txt", "Files")]
        public void ShouldCallParserForEachLine()
        {
            var linesThatParserReceived = new List<string>();
            var parser = new Mock<IOrderParser>();
            parser.Setup(o => o.Parse(It.IsAny<string>()))
                .Returns((string line) =>
                {
                    linesThatParserReceived.Add(line);
                    return new FraudRadar.Order();
                });

            var modifier = new Mock<IOrderModifier>();
            var path = Path.Combine(Environment.CurrentDirectory,
                "Files", "TwoLines_FraudulentSecond.txt");
            var reader = new OrderFileReader(path, parser.Object, modifier.Object);

            var result = reader.ReadAll().ToArray();

            parser.Verify(o => o.Parse(It.IsAny<string>()),
                Times.Exactly(2));
            CollectionAssert.AreEqual(
                expected: new string[] { "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010",
                                         "2,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689011"},
                actual: linesThatParserReceived,
                message: "The wrong lines were passed from the text file into a parser.");
        }
    }
}
