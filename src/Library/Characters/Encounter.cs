using System;
using System.Collections.Generic;
using Ucu.Poo.RoleplayGame;

public class Encounter 
{
    public static void Main(string[] args)
    {
        // Nombre, vida e items
        var heroe1 = new Character("Aragorn", 100, new List<IItem>(), 20);
        var heroe2 = new Character("Legolas", 8, new List<IItem>(), 12);

        var enemie1 = new Character("Orco", 5, new List<IItem>(), 34);
        var enemie2 = new Character("Troll", 12, new List<IItem>(),17);

        var heroes = new List<ICharacter> { heroe1, heroe2 };
        var enemies = new List<ICharacter> { enemie1, enemie2};

        // PV sobre los personajes (con diccionario)
        var points = new Dictionary<ICharacter, int>();
        foreach (var h in heroes) points[h] = 0;

        while (HayVivos(heroes) && HayVivos(enemies))
        {
            // Enemigos atacan primero
            foreach (var enemie in enemies)
            {
                if (enemie.Health <= 0) continue;
                var target = BuscarVivo(heroes);
                if (target != null)
                {
                    target.ReceiveAttack(enemie.AttackValue);
                    Console.WriteLine($"{enemie.Name} attacks {target.Name}. Life of {target.Name}: {target.Health}");
                }
            }

            // Los heroes  atacan a los enemigos
            foreach (var heroe in heroes)
            {
                if (heroe.Health <= 0) continue;
                foreach (var enemie in enemies)
                {
                    if (enemie.Health > 0)
                    {
                        enemie.ReceiveAttack(heroe.AttackValue);
                        Console.WriteLine($"{heroe.Name} attacks  {enemie.Name}. Life of {enemie.Name}: {enemie.Health}");
                        if (enemie.Health <= 0)
                        {
                            // El heroe se quedo los tres puntos del enemigo derrotado
                            points[heroe] += 3;
                            Console.WriteLine($"{heroe.Name} won 3 points and now has {points[heroe]} points.");
                            
                            if (points[heroe] >= 5)
                            {
                                heroe.Cure(100);
                                Console.WriteLine($"{heroe.Name} he was cured and now has{heroe.Health} of life");
                            }
                        }
                    }
                }
            }
        }
        
        if (HayVivos(heroes))
            Console.WriteLine("¡Los heroes ganaron");
        else
            Console.WriteLine("¡Los enemigos ganaron");
    }

    static bool HayVivos(List<ICharacter> list)
    {
        foreach (var p in list)
            if (p.Health > 0)
                return true;
        return false;
    }

    static ICharacter BuscarVivo(List<ICharacter> list)
    {
        foreach (var p in list)
            if (p.Health > 0)
                return p;
        return null;
    }
}