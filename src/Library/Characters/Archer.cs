using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Archer: ICharacter
{
    public int health = 100;

    private Inventory inventory = new Inventory();

    public Archer(string name)
    {
        this.Name = name;

        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }
    public string Name { get; set; }
    public int AttackValue => inventory.AttackValue;
    public int DefenseValue => inventory.DeffenseValue;

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

    public void Cure(int health)
    {
        this.Health = 100;
    }

    public void AddItem(IItem item)
    {
        inventory.AddItem(item);
    }

    public void RemoveItem(IItem item)
    {
        inventory.RemoveItem(item);
    }
}