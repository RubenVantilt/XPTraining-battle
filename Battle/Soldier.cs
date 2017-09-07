using System;

namespace Battle
{
    public class Soldier
    {
        public Soldier(string name)
        {
            ValidateNameisNotBlank(name);
            Name = name;
            Weapon = new Weapon();
        }

        private void ValidateNameisNotBlank(string name)
        {
            if (IsBlank(name))
            {
                throw new ArgumentException("name can not be blank");
            }
        }

        private bool IsBlank(string name) => string.IsNullOrEmpty(name?.Trim());
        
        public string Name { get; }
        public Weapon Weapon { get;  set; }
    }
}