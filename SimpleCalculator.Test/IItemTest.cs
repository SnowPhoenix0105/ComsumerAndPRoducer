using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;


namespace SimpleCalculator.Test
{
    [TestClass]
    public class IItemTest
    {
        [DataTestMethod]
        public void TestIntegerItemEquals()
        {
            int val1 = 1;
            int val2 = 2;
            var integer1 = new IntegerItem(val1);
            var integer2 = new IntegerItem(val2);
            Assert.IsEqual(val1==val2, integer1 == integer2)
        }

    }
}
