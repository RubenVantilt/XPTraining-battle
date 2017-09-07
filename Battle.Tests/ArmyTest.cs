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
    }
}
