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
    }
}