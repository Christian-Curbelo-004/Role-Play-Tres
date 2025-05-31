using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Dwarf: ICharacter
{
    private int health = 90;

    private List<IItem> items = new List<IItem>();

    public Dwarf(string name)
    {
        this.Name = name;

        this.AddItem(new Axe());
        this.AddItem(new Helmet());
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
}
