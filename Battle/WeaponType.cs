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
    }

    class BareFist : WeaponType { }
    class Axe : WeaponType { }
    class Sword : WeaponType { }
    class Spear : WeaponType { }
}
