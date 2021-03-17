using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SimpleCalculator.Test
{
    [TestClass]
    public class IItemTest
    {
        public static readonly IntegerItem ZERO = new IntegerItem(0);
        public static readonly IntegerItem ONE = new IntegerItem(1);
        public static readonly IntegerItem TWO = new IntegerItem(2);

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(-1,1)]
        [DataRow(-1,0)]
        [DataRow(int.MaxValue, int.MaxValue)]
        [DataRow(int.MinValue, int.MinValue)]
        [DataRow(int.MaxValue, int.MinValue)]
        public void TestIntegerItemValues(int val1, int val2)
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
        public void TestAddItemValues(int val1, int val2)
        {
            var item = new AddItem(new IntegerItem(val1), new IntegerItem(val2));
            Assert.AreEqual(val1 + val2, item.Value);
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
        public void TestSubItemValues(int val1, int val2)
        {
            var item = new SubItem(new IntegerItem(val1), new IntegerItem(val2));
            Assert.AreEqual(val1 - val2, item.Value);
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
        public void TestMulItemValues(int val1, int val2)
        {
            var item = new MulItem(new IntegerItem(val1), new IntegerItem(val2));
            Assert.AreEqual(val1 * val2, item.Value);
        }

        [TestMethod]
        public void TestIntegerItemEquals()
        {
            Assert.IsTrue(ONE.Equals(ONE));
            Assert.IsTrue(ONE.Equals(new IntegerItem(1)));
            Assert.IsFalse(ONE.Equals(TWO));
            Assert.IsFalse(ONE.Equals(null));
            Assert.IsFalse(ONE.Equals(new AddItem(ZERO, ONE)));
        }

        [TestMethod]
        public void TestIntegerItemExplicit()
        {
            Assert.IsTrue(ONE.Equals((IntegerItem)1));
            Assert.IsFalse(ONE.Equals(1));
            Assert.IsTrue(((IntegerItem)1).Equals(ONE));
        }

        [TestMethod]
        public void TestIntegerConstant()
        {
            Assert.AreEqual(ZERO, IntegerItem.ZERO);
            Assert.AreEqual(ONE, IntegerItem.ONE);
            Assert.AreEqual(TWO, IntegerItem.TWO);
        }

        [TestMethod]
        public void TestAddItemEquals()
        {
            var item = new AddItem(ONE, ZERO);
            Assert.IsTrue(item.Equals(item));
            Assert.IsTrue(item.Equals(new AddItem(ONE, ZERO)));
            Assert.IsFalse(item.Equals(new AddItem(ZERO, ONE)));
            Assert.IsFalse(item.Equals(new AddItem(TWO, (IntegerItem)(-1))));
            Assert.IsFalse(item.Equals(null));
            Assert.IsFalse(item.Equals(new SubItem(ONE, ZERO)));
        }

        [TestMethod]
        public void TestSubItemEquals()
        {
            var item = new SubItem(ONE, ZERO);
            Assert.IsTrue(item.Equals(item));
            Assert.IsTrue(item.Equals(new SubItem(ONE, ZERO)));
            Assert.IsFalse(item.Equals(new SubItem(ZERO, ONE)));
            Assert.IsFalse(item.Equals(new SubItem(TWO, (IntegerItem)(-1))));
            Assert.IsFalse(item.Equals(null));
            Assert.IsFalse(item.Equals(new AddItem(ONE, ZERO)));
        }

        [TestMethod]
        public void TestMulItemEquals()
        {
            var item = new MulItem(ONE, TWO);
            Assert.IsTrue(item.Equals(item));
            Assert.IsTrue(item.Equals(new MulItem(ONE, TWO)));
            Assert.IsFalse(item.Equals(new MulItem(TWO, ONE)));
            Assert.IsFalse(item.Equals(new MulItem(TWO, (IntegerItem)(-1))));
            Assert.IsFalse(item.Equals(null));
            Assert.IsFalse(item.Equals(new AddItem(ONE, ZERO)));
        }

        [TestMethod]
        public void TestComplexExpression()
        {
            IItem item1 = new AddItem(ONE, TWO);
            Assert.AreEqual(3, item1.Value);

            IItem item2 = new MulItem(item1, TWO);
            Assert.AreEqual(6, item2.Value);
            Assert.IsTrue(item1.Equals(item1));
            Assert.IsTrue(item2.Equals(item2));
            Assert.IsFalse(item1.Equals(item2));

            IItem item3 = new AddItem(ONE, TWO);
            Assert.AreEqual(3, item1.Value);
            IItem item4 = new MulItem(item1, TWO);
            Assert.AreEqual(6, item2.Value);
            Assert.IsTrue(item1.Equals(item3));
            Assert.IsTrue(item2.Equals(item4));
            Assert.IsFalse(item1.Equals(item4));
            Assert.IsFalse(item2.Equals(item3));
            Assert.IsFalse(item3.Equals(item4));

            item3 = new MulItem(TWO, TWO);
            Assert.AreEqual(4, item3.Value);
            item4 = new AddItem(item3, TWO);
            Assert.AreEqual(6, item4.Value);
            Assert.IsFalse(item2.Equals(item4));
            Assert.AreEqual(item2.Value, item4.Value);
        }
    }
}
