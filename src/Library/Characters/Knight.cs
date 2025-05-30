using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Knight: ICharacter
{
    private int health = 100;

    private List<IItem> items = new List<IItem>();

    public Knight(string name)
    {
        this.Name = name;

        this.AddItem(new Sword());
        this.AddItem(new Armor());
        this.AddItem(new Shield());
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

    public int DefenseValue
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
        if (this.DefenseValue < power)
        {
            this.Health -= power - this.DefenseValue;
        }
    }

    public void Cure(int  health)
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
