using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class OrderAddressStateNormalizerTests
    {
        /*[TestMethod]
        public void ShouldNormalizeCleanState()
        {
            var normalizer = new OrderAddressStateNormalizer(null);
            var updatedItem = new FraudRadar.Order
            {
                State = "illinois"
            };
            normalizer.Modify(updatedItem);

            updatedItem.State.Should().Be("illinois");
        }*/

        [TestMethod]
        public void ShouldNormalizeDirtyState()
        {
            var normalizer = new OrderAddressStateNormalizer(null);
            var updatedItem = new FraudRadar.Order
            {
                State = "il"
            };
            normalizer.Modify(updatedItem);

            updatedItem.State.Should().Be("illinois");
        }
    }
}
