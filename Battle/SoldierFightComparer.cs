using System;
using System.Collections.Generic;
using System.Text;

namespace Battle
{
    public class SoldierFightComparer
    {
        public static Soldier GetWinner(Soldier attacker, Soldier opponent)
        {
            int opponentDamage = 0;
            int attackerDamage = 0;

            if (attacker.Weapon.WeaponType.GetType() == opponent.Weapon.WeaponType.GetType())
            {
                return attacker;
            }

            if (attacker.Weapon.WeaponType.GetType() == typeof(MagicPotion))
            {
                opponentDamage = opponent.Weapon.AmountOfDamage;
                attackerDamage = CalculateMagicPotionDamage(opponentDamage);
            }
            else if (opponent.Weapon.WeaponType.GetType() == typeof(MagicPotion))
            {
                attackerDamage = attacker.Weapon.AmountOfDamage;
                opponentDamage = CalculateMagicPotionDamage(attackerDamage);
            }
            else
            {
                attackerDamage = attacker.Weapon.AmountOfDamage;
                opponentDamage = opponent.Weapon.AmountOfDamage;
            }

            if (attackerDamage >= opponentDamage)
                return attacker;

            return opponent;
        }

        private static int CalculateMagicPotionDamage(int opponentDamage)
        {
            return opponentDamage % 2 == 0 ? 10 : 0;
        }
    }
}
