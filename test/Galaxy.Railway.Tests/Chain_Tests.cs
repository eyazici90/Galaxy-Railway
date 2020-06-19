using FluentAssertions;
using Galaxy.Railway;
using System;
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
    }
}
