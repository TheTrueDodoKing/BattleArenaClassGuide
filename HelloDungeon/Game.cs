using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        struct Monster
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;
        }
        
        float Attack(Monster attacker, Monster defender)
        {
            float totalDamage = attacker.Damage - defender.Defense;

            return defender.Health - totalDamage;
        }

        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name: " + monster.Name);
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Damage: " + monster.Damage);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Stamina: " + monster.Stamina);
        }

        //float Heal(Monster healing, float healAmount)
        //{
            
        //    healAmount = healing.Health + 15;

        //    return healAmount;
            
        //}
        void Fight(Monster monster1, Monster monster2)
        {
            Console.WriteLine(monster1.Name + "punches" + monster2.Name + "!");
            monster2.Health = Attack(monster1, monster2);
            Console.ReadKey(true);

            PrintStats(monster1);
            PrintStats(monster2);
            
            Console.WriteLine(monster2 + "punches" + monster1 + "!");
            monster1.Health = Attack(monster2, monster1);
            Console.ReadKey(true);

            PrintStats(monster1);
            PrintStats(monster2);
        }

        public void Run()
        {
            Monster JoePable;
            JoePable.Name = "JoePable";
            JoePable.Health = 100f;
            JoePable.Damage = 2f;
            JoePable.Defense = 3f;
            JoePable.Stamina = 3f;

            Monster John_DarkSouls;
            John_DarkSouls.Name = "John Darksouls";
            John_DarkSouls.Health = 500f;
            John_DarkSouls.Damage = 50f;
            John_DarkSouls.Defense = 15.5f;
            John_DarkSouls.Stamina = 80f;

            Monster LucyJill;
            LucyJill.Name = "Lucy Jill Dirtbag Biden";
            LucyJill.Health = 52f;
            LucyJill.Damage = 37f;
            LucyJill.Defense = 5f;
            LucyJill.Stamina = 32f;

            Monster Tree_Lobster;
            Tree_Lobster.Name = "Tree Lobster";
            Tree_Lobster.Health = 1000f;
            Tree_Lobster.Damage = 10f;
            Tree_Lobster.Defense = 40f;
            Tree_Lobster.Stamina = 100.5f;

            Fight(JoePable, LucyJill);

            Console.Clear();
            
            Fight(JoePable, LucyJill);

            Console.Clear(); 
            
            Fight(JoePable, LucyJill);

            Console.Clear();

        }

    }
}
