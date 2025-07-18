﻿using System;
using System.Collections.Generic;
using System.Linq;


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

    public int AttackValue => items.Sum(items => items.AttackValue); 
    public int DeffenseValue => items.Sum(items => items.DeffenseValue);
}
    

    

