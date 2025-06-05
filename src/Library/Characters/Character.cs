using System;
using System.Collections.Generic;

namespace Ucu.Poo.RoleplayGame
{
    public class Character : ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }

        private List<IItem> items;
        
        public int AttackValue { get; set; }

        public Character(string name, int health, List<IItem> items, int attackvalue )
        {
            Name = name;
            Health = health;
            this.items = items ?? new List<IItem>();
            AttackValue = attackvalue;
        }

        

        public int DeffenseValue
        {
            get
            {
                int total = 0;
                foreach (var item in items)
                {
                    total += item.DeffenseValue;
                }
                return total;
            }
        }

        public void AddItem(IItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            items.Remove(item);
        }

        public void Cure(int health)
        {
            Health += health;
        }

        public void ReceiveAttack(int damage)
        {
            int effectiveDamage = damage - DeffenseValue;
            if (effectiveDamage > 0)
            {
                Health -= effectiveDamage;
            }
        }
    }
}