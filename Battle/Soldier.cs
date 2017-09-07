using System;

namespace Battle
{
    public class Soldier
    {
        public Soldier(string name, int weapon = 0)
        {
            ValidateNameisNotBlank(name);
            Name = name;
            Weapon = new Weapon(weapon);
        }

        public string Name { get; }
        public Weapon Weapon { get; set; }
        public int Id { get; set; }

        private void ValidateNameisNotBlank(string name)
        {
            if (IsBlank(name))
            {
                throw new ArgumentException("name can not be blank");
            }
        }

        private bool IsBlank(string name) => string.IsNullOrEmpty(name?.Trim());

        public Soldier Fight(Soldier attackedOne)
        {
            return SoldierFightComparer.GetWinner(this, attackedOne);
        }
    }
}