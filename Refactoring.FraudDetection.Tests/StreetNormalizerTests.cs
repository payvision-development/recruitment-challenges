using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class StreetNormalizerTests
    {
        [TestMethod]
        public void ShouldNormalizeDirtyStreet()
        {
            var normalizer = new StreetNormalizer(null);
            var updatedItem = new FraudRadar.Order
            {
                Street = "123 Sesame st."
            };
            normalizer.Modify(updatedItem);

            updatedItem.Street.Should().Be("123 Sesame street");
        }

        [TestMethod]
        public void ShouldNormalizeDirtyRoad()
        {
            var normalizer = new StreetNormalizer(null);
            var updatedItem = new FraudRadar.Order
            {
                Street = "123 Sesame rd."
            };
            normalizer.Modify(updatedItem);

            updatedItem.Street.Should().Be("123 Sesame road");
        }
    }
}
