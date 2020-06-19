using FluentAssertions;
using Galaxy.Railway;
using System.Threading.Tasks;
using Xunit;

namespace Galaxy_Railway.Tests
{
    public class Optional_Tests
    {
        [Fact]
        public void Should_be_optional_has_value()
        {
            var result = string.Empty.ToOptional();

            result.Should().BeOfType<Optional<string>>();
            result.HasValue.Should().BeTrue();
        }

        [Fact]
        public void Should_be_optional_has_not_value()
        {
            string fake = null;

            var result = fake.ToOptional();

            result.Should().BeOfType<Optional<string>>();
            result.HasValue.Should().BeFalse();
        }
        [Fact]
        public async Task Should_be_optional_async()
        {
            var result = await Task.FromResult(string.Empty).ToOptionalAsync();

            result.Should().BeOfType<Optional<string>>();
            result.HasValue.Should().BeTrue();
        }
    }
}
