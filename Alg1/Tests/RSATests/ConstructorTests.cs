using System;
using NUnit.Framework;
using Alg_lab_1;
using NUnit.Framework.Constraints;

namespace Alg_lab_1.Tests
{
    [TestFixture]
    public class ConstructorsTest
    {
        [Test]
        public void ConstructorsTests()
        {
            RSACoder rsa = new RSACoder(7, 11);

            Assert.AreEqual(7, rsa.p);
            Assert.AreEqual(11, rsa.q);
            Assert.AreEqual(77, rsa.n);
            Assert.AreEqual((7-1)*(11-1), rsa.phi);
            Assert.AreEqual(77, rsa.open_key.Item2);
        }


    }
}