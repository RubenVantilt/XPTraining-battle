using System;
using System.Collections.Generic;
using System.Text;

namespace Battle
{
    public class Weapon
    {
        private WeaponType weaponType;
        public Weapon(int weapon)
        {

            weaponType = WeaponType.NewType(weapon);
            AmountOfDamage = weaponType.Damage;
        }

        public WeaponType WeaponType { get { return weaponType; } }
        public int AmountOfDamage { get; }

        public const int BAREFIST = 0;
        public const int AXE = 1;
        public const int SWORD = 2;
        public const int SPEAR = 3;

    }
}
