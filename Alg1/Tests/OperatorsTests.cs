using NUnit.Framework;
using Alg_lab_1;

namespace Alg_lab_1.Tests
{
    [TestFixture]
    public class OperatorsTest
    {
        private BinaryInteger a, b, c, a1;
        [SetUp]
        public void SetUp()
        {
            a = new BinaryInteger(0);
            b = new BinaryInteger(15);
            c = new BinaryInteger(-20);
            a1 = new BinaryInteger(0);
        }

        [Test]
        public void AdditionTests()
        {
            Assert.AreEqual(new BinaryInteger(0).Value, (a + a).Value);
            Assert.AreEqual(new BinaryInteger(15).Value, (a + b).Value);
            Assert.AreEqual(new BinaryInteger(-20).Value, (a + c).Value);
            Assert.AreEqual(new BinaryInteger(-5).Value, (b + c).Value);
            Assert.AreEqual(new BinaryInteger(10).Value, (b + b + c + a).Value);
        }

        [Test]
        public void SubstractionTests()
        {
            Assert.AreEqual(new BinaryInteger(0).Value, (a - a).Value);
            Assert.AreEqual(new BinaryInteger(-15).Value, (a - b).Value);
            //Assert.AreEqual(new BinaryInteger(20).Value,(a-c).Value); 
            Assert.AreEqual(new BinaryInteger(35).Value, (b - c).Value);
        }

        [Test]
        public void MultiplicationTests()
        {
            Assert.AreEqual(new BinaryInteger(0).Value, (a * a).Value);
            Assert.AreEqual(new BinaryInteger(15).Value, (b * new BinaryInteger(1)).Value);
            Assert.AreEqual(new BinaryInteger(30).Value, (b * new BinaryInteger(2)).Value);

        }
        [Test]
        public void DivisionTests()
        {
            var z = new BinaryInteger(1);
            var x = new BinaryInteger(10);
            var c = new BinaryInteger(20);
            var q = new BinaryInteger(4);
            Assert.AreEqual(new BinaryInteger(1).Value, (z / z).Value);
            Assert.AreEqual(new BinaryInteger(5).Value, (c / q).Value);
            Assert.AreEqual(new BinaryInteger(2).Value, (c / x).Value);
            Assert.AreEqual(new BinaryInteger(5).Value, (c / q).Value);

            Assert.AreEqual(new BinaryInteger(2).Value, (x % q).Value);
            Assert.AreEqual(new BinaryInteger(0).Value, (c % q).Value);
        }

        [Test]
        public void ReversionTests()
        {
            Assert.AreEqual(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, BinaryInteger.Reverse(new BinaryInteger(0)).Value);
            Assert.AreEqual(new int[] { 1, 1, 1, 0, 1, 1, 0, 0 }, BinaryInteger.Reverse(new BinaryInteger(20)).Value);
            Assert.AreEqual(new int[] { 0, 0, 0, 1, 0, 1, 0, 0 }, BinaryInteger.Reverse(new BinaryInteger(new int[] { 1, 1, 1, 0, 1, 1, 0, 0 })).Value);
        }

        [Test]
        public void CompareTests()
        {
            Assert.IsTrue(a == a1);
            Assert.IsFalse(a == b);
            Assert.IsFalse(a != a1);
            Assert.IsTrue(a != b);

            Assert.IsTrue(b > a);
            Assert.IsTrue(b > c);
            Assert.IsFalse(a > b);
            Assert.IsFalse(a > a1);

            Assert.IsFalse(b < a);
            Assert.IsFalse(b < c);
            Assert.IsTrue(a < b);
            Assert.IsFalse(a < a1);
        }


    }
}