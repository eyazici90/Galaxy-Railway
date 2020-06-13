using FluentAssertions;
using Galaxy.Railway;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
using Xunit;

namespace Galaxy_Railway.Tests
{
    public class Unit_Tests
    {
        [Fact]
        public async Task Should_be_equal_to_each_other()
        {
            var unit1 = Unit.Value;
            var unit2 = await Unit.Task;

            unit1.Should().BeEquivalentTo(unit2);
            (unit1 == unit2).Should().BeTrue();
            (unit1 != unit2).Should().BeFalse();
        }

        [Fact]
        public void Should_be_equitable()
        {
            var dictionary = new Dictionary<Unit, string>
            {
                {new Unit(), "value"},
            };
            dictionary[default].Should().Be("value");
        }

        [Fact]
        public void Should_tostring()
        {
            var unit = Unit.Value;
            unit.ToString().Should().Be("()");
        }

        [Fact]
        public void Should_compareto_as_zero()
        {
            var unit1 = new Unit();
            var unit2 = new Unit();

            unit1.CompareTo(unit2).Should().Be(0);
        }

        public static object[][] ValueData()
        {
            return new[]
            {
                new object[] {new object(), false},
                new object[] {"", false},
                new object[] {"()", false},
                new object[] {null, false},
                new object[] {new Uri("https://www.google.com"), false},
                new object[] {new Unit(), true},
                new object[] {Unit.Value, true},
                new object[] {Unit.Task.Result, true},
                new object[] {default(Unit), true},
            };
        }

        [Theory]
        [MemberData(nameof(ValueData))]
        public void Should_be_equal(object value, bool isEqual)
        {
            var unit1 = Unit.Value;

            if (isEqual)
                unit1.Equals(value).Should().BeTrue();
            else
                unit1.Equals(value).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(ValueData))]
        public void Should_compareto_value_as_zero(object value, bool _)
        {
            var unit1 = new Unit();
            ((IComparable)unit1).CompareTo(value).Should().Be(0);
        }
    }
}
