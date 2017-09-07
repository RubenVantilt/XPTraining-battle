using System;
using System.Text;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Battle.Tests
{
    public class ArmyTest
    {
        private IHeadQuarters _iHeadQuarters;
        public ArmyTest()
        {
            _iHeadQuarters = Substitute.For<IHeadQuarters>();
        }

        [Fact]
        public void GivenASoldier_HeCanBeEnrolledInAnArmy()
        {
            Soldier soldier = new Soldier("Soldier name");
            Army army = new Army(_iHeadQuarters);

            army.Enroll(soldier);
            army.Soldiers.Should().Contain(soldier);
        }

        [Fact]
        public void GivenASoldier_WhenIsFirstSoldier_ThenIsFrontMan()
        {
            Soldier frontManSoldier = new Soldier("Front man");
            Soldier soldier = new Soldier("Soldier");
            Army army = new Army(_iHeadQuarters);

            army.Enroll(frontManSoldier);
            army.Enroll(soldier);

            army.Frontman.Should().Be(frontManSoldier);
        }

        [Fact]
        public void GivenTwoArmiesWithOneSoldier_WhenFightingWar_StrongestFrontManWins()
        {
            var firstArmy = new Army(_iHeadQuarters);
            var secondArmy = new Army(_iHeadQuarters);

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
            var firstArmy = new Army(_iHeadQuarters);
            var secondArmy = new Army(_iHeadQuarters);

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
            var firstArmy = new Army(_iHeadQuarters);
            var secondArmy = new Army(_iHeadQuarters);

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
            var firstArmy = new Army(_iHeadQuarters);
            var secondArmy = new Army(_iHeadQuarters);

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

        [Fact]
        public void GivenSoldier_WhenSoldierGetsEnlisted_ThisGetsReportedToHeadQuarters()
        {
            Soldier soldier = new Soldier("Soldier");
            Army army = new Army(_iHeadQuarters);
            army.Enroll(soldier);

            _iHeadQuarters.Received().ReportEnlistment("Soldier");
        }

        [Fact]
        public void GivenSoldier_WhenSoldierGetsEnlisted_SoldierGetsId()
        {
            Soldier soldier = new Soldier("Soldier");
            Army army = new Army(_iHeadQuarters);
            _iHeadQuarters.ReportEnlistment("Soldier").Returns(99);
            army.Enroll(soldier);

            soldier.Id.Should().Be(99);
        }
    }
}
