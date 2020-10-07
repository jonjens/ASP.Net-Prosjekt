using System;
using Xunit;
using CodingChallengeAsp.Models;

namespace XUnitTestMath
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            Test test = new Test();

            int result = test.Math(11);

            int expectation = 21;

            Assert.Equal(expectation, result);

        }
    }
}
