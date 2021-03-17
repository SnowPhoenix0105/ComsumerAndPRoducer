using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Test
{
    [TestClass]
    public class ParserTest
    {
        public static readonly IntegerItem ONE = IntegerItem.ONE;
        public static readonly IntegerItem ZERO = IntegerItem.ZERO;
        public static readonly IntegerItem TWO = IntegerItem.TWO;

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestNullExpression()
        {
            Parser.Parse(null);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("   ")]
        [ExpectedException(typeof(ExpressionTooShortException))]
        public void TestEmptyExpression(string origin)
        {
            Parser.Parse(origin);
        }

        [DataTestMethod]
        [DataRow("1+")]
        [DataRow("2*")]
        [DataRow("1-")]
        [DataRow("1++1")]
        [DataRow("-1-1")]
        [DataRow("1+-1")]
        [DataRow("1*-1")]
        [DataRow("1+ -1")]
        [DataRow("1* -1")]
        [DataRow("1* (-1)")]
        [ExpectedException(typeof(SyntaxException))]
        public void TestSyntaxException(string origin)
        {
            Parser.Parse(origin);
        }

        [TestMethod]
        public void TestIntegerParse()
        {
            Assert.AreEqual((IntegerItem) 123, Parser.Parse("123"));
            Assert.AreEqual((IntegerItem) 0, Parser.Parse("0"));
            Assert.AreEqual((IntegerItem) 1, Parser.Parse("1"));
            Assert.AreEqual((IntegerItem) int.MaxValue, Parser.Parse(int.MaxValue.ToString()));
        }

        [TestMethod]
        public void TestAddParse()
        {
            Assert.AreEqual(new AddItem(ONE, ONE), Parser.Parse("1+1"));
            Assert.AreEqual(new AddItem(ONE, ONE), Parser.Parse(" 1+1"));
            Assert.AreEqual(new AddItem(ONE, ONE), Parser.Parse("1 +1"));
            Assert.AreEqual(new AddItem(ONE, ONE), Parser.Parse("1 + 1"));
            Assert.AreEqual(new AddItem(ONE, ONE), Parser.Parse("1 + 1 "));
            Assert.AreEqual(new AddItem(ONE, ONE), Parser.Parse("1+1 "));
            Assert.AreEqual(new AddItem(ONE, ONE), Parser.Parse("1+ 1 "));
            Assert.AreEqual(new AddItem(TWO, ONE), Parser.Parse("2+ 1"));
        }

        [TestMethod]
        public void TestSubParse()
        {
            Assert.AreEqual(new SubItem(ONE, ONE), Parser.Parse("1-1"));
            Assert.AreEqual(new SubItem(ONE, ONE), Parser.Parse(" 1-1"));
            Assert.AreEqual(new SubItem(ONE, ONE), Parser.Parse("1 -1"));
            Assert.AreEqual(new SubItem(ONE, ONE), Parser.Parse("1 - 1"));
            Assert.AreEqual(new SubItem(ONE, ONE), Parser.Parse("1 - 1 "));
            Assert.AreEqual(new SubItem(ONE, ONE), Parser.Parse("1-1 "));
            Assert.AreEqual(new SubItem(ONE, ONE), Parser.Parse("1- 1 "));
            Assert.AreEqual(new SubItem(TWO, ONE), Parser.Parse("2- 1"));
        }

        [TestMethod]
        public void TestMulParse()
        {
            Assert.AreEqual(new MulItem(ONE, ONE), Parser.Parse("1*1"));
            Assert.AreEqual(new MulItem(ONE, ONE), Parser.Parse("1 *1"));
            Assert.AreEqual(new MulItem(ONE, ONE), Parser.Parse("1 * 1"));
            Assert.AreEqual(new MulItem(ONE, ONE), Parser.Parse("1 * 1 "));
            Assert.AreEqual(new MulItem(ONE, ONE), Parser.Parse("1*1 "));
            Assert.AreEqual(new MulItem(ONE, ONE), Parser.Parse("1* 1 "));
            Assert.AreEqual(new MulItem(TWO, ONE), Parser.Parse("2* 1"));
        }

        [TestMethod]
        public void TestComplexExpression()
        {
            Assert.AreEqual(new AddItem(ZERO, new MulItem(ONE, TWO)), Parser.Parse("0+1*2"));
            Assert.AreEqual(new AddItem(ZERO, new MulItem(ONE, TWO)), Parser.Parse("0+  1*2"));
            Assert.AreEqual(new AddItem(ZERO, new MulItem(ONE, TWO)), Parser.Parse("0+1*  2"));
            Assert.AreEqual(new AddItem(ZERO, new MulItem(ONE, TWO)), Parser.Parse("0+1*2  "));
            Assert.AreEqual(new AddItem(ZERO, new MulItem(ONE, TWO)), Parser.Parse("0+1* 2"));
            Assert.AreEqual(new AddItem(ZERO, new MulItem(ONE, TWO)), Parser.Parse("0+ 1*2"));
            Assert.AreEqual(new AddItem(ZERO, new MulItem(ONE, TWO)), Parser.Parse(" 0 +1*2"));
            Assert.AreEqual(new AddItem(ZERO, new MulItem(ONE, TWO)), Parser.Parse("0 + 1*2"));
        }

    }
}