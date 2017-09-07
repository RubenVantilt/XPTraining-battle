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

        [Fact]
        public void Soldier_isDefaultEquippedWithWeapon_ThenDefaultIsBareFist()
        {
            Soldier soldier = new Soldier("soldier name");

            soldier.Weapon.Should().NotBeNull();

            soldier.Weapon.WeaponType.Should().BeOfType<BareFist>();
        }

        [Fact]
        public void Soldier_isEquippedWithAxe_ThenWeaponIsAxe()
        {
            Soldier soldier = new Soldier("soldier name", Weapon.AXE);

            soldier.Weapon.Should().NotBeNull();

            soldier.Weapon.WeaponType.Should().BeOfType<Axe>();
        }

        [Fact]
        public void GivenASoldier_WhenTwoSoldiersWithUnequalWeaponDamageFight_TheStrongestOneWins()
        {
            Soldier attacker = new Soldier("Attacker", 0);
            Soldier attackedOne = new Soldier("Attacked one", 3);

            Soldier winner = attacker.Fight(attackedOne);

            winner.Should().Be(attackedOne);
        }

        [Fact]
        public void GivenASoldier_WhenTwoSoldiersWithEqualWeaponDamageFight_TheAttackerWins()
        {
            Soldier attacker = new Soldier("Attacker", 0);
            Soldier attackedOne = new Soldier("Attacked one", 0);

            Soldier winner = attacker.Fight(attackedOne);

            winner.Should().Be(attacker);
        }
    }
}