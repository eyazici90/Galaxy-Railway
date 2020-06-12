using FluentAssertions;
using Galaxy.Railway;
using System.Threading.Tasks;
using Xunit;

namespace Galaxy_Railway.Tests
{
    public class Map_Tests
    {
        [Fact]
        public void Should_be_mapped()
        {
            var city = "Amsterdam";

            var result = city.Map(c => c.ToLower());

            result.Should().Be(city.ToLower());
        }

        [Fact]
        public async Task Should_be_mapped_async()
        {
            var city = Task.FromResult("Amsterdam");

            var result = await city.MapAsync(c => c.ToLower());

            result.Should().Be((await city).ToLower());
        }
    }
}
