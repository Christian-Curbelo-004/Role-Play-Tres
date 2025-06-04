using System;
using System.Xml.Linq;

namespace Ucu.Poo.RoleplayGame.Program;

class Program
{
    public static void Main(string[] args)
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

        gimli.Cure(123);
        Console.WriteLine($"Someone cured Gimli. Gimli now has ❤️ {gimli.Health}");

        Heroes heroes = new Heroes("Aragorn", 100, 1, 100, 1);
        Enemies enemies = new Enemies("Troll", 30, 0, 10);


        Console.WriteLine($"\n{heroes.Name} attacks {enemies.Name} with ⚔️ {heroes.AttackValue}");
        enemies.ReceiveAttack(heroes.AttackValue);

        int health = heroes.Health;
        int health2 = heroes.Health;

        Console.WriteLine($"{enemies.Name} now has ❤️ {enemies.Health}");

        if (enemies.Health > 0)
        {
            Console.WriteLine($"{enemies.Name} counter-attacks with ⚔️ {enemies.AttackValue}");
            heroes.ReceiveAttack(enemies.AttackValue);
        }
        else
        {
            Console.WriteLine($"{heroes.Name} won {heroes.VictoryPoints} points");
        }
    }
}
