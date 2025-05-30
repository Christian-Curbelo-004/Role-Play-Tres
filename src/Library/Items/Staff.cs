namespace Ucu.Poo.RoleplayGame;

public class Staff: IAttackItem, IDeffenseItem
{
    public int AttackValue
    {
        get
        {
            return 100;
        }
    }

    public int DeffenseValue
    {
        get
        {
            return 100;
        }
    }
}
