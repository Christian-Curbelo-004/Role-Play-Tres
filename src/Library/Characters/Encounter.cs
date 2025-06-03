using System;
using System.Collections.Generic;
using Ucu.Poo.RoleplayGame;

public class Encounter
{
    public static void Main(string[] args)
    {
        // Asegúrate de que Character implemente ICharacter y tenga un constructor compatible
        var heroe1 = new Character("Aragorn", 10, 4, 1);
        var heroe2 = new Character("Legolas", 8, 5, 2);

        var enemigo1 = new Character("Orco", 5, 3, 0);
        var enemigo2 = new Character("Troll", 7, 4, 1);

        var heroes = new List<ICharacter> { heroe1, heroe2 };
        var enemigos = new List<ICharacter> { enemigo1, enemigo2 };

        // Diccionario para los puntos de victoria de cada personaje
        var puntos = new Dictionary<ICharacter, int>();
        foreach (var h in heroes) puntos[h] = 0;

        while (HayVivos(heroes) && HayVivos(enemigos))
        {
            // Enemigos atacan primero
            foreach (var enemigo in enemigos)
            {
                if (enemigo.Health <= 0) continue;
                var objetivo = BuscarVivo(heroes);
                if (objetivo != null)
                {
                    objetivo.ReceiveAttack(enemigo.AttackValue);
                    Console.WriteLine($"{enemigo.Name} ataca a {objetivo.Name}. Vida de {objetivo.Name}: {objetivo.Health}");
                }
            }

            // Héroes vivos atacan a todos los enemigos vivos
            foreach (var heroe in heroes)
            {
                if (heroe.Health <= 0) continue;
                foreach (var enemigo in enemigos)
                {
                    if (enemigo.Health > 0)
                    {
                        enemigo.ReceiveAttack(heroe.AttackValue);
                        Console.WriteLine($"{heroe.Name} ataca a {enemigo.Name}. Vida de {enemigo.Name}: {enemigo.Health}");
                        if (enemigo.Health <= 0)
                        {
                            // Gana 3 puntos por cada enemigo vencido
                            puntos[heroe] += 3;
                            Console.WriteLine($"{heroe.Name} ganó 3 puntos y ahora tiene {puntos[heroe]} puntos.");
                            // Si llega a 5 o más puntos, se cura 5 puntos de vida
                            if (puntos[heroe] >= 5)
                            {
                                heroe.Cure(5);
                                Console.WriteLine($"{heroe.Name} se curó y ahora tiene {heroe.Health} de vida.");
                            }
                        }
                    }
                }
            }
        }

        if (HayVivos(heroes))
            Console.WriteLine("¡Los héroes ganaron!");
        else
            Console.WriteLine("¡Los enemigos ganaron!");
    }

    static bool HayVivos(List<ICharacter> lista)
    {
        foreach (var p in lista)
            if (p.Health > 0)
                return true;
        return false;
    }

    static ICharacter BuscarVivo(List<ICharacter> lista)
    {
        foreach (var p in lista)
            if (p.Health > 0)
                return p;
        return null;
    }
}