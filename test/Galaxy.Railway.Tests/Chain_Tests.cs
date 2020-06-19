using FluentAssertions;
using Galaxy.Railway;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Galaxy_Railway.Tests
{
    public class Chain_Tests
    {
        [Fact]
        public void Should_be_chained()
        {
            var city = "Amsterdam";

            var result = city.ToOptional()
                .ThrowsIf(optional => !optional.HasValue, new ArgumentNullException())
                .Map(result => result.Value)
                .AndThen(c => c.ToLower());

            result.Should().Be(city.ToLower());
        }

        [Fact]
        public void Should_throw()
        {
            string city = null;

            Action act = () => city.ToOptional()
                .ThrowsIf(optional => !optional.HasValue, new ArgumentNullException())
                .Map(result => result.Value)
                .AndThen(c => c.ToLower());

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Should_be_chained_async()
        {
            var city = Task.FromResult("Amsterdam");

            var result = await city.ToOptionalAsync()
                .ThrowsIfAsync(optional => !optional.HasValue, new ArgumentNullException())
                .MapAsync(result => result.Value)
                .AndThenAsync(c => c.ToLower());

            result.Should().Be((await city).ToLower());
        }

        [Fact]
        public void Should_throw_async()
        {
            var city = Task.FromResult<string>(null);

            Func<Task> act = async () => await city.ToOptionalAsync()
                .ThrowsIfAsync(optional => !optional.HasValue, new ArgumentNullException())
                .MapAsync(result => result.Value)
                .AndThenAsync(c => c.ToLower());

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
