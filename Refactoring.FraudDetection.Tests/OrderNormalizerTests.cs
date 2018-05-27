using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class OrderNormalizerTests
    {
        [TestMethod]
        public void ShouldNormalizeCleanEmail()
        {
            var normalizer = OrderNormalizer.Default;
            var updatedItem = new FraudRadar.Order
            {
                Email = "bugs@bunny.com",
                Street = "123 Sesame St.",
                State = "NY"
            };
            normalizer.Modify(updatedItem);

            updatedItem.Email.Should().Be("bugs@bunny.com");
        }

        [TestMethod]
        public void ShouldNormalizeDirtyEmail()
        {
            var normalizer = OrderNormalizer.Default;
            var updatedItem = new FraudRadar.Order
            {
                Email = "bugs+elmer.fudd@bunny.com",
                Street = "123 Sesame St.",
                State = "NY"
            };
            normalizer.Modify(updatedItem);

            updatedItem.Email.Should().Be("bugs@bunny.com");
        }

        [TestMethod]
        public void ShouldNormalizeDirtyStreet()
        {
            var normalizer = OrderNormalizer.Default;
            var updatedItem = new FraudRadar.Order
            {
                Email = "bugs+elmer.fudd@bunny.com",
                Street = "123 Sesame st.",
                State = "NY"
            };
            normalizer.Modify(updatedItem);

            updatedItem.Street.Should().Be("123 Sesame street");
        }

        [TestMethod]
        public void ShouldNormalizeDirtyRoad()
        {
            var normalizer = OrderNormalizer.Default;
            var updatedItem = new FraudRadar.Order
            {
                Email = "bugs+elmer.fudd@bunny.com",
                Street = "123 Sesame rd.",
                State = "NY"
            };
            normalizer.Modify(updatedItem);

            updatedItem.Street.Should().Be("123 Sesame road");
        }
    }
}
