using FluentAssertions;
using Galaxy.Railway;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Galaxy_Railway.Tests
{
    public class Throws_Tests
    {
        [Fact]
        public void Should_throw_when_true()
        {
            var city = string.Empty;

            Func<string> func = () => city.ThrowsIf(c => c.IsNullOrEmpty(), new ArgumentNullException());

            func.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Should_throw_when_true_async()
        {
            var city = Task.FromResult(string.Empty);

            Func<Task<string>> func = async () => await city.ThrowsIfAsync(c => c.IsNullOrEmpty(), new ArgumentNullException());

            func.Should().Throw<ArgumentNullException>();
        }
    }
}
