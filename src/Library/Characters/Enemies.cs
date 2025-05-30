using System.ComponentModel.Design;

namespace Ucu.Poo.RoleplayGame;

public class Enemies : ICharacter
{
    public string Name { get; set; }
    public int Health { get;  set; }
    public int VictoryPoints { get; private set; }

    private List<IItem> items = new List<IItem>();

    public Enemies(string name, int health, int victoryPoints)
    {
        this.Name = name;
        this.Health = health;
        this.VictoryPoints = victoryPoints;
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
        this.Health -= health;
    }

    public int AttackValue
    {
        get { return items.Sum(item => item.AttackValue); }
    }

    public int DefenseValue
    {
        get { return items.Sum(item => item.DeffenseValue); }
    }



    public void Attack(ICharacter target)
    {

        if (this.Health <= 0 || target.Health <= 0)
        {
            Console.WriteLine("No puede atacar si esta muerto o si el objetivo ya murio"); 
        }

        int damage = this.AttackValue - target.DefenseValue;
        if (damage > 0)
        {
            target.Health -= damage;

            if (target.Health <= 0 && target is Enemies enemy)
            {
                this.VictoryPoints += enemy.VictoryPoints;
            }
        }
    }

    public void ReceiveAttack(int damage)
    {
        this.Health -= damage; 
    }
}

    
   // Podriamos agregar un contador de VP a los enemigos
   
    

   










    

    
    
  
    
