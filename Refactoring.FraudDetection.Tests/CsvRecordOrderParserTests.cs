using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class CsvRecordOrderParserTests
    {
        [TestMethod]
        public void ShouldParseAndLowerNames()
        {
            var parser = new CsvRecordOrderParser();

            var result = parser.Parse("33,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010");

            result.Should().NotBeNull();
            result.OrderId.Should().Be(33);
            result.DealId.Should().Be(1);
            result.Email.Should().Be("bugs@bunny.com");
            result.Street.Should().Be("123 sesame st.");
            result.City.Should().Be("new york");
            result.State.Should().Be("ny");
            result.ZipCode.Should().Be("10011");
            result.CreditCard.Should().Be("12345689010");
        }
    }
}
