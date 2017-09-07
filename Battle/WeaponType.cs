using System;
using System.Collections.Generic;
using System.Text;

namespace Battle
{
    public abstract class WeaponType
    {
        public static WeaponType NewType(int weapon) {
            WeaponType weaponType;
            switch (weapon)
            {
                
                case Weapon.BAREFIST:
                    weaponType = new BareFist();
                    break;
                case Weapon.AXE:
                    weaponType = new Axe();
                    break;
                case Weapon.SWORD:
                    weaponType = new Sword();
                    break;
                case Weapon.SPEAR:
                    weaponType = new Spear();
                    break;
                default:
                    throw new Exception("Invalid Weapon");

            }
            return weaponType;
        }

        public abstract int Damage { get; }
    }

    class BareFist : WeaponType {
        public override int Damage
        {
            get { return 1; }
        }
    }
    class Axe : WeaponType {
        public override int Damage
        {
            get { return 3; }
        }
    }
    class Sword : WeaponType {
        public override int Damage
        {
            get { return 2; }
        }
    }
    class Spear : WeaponType {
        public override int Damage
        {
            get { return 2; }
        }
    }
}
