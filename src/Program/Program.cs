using System;
using System.Xml.Linq;

namespace Ucu.Poo.RoleplayGame.Program;

class Program
{
    static void Main(string[] args)
    {
        SpellsBook book = new SpellsBook();
        book.AddSpell(new SpellOne());
        book.AddSpell(new SpellOne());
        
        Wizard gandalf = new Wizard("Gandalf");
        gandalf.AddItem(book);

        Dwarf gimli = new Dwarf("Gimli");

        Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
        Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

        gimli.ReceiveAttack(gandalf.AttackValue);

        Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

        gimli.Cure(10);
        Console.WriteLine($"Someone cured Gimli. Gimli now has ❤️ {gimli.Health}");
        
        Heroes aragorn = new Heroes("Aragorn", 100,  0, 20);
        Enemies troll = new Enemies("Troll", 30, 0);

        
        Console.WriteLine($"\n{aragorn.Name} attacks {troll.Name} with ⚔️ {aragorn.AttackValue}");
        troll.ReceiveAttack(aragorn.AttackValue);
        Console.WriteLine($"{troll.Name} now has ❤️ {troll.Health}");

        Console.WriteLine($"{troll.Name} counter-attacks with ⚔️ {troll.AttackValue}");
        aragorn.ReceiveAttack(troll.AttackValue);
        Console.WriteLine($"{aragorn.Name} now has ❤️ {aragorn.Health}");
    }
}
