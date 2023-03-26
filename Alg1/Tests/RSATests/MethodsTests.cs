using System;
using NUnit.Framework;
using Alg_lab_1;
using NUnit.Framework.Constraints;

namespace Alg_lab_1.Tests
{
    [TestFixture]
    public class MethodsTests
    {
        [Test]
        public void MethodsTest()
        {
            RSACoder rsa = new RSACoder(7, 11);

            Assert.IsFalse(rsa.is_prime(4));
            Assert.IsTrue(rsa.is_prime(3));
            Assert.IsTrue(rsa.is_coprime(3, 7));
            Assert.IsFalse(rsa.is_coprime(4, 8));
        }


    }
}