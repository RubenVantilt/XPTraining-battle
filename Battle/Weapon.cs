using System;
using System.Collections.Generic;
using System.Text;

namespace Battle
{
    public class Weapon
    {
        private WeaponType weaponType;
        public Weapon()
        {
            weaponType = new BareFist();
        }

        public WeaponType WeaponType { get { return weaponType; } }
    }
}
