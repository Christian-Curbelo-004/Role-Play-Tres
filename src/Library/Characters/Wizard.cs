using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Wizard: IMagicCharacter
{
    private int health = 80;

    private List<IItem> items = new List<IItem>();

    private List<IMagicalItem> magicalItems = new List<IMagicalItem>();

    public Wizard(string name)
    {
        this.Name = name;

        this.AddItem(new Staff());
    }

    public string Name { get; set; }

    public int AttackValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IAttackItem)
                {
                    value += (item as IAttackItem).AttackValue;
                }
            }
            foreach (IMagicalItem item in this.magicalItems)
            {
                if (item is IMagicalAttackItem)
                {
                    value += (item as IMagicalAttackItem).AttackValue;
                }
            }
            return value;
        }
    }

    public int DeffenseValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IDeffenseItem)
                {
                    value += (item as IDeffenseItem).DeffenseValue;
                }
            }
            foreach (IMagicalItem item in this.magicalItems)
            {
                if (item is IMagicalDefenseItem)
                {
                    value += (item as IMagicalDefenseItem).DefenseValue;
                }
            }
            return value;
        }
    }

     public int Health
    {
        get
        {
            return this.health;
        }
         set
        {
            this.health = value < 0 ? 0 : value;
        }
    }

    public void ReceiveAttack(int power)
    {
        if (this.DeffenseValue < power)
        {
            this.Health -= power - this.DeffenseValue;
        }
    }

    public void Cure(int health)
    {
        this.Health = 100;
    }

    public void AddItem(IItem item)
    {
        this.items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        this.items.Remove(item);
    }

    public void AddItem(IMagicalItem item)
    {
        this.magicalItems.Add(item);
    }

    public void RemoveItem(IMagicalItem item)
    {
        this.magicalItems.Remove(item);
    }

}
