using System;
using System.Collections.Generic;
using System.Linq;

namespace Ucu.Poo.RoleplayGame;

public class Heroes : ICharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int VictoryPoints { get; set; }
    public int EarnedPoints { get; set; }
    public int AttackValue { get; set; }
    private List<IItem> items = new List<IItem>();
    
    public Heroes(string name, int health, int victoryPoints, int attackValue, int earnedPoints)
    {
        Name = name;
        Health = health;
        VictoryPoints = victoryPoints;
        EarnedPoints = EarnedPoints;
        AttackValue = attackValue;
    }

    public void AddItem(IItem item)
    {
        items.Add(item);

    }

    public void RemoveItem(IItem item)
    {
        items.Remove(item);
    }

    public void Cure(int Health)
    {
        this.Health += Health;
    }

    

    public int DeffenseValue
    {
        get  {return items.Sum(item => item.DeffenseValue);}
    }

    public int Attack(ICharacter target)
    {
        if (this.Health <= 0 || target.Health <= 0)
        {
            Console.WriteLine("No puede atacar si esta muerto o si el objetivo ya murio");
            return 0;
        }

        int damage = this.AttackValue - target.DeffenseValue;
        if (damage > 0)
        {
            target.Health -= damage;
            if (target.Health <= 0 && target is Enemies enemy)
            {
                VictoryPoints = 0;
                VictoryPoints ++;
                
                Console.WriteLine($"Heroes won {VictoryPoints} points.  ");
            }
        }

        return VictoryPoints;
    }

    public void ReceiveAttack(int damage)
    {
       this.Health -= damage;
    }
}
    

        