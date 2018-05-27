using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class EmailNormalizerTests
    {
        [TestMethod]
        public void ShouldNormalizeCleanEmail()
        {
            var normalizer = new EmailNormalizer(null);
            var updatedItem = new FraudRadar.Order
            {
                Email = "bugs@bunny.com",
            };
            normalizer.Modify(updatedItem);

            updatedItem.Email.Should().Be("bugs@bunny.com");
        }

        [TestMethod]
        public void ShouldNormalizeDirtyEmail()
        {
            var normalizer = new EmailNormalizer(null);
            var updatedItem = new FraudRadar.Order
            {
                Email = "bugs+elmer.fudd@bunny.com",
            };
            normalizer.Modify(updatedItem);

            updatedItem.Email.Should().Be("bugs@bunny.com");
        }
    }
}
