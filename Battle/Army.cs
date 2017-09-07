using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle
{
    public class Army

    {
        public Army(IHeadQuarters headQuarters)
        {
            HeadQuarters = headQuarters;
            Soldiers = new List<Soldier>();
        }

        public void Enroll(Soldier soldier)
        {
            Soldiers.Add(soldier);
            var id = HeadQuarters.ReportEnlistment(soldier.Name);
            soldier.Id = id;
        }

        private IHeadQuarters HeadQuarters { get; set; }
        public List<Soldier> Soldiers { get; set; }

        public Soldier Frontman => Soldiers.FirstOrDefault();

        public Army Attack(Army secondArmy)
        {
            while (ThereIsAFrontman(Frontman) && ThereIsAFrontman(secondArmy.Frontman))
            {
                var winningFrontman = Frontman.Fight(secondArmy.Frontman);
                if (!isOurFrontman(winningFrontman))
                {
                    this.RemoveDeadSoldier(Frontman);
                }
                else
                {
                    secondArmy.RemoveDeadSoldier(secondArmy.Frontman);
                }
            }
            var winningArmy = CheckWinningTeam(secondArmy);

            HeadQuarters.ReportVictory(winningArmy.Soldiers.Count);
            return winningArmy;
        }

        private Army CheckWinningTeam( Army secondArmy)
        {
            if( Soldiers.Count > secondArmy.Soldiers.Count)
            {
                return this;
            }
            else
            {
                return secondArmy;
            }
        }

        private bool ThereIsAFrontman(Soldier frontman)
        {
            return frontman != null;
        }

        private bool isOurFrontman(Soldier soldier)
        {
            return Frontman == soldier;
        }

        public void RemoveDeadSoldier(Soldier deadSoldier)
        {
            HeadQuarters.ReportCasualty(deadSoldier.Id);
            Soldiers.Remove(deadSoldier);
        }
    }
}