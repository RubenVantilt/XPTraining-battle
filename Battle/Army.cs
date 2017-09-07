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

        public Soldier Frontman => Soldiers.First();

        public Army Attack(Army secondArmy)
        {
            var winningFrontman = Frontman.Fight(secondArmy.Frontman);
            if (! isOurFrontman(winningFrontman))
            {
                this.RemoveDeadSoldier(Frontman);
                return secondArmy;
            }
            else
            {
                secondArmy.RemoveDeadSoldier(secondArmy.Frontman);
                return this;
            }

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