using System;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class ArmyTest
    {
        [Fact]
        public void GivenASoldier_HeCanBeEnrolledInAnArmy()
        {
            Soldier soldier = new Soldier("Soldier name");
            Army army = new Army();

            army.Enroll(soldier);
            army.Soldiers.Should().Contain(soldier);
        }

        [Fact]
        public void GivenASoldier_WhenIsFirstSoldier_ThenIsFrontMan()
        {
            Soldier frontManSoldier = new Soldier("Front man");
            Soldier soldier = new Soldier("Soldier");
            Army army = new Army();

            army.Enroll(frontManSoldier);
            army.Enroll(soldier);

            army.Frontman.Should().Be(frontManSoldier);
        }

        [Fact]
        public void GivenTwoArmiesWithOneSoldier_WhenFightingWar_StrongestFrontManWins()
        {
            var firstArmy = new Army();
            var secondArmy = new Army();

            var frontmanFirstArmy = new Soldier("Front man first army", Weapon.BAREFIST);
            var frontmanSecondArmy = new Soldier("Front man second army", Weapon.SPEAR);

            firstArmy.Enroll(frontmanFirstArmy);
            secondArmy.Enroll(frontmanSecondArmy);

            var winningArmy = firstArmy.Attack(secondArmy);

            winningArmy.Should().Be(secondArmy);
        }

        [Fact]
        public void GivenTwoArmiesWithOneSoldier_WhenFightingWar_LoserDiesAndIsRemovedFromArmy()
        {
            var firstArmy = new Army();
            var secondArmy = new Army();

            var frontmanFirstArmy = new Soldier("Front man first army", Weapon.BAREFIST);
            var frontmanSecondArmy = new Soldier("Front man second army", Weapon.SPEAR);

            firstArmy.Enroll(frontmanFirstArmy);
            secondArmy.Enroll(frontmanSecondArmy);

            firstArmy.Attack(secondArmy);

            firstArmy.Soldiers.Should().BeEmpty();
        }

        [Fact]
        public void GivenTwoArmiesWithMoreThanOneSoldier_WhenFightingWar_StrongestArmyWinsBecauseSameWeapons()
        {
            var firstArmy = new Army();
            var secondArmy = new Army();

            var frontmanFirstArmy = new Soldier("Front man first army", Weapon.SPEAR);
            var secondManFirstArmy = new Soldier("Second man first army", Weapon.BAREFIST);
            var thirdManFirstArmy = new Soldier("Third man first army", Weapon.BAREFIST);

            firstArmy.Enroll(frontmanFirstArmy);
            firstArmy.Enroll(secondManFirstArmy);
            firstArmy.Enroll(thirdManFirstArmy);

            var frontmanSecondArmy = new Soldier("Front man second army", Weapon.BAREFIST);
            var secondManSecondArmy = new Soldier("Second man second army", Weapon.SPEAR);
            var thirdManSecondArmy = new Soldier("Third man second army", Weapon.SPEAR);

           

            secondArmy.Enroll(frontmanSecondArmy);
            secondArmy.Enroll(secondManSecondArmy);
            secondArmy.Enroll(thirdManSecondArmy);

            var winningArmy = firstArmy.Attack(secondArmy);

            winningArmy.Should().Be(firstArmy);
        }

        [Fact]
        public void GivenTwoArmiesWithMoreThanOneSoldier_WhenFightingWar_StrongestArmyWinsBecauseStrongerWeapons()
        {
            var firstArmy = new Army();
            var secondArmy = new Army();

            var frontmanFirstArmy = new Soldier("Front man first army", Weapon.AXE);
            var secondManFirstArmy = new Soldier("Second man first army", Weapon.AXE);
            var thirdManFirstArmy = new Soldier("Third man first army", Weapon.AXE);

            firstArmy.Enroll(frontmanFirstArmy);
            firstArmy.Enroll(secondManFirstArmy);
            firstArmy.Enroll(thirdManFirstArmy);

            var frontmanSecondArmy = new Soldier("Front man second army", Weapon.BAREFIST);
            var secondManSecondArmy = new Soldier("Second man second army", Weapon.SPEAR);
            var thirdManSecondArmy = new Soldier("Third man second army", Weapon.SPEAR);



            secondArmy.Enroll(frontmanSecondArmy);
            secondArmy.Enroll(secondManSecondArmy);
            secondArmy.Enroll(thirdManSecondArmy);

            var winningArmy = firstArmy.Attack(secondArmy);

            winningArmy.Should().Be(firstArmy);
        }
    }
}
