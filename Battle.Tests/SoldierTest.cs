using System;
using Xunit;
using FluentAssertions;

namespace Battle
{
    public class SoldierTest
    {

        [Fact]
        public void construction_ASoldierMustHaveAName()
        {
            Soldier soldier = new Soldier("soldier name");

            soldier.Name.Should().Be("soldier name");
        }

        [Theory]
        [InlineData("")]
        [InlineData("        ")]
        [InlineData(null)] 
        public void construction_ASoldierMustHaveAName_CannotBeBlank(string name)
            => ((Action)(() => new Soldier(name))).ShouldThrow<ArgumentException>();
    }
}