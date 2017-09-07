using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle
{
    public class Army

    {
        public Army()
        {
            Soldiers = new List<Soldier>();
        }

        public void Enroll(Soldier soldier)
        {
            Soldiers.Add(soldier);
        }

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

            return CheckWinningTeam(secondArmy);
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

        private void RemoveDeadSoldier(Soldier deadSoldier)
        {
            Soldiers.Remove(deadSoldier);
        }
    }
}