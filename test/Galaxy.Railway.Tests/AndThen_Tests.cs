using FluentAssertions;
using Galaxy.Railway;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Galaxy_Railway.Tests
{
    public class AndThen_Tests
    {

        [Fact]
        public void Should_be_composed()
        {
            Func<int, int> func1 = number => number + 1;

            Func<int, int> func2 = number => number += 2;


            func1(1).AndThen(func2).Should().Be(4);
        }

        [Fact]
        public async Task Should_be_composed_when_async()
        {
            Func<int, Task<int>> func1 = number => Task.FromResult(number + 1);

            Func<int, Task<int>> func2 = number => Task.FromResult(number += 2);

            var result = await func1(1).AndThenAsync(func2);

            result.Should().Be(4);
        }
    }
}
