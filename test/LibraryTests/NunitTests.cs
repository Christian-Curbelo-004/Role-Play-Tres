using NUnit.Framework;
using System.Collections.Generic;
using Ucu.Poo.RoleplayGame;

namespace Ucu.Poo.RoleplayGame.Tests
{
    [TestFixture]
    public class EncounterTest
    {
        [Test]
        public void HeroesVsEnemies()
        {
            var heroe1 = new Character("Aragorn", 100, new List<IItem>(), 20);
            var heroe2 = new Character("Legolas", 8, new List<IItem>(), 12);
            var heroes = new List<ICharacter> { heroe1, heroe2 };
    
            var enemy1 = new Character("Orco", 5, new List<IItem>(), 34);
            var enemy2 = new Character("Troll", 12, new List<IItem>(), 17);
            var enemies = new List<ICharacter> { enemy1, enemy2 };
    
            var points = new Dictionary<ICharacter, int>();
            foreach (var h in heroes) points[h] = 0;

            string winner = Encounter.SimulateEncounter(heroes, enemies, points);

            Assert.That(winner, Is.EqualTo("heroes").Or.EqualTo("enemies"));
            
            
        }
    }
}