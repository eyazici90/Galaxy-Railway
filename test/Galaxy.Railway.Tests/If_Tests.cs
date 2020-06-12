using FluentAssertions;
using Galaxy.Railway;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Galaxy_Railway.Tests
{
    public class If_Tests
    {
        [Fact]
        public void Should_be_executed_when_true()
        {
            var str = string.Empty;

            var result = str.If(str.IsNullOrEmpty(), _ => "Amsterdam");

            result.Should().NotBeNullOrEmpty().And.Be("Amsterdam");
        }

        [Fact]
        public async Task Should_be_executed_when_true_async()
        {
            var asyncStr = Task.FromResult(string.Empty);

            var result = await asyncStr.IfAsync(await asyncStr == string.Empty, async _ => "Amsterdam");

            result.Should().NotBeNullOrEmpty().And.Be("Amsterdam");
        }
    }
}
