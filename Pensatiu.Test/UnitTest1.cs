using System;
using Xunit;

namespace Pensatiu.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int x = 5;
            Assert.Equal(5, x);
        }
    }
}
