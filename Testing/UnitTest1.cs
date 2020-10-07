using NUnit.Framework;
using System;
using CodingChallengeAsp.Models;

namespace Testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Test test = new Test();

            int result = test.Number(11);

            int expected = 21;

            Assert.AreEqual(expected, result);

        }
    }
}