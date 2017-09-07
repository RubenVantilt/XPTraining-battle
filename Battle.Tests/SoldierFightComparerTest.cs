using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class SoldierFightComparerTest
    {
        [Theory]
        [InlineData(Weapon.MAGIC_POTION, Weapon.MAGIC_POTION, 1)]
        [InlineData(Weapon.MAGIC_POTION, Weapon.AXE, 2)]
        [InlineData(Weapon.MAGIC_POTION, Weapon.SPEAR, 1)]
        [InlineData(Weapon.AXE, Weapon.SPEAR, 1)]
        [InlineData(Weapon.BROAD_AXE, Weapon.BAREFIST, 1)]
        public void GetWinner_whenTwoSoldiersAreCompared_thenRightSoldierShouldWin(int weaponTypeAttacker,
            int weaponTypeOpponent, int expectedWinner)
        {
            Soldier attacker = new Soldier("attacker", weaponTypeAttacker);
            Soldier opponent = new Soldier("opponent", weaponTypeOpponent);

            Soldier winner = SoldierFightComparer.GetWinner(attacker, opponent);

            int winnerPosition = winner.Equals(attacker) ? 1 : 2;

            winnerPosition.Should().Be(expectedWinner);
        }
    }
}
