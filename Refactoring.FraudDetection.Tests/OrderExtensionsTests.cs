using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class OrderExtensionsTests
    {
        [TestMethod]
        public void ShouldCallLogicForEachItem()
        {
            var orders = new FraudRadar.Order[]
            {
                new FraudRadar.Order(),
                new FraudRadar.Order(),
                new FraudRadar.Order()
            };
            var logic = new Mock<IOrderModifier>();          
                
            orders.Apply(logic.Object).ToArray();

            logic.Verify(o => o.Modify(It.IsAny<FraudRadar.Order>()),
                Times.Exactly(3));
        }
    }
}
