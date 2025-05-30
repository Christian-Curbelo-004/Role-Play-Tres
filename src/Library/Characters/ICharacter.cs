namespace Ucu.Poo.RoleplayGame;

public interface ICharacter
{
    string Name { get; set; }

     int Health { get; set; }

    int AttackValue { get; }

    int DefenseValue { get; }

    void AddItem(IItem item);

    void RemoveItem(IItem item);

    void Cure(int health);

    
    void ReceiveAttack(int damage);
}
