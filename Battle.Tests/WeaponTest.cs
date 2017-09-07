using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class WeaponTest
    {
        [Theory]
        [InlineData(Weapon.BAREFIST, 1)]
        [InlineData(Weapon.AXE, 3)]
        [InlineData(Weapon.SWORD, 2)]
        [InlineData(Weapon.SPEAR, 2)]
        [InlineData(Weapon.TRIDENT, 6)]
        public void Weapon_whenCreated_thenShouldHaveCorrectAmountOfDamage(int weaponType, int expectedAmountOfDamage)
        {
            Weapon weapon = new Weapon(weaponType);

            weapon.AmountOfDamage.Should().Be(expectedAmountOfDamage);
        }
    }
}
