using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        struct Character
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;
            public Weapon CurrentWeapon;
        }

        struct Weapon
        {
            public string Name;
            public float Damage;
            public float Defense;
            public float Stamina;
        }

        bool gameOver;
        
        int currentScene = 0;

        Character JoePable;
        Character John_DarkSouls;
        Character LucyJill;
        Character Tree_Lobster;
        
        Character[] Enemies;
        int currentEnemyIndex = 0;

        Character Player;
        float Attack(Character attacker, Character defender)
        {
            float totalDamage = attacker.Damage + attacker.CurrentWeapon.Damage - defender.Defense - defender.CurrentWeapon.Defense;

            return defender.Health - totalDamage;
        }

        void PrintStats(Character monster)
        {
            Console.WriteLine("Name: " + monster.Name);
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Damage: " + monster.Damage);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Stamina: " + monster.Stamina);
            Console.WriteLine("Weapon: " + monster.CurrentWeapon.Name);
        }

        //float Heal(Monster healing, float healAmount)
        //{

        //    healAmount = healing.Health + 15;

        //    return healAmount;

        //}
        void Fight(ref Character monster2)
        {
            PrintStats(Player);
            PrintStats(monster2);

            bool isDefending = false;
            string battleChoice = GetInput("Choose an action", "Attack", "Defend", "Run", "Forfeit");

            if (battleChoice == "1")
            {
                monster2.Health = 0;
                Console.WriteLine("You used " + Player.CurrentWeapon.Name + " ");

                if (monster2.Health <= 0)
                {
                    return;
                }
            }
            else if (battleChoice == "2")
            {
                Player.Defense *= 5;
                Console.WriteLine("You block");
                isDefending = true;
            }
            else if (battleChoice == "3")
            {
                Console.WriteLine("You fled the battle");
                currentScene = 2;
            }
            else if (battleChoice == "4")
            {
                gameOver = true;
            }
            Console.WriteLine(monster2.Name + " uses " + monster2.CurrentWeapon.Name + " on " + Player.Name);
            Player.Health = Attack(monster2, Player);
            Console.ReadKey(true);

            if (isDefending == true)
            {
                Player.Defense /= 5;
            }
        }
        string GetInput(string prompt, string option1, string option2, string option3, string option4)
        {
            string playerChoice = "";

            Console.WriteLine(prompt);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.WriteLine("4. " + option4);

            playerChoice = Console.ReadLine();

            return playerChoice;
        }
        void CharacterSelectionScene()
        {
            string characterChoice = GetInput("Choose Your Character", JoePable.Name, John_DarkSouls.Name, LucyJill.Name, Tree_Lobster.Name);
            
                if (characterChoice == "1")
                {
                    Player = JoePable;
                }
                else if (characterChoice == "2")
                {
                    Player = John_DarkSouls;                   
                }
                else if (characterChoice == "3")
                {
                    Player = LucyJill;                 
                }
                else if (characterChoice == "4")
                {
                    Player = Tree_Lobster;                 
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Press any ket to continue");
                    Console.ReadKey(true);
                    return;
                }
            PrintStats(Player);
            Console.ReadKey(true);
            Console.Clear();
            currentScene = 1;
        }
        void BattleScene()
        {
            Fight(ref Enemies[currentEnemyIndex]);
            
            Console.Clear();

            if (Player.Health <= 0 || Enemies[currentEnemyIndex].Health <= 0)
            {
                currentScene = 2;
            }
        }
        void WinReusultsScene()
        {
            if (Player.Health > 0 && Enemies[currentEnemyIndex].Health <= 0)
            {
                Console.WriteLine("The Winner is: " + Player.Name);
                currentScene = 1;
                currentEnemyIndex++;

                if (currentEnemyIndex >= Enemies.Length)
                {
                    gameOver = true;
                }
            }
            else if (Enemies[currentEnemyIndex].Health > 0 && Player.Health <= 0)
            {
                Console.WriteLine("The Winner is: " + Enemies[currentEnemyIndex].Name);
                currentScene = 3;
            }
            Console.ReadKey(true);
            Console.Clear();
            
        }
            void GetArray(int[] numbers)
        {
            int sum = 0;
            for ( int i = 0; i < numbers.Length; i++ )
            {
                sum = sum + numbers[i];
                
            }
            Console.WriteLine(sum);
        }
        void BigRay(int[] numbers)
        {
            int biggestNumber = numbers[0];

            for(int i = 0; 1 < numbers.Length; i++ )
            {
                if (numbers[i] > biggestNumber)
                {
                    biggestNumber = numbers[i];
                }
            }
            Console.WriteLine(biggestNumber);
        }


        void EndGameScene()
        {
            string playerChoice = GetInput("You Died. Play Again?", "Yes", "No", "", "");
                
                if (playerChoice == "1")
                {
                    currentScene = 0;
                }
                else if (playerChoice == "2")
                {
                    gameOver = true;
                }
        }
        void Start()
        {
            Weapon Pitchfork;
            Pitchfork.Name = "Pitchfork";
            Pitchfork.Damage = 5f;
            Pitchfork.Defense = 0f;
            Pitchfork.Stamina = 4f;

            Weapon Solar_Eclipse;
            Solar_Eclipse.Name = "The Solar Eclipse";
            Solar_Eclipse.Damage = 20f;
            Solar_Eclipse.Defense = 2f;
            Solar_Eclipse.Stamina = 0f;

            Weapon Cracked_Mirror;
            Cracked_Mirror.Name = "Cracked Mirror";
            Cracked_Mirror.Damage = 2f;
            Cracked_Mirror.Defense = 3f;
            Cracked_Mirror.Stamina = 8f;

            Weapon Earthen_Claws;
            Earthen_Claws.Name = "Earthen Claws";
            Earthen_Claws.Damage = 8f;
            Earthen_Claws.Defense = 4f;
            Earthen_Claws.Stamina = 0f;

            Weapon Default;
            Default.Name = "Default";
            Default.Damage = 0f;
            Default.Defense = 0f;
            Default.Stamina = 0f;
            
            JoePable.Name = "JoePable";
            JoePable.Health = 100f;
            JoePable.Damage = 2f;
            JoePable.Defense = 3f;
            JoePable.Stamina = 3f;
            JoePable.CurrentWeapon = Pitchfork;

            
            John_DarkSouls.Name = "John Darksouls";
            John_DarkSouls.Health = 500f;
            John_DarkSouls.Damage = 50f;
            John_DarkSouls.Defense = 15.5f;
            John_DarkSouls.Stamina = 80f;
            John_DarkSouls.CurrentWeapon = Solar_Eclipse;

            
            LucyJill.Name = "Lucy Jill Dirtbag Biden";
            LucyJill.Health = 52f;
            LucyJill.Damage = 37f;
            LucyJill.Defense = 5f;
            LucyJill.Stamina = 32f;
            LucyJill.CurrentWeapon = Cracked_Mirror;

            
            Tree_Lobster.Name = "Tree Lobster";
            Tree_Lobster.Health = 1000f;
            Tree_Lobster.Damage = 10f;
            Tree_Lobster.Defense = 40f;
            Tree_Lobster.Stamina = 100.5f;
            Tree_Lobster.CurrentWeapon = Earthen_Claws;
            //                              0           1               2           3
            Enemies = new Character[4] { JoePable, John_DarkSouls, LucyJill, Tree_Lobster };

            Player.Name = "";
            Player.Health = 0f;
            Player.Damage = 0f;
            Player.Defense = 0f;
            Player.Stamina = 0f;
            Player.CurrentWeapon = Default;
        }
        void Update()
        {
            if (currentScene == 0)
            {
                CharacterSelectionScene();
            }
            else if (currentScene == 1)
            {
                BattleScene();
            }
            else if (currentScene == 2)
            {
                WinReusultsScene();
            }
            else if(currentScene == 3)
            {
                EndGameScene();
            }
        }
        void End()
        {
            Console.WriteLine("Thanks for playing");
        }
        public void Run()
        {

            Start();

            while (gameOver == false)
            {
                Update();
            }

            End();
        }
        
    }
}
