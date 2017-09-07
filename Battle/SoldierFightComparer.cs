using System;
using System.Collections.Generic;
using System.Text;

namespace Battle
{
    public class SoldierFightComparer
    {
        public static Soldier GetWinner(Soldier attacker, Soldier opponent)
        {
            if (GetWeaponType(attacker) == GetWeaponType(opponent))
            {
                return attacker;
            }

            var damages = CalculateDamages(attacker, opponent);

            if (damages.AttackerDamage >= damages.OpponentDamage)
                return attacker;

            return opponent;
        }

        private static Damages CalculateDamages(Soldier attacker, Soldier opponent)
        {
            var damages = new Damages();

            damages.AttackerDamage = attacker.Weapon.AmountOfDamage;
            damages.OpponentDamage = opponent.Weapon.AmountOfDamage;

            if (GetWeaponType(attacker) == typeof(MagicPotion))
            {
                damages.AttackerDamage = CalculateMagicPotionDamage(damages.OpponentDamage);
            }
            else if (GetWeaponType(opponent) == typeof(MagicPotion))
            {
                damages.OpponentDamage = CalculateMagicPotionDamage(damages.AttackerDamage);
            }

            return damages;
        }

        private static Type GetWeaponType(Soldier soldier)
        {
            return soldier.Weapon.WeaponType.GetType();
        }

        private static int CalculateMagicPotionDamage(int opponentDamage)
        {
            return opponentDamage % 2 == 0 ? 10 : 0;
        }
    }
}
