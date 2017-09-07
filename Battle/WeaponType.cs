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
                case Weapon.TWO_HANDED_SWORD:
                    weaponType = new TwoHandedSword();
                    break;
                case Weapon.BROAD_AXE:
                    weaponType = new BroadAxe();
                    break;
                case Weapon.TRIDENT:
                    weaponType = new Trident();
                    break;
                case Weapon.MAGIC_POTION:
                    weaponType = new MagicPotion();
                    break;
                default:
                    throw new Exception("Invalid Weapon");

            }
            return weaponType;
        }

        public abstract int Damage { get; set; }
    }

    class Trident : WeaponType
    {
        private static readonly Spear Spear = new Spear();

        public override int Damage { get; set; } = 3 * Spear.Damage;
    }

    class BroadAxe : WeaponType
    {
        private static readonly Axe Axe = new Axe();

        public override int Damage { get; set; } = 2 + Axe.Damage;
    }

    class TwoHandedSword : WeaponType
    {
        public override int Damage { get; set; } = 5;
    }

    class BareFist : WeaponType
    {
        public override int Damage { get; set; } = 1;
    }
    class Axe : WeaponType {
        public override int Damage { get; set; } = 3;
    }
    class Sword : WeaponType {
        public override int Damage { get; set; } = 2;
    }
    class Spear : WeaponType {
        public override int Damage { get; set; } = 2;
    }

    class MagicPotion : WeaponType
    {
        public override int Damage { get; set; }
    }
}
