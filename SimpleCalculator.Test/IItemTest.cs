using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;


namespace SimpleCalculator.Test
{
    [TestClass]
    public class IItemTest
    {
        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(-1,1)]
        [DataRow(-1,0)]
        [DataRow(int.MaxValue, int.MaxValue)]
        [DataRow(int.MinValue, int.MinValue)]
        [DataRow(int.MaxValue, int.MinValue)]
        public void TestIntegerItemEquals(int val1, int val2)
        {
            var integer1 = new IntegerItem(val1);
            var integer2 = new IntegerItem(val2);
            Assert.AreEqual(val1==val2, integer1.Equals(integer2));
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(-1,1)]
        [DataRow(-1,0)]
        [DataRow(int.MaxValue, int.MaxValue)]
        [DataRow(int.MinValue, int.MinValue)]
        [DataRow(int.MaxValue, int.MinValue)]
        public void TestAddItemEquals(int val1, int val2)
        {
            var item = new AddItem(new IntegerItem(val1), new IntegerItem(val2));
            Assert.AreEqual(val1 + val2, item.Value);
        }
    }
}
