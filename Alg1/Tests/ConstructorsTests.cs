using System;
using NUnit.Framework;
using Alg_lab_1;
using NUnit.Framework.Constraints;

namespace Alg_lab_1.Tests
{
    [TestFixture]
    public class ConstructorTest
    {
        [Test]
        public void ConstructorTests()
        {
            Assert.AreEqual(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, (new BinaryInteger(0).Value));
            Assert.AreEqual(new int[] { 0, 0, 0, 0, 1, 0, 0, 0 }, (new BinaryInteger(8).Value));
            Assert.AreEqual(new int[] { 1, 1, 1, 1, 1, 0, 0, 0 }, (new BinaryInteger(-8).Value));
        }


    }
}