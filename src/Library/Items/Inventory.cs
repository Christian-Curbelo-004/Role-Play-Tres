namespace Ucu.Poo.RoleplayGame;

public class Inventory
{
    private List<IItem> items = new List<IItem>();

    public void AddItem(IItem item)
    {
        this.items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        this.items.Remove(item);
    }

    public int AttackValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IAttackItem attackItem)
                    value += attackItem.AttackValue;
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
                if (item is IDefenseItem defenseItem)
                    value += defenseItem.DefenseValue;
            }

            return value;
        }
    }
}

