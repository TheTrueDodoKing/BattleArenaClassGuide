using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    struct Weapon
        {
            public string Name;
            public float Damage;
            public float Defense;
            public float Stamina;
        }
    class Game
    {
        bool gameOver;
        
        int currentScene = 0;

        Character JoePable;
        Character John_DarkSouls;
        Character LucyJill;
        Character Tree_Lobster;
        
        Character[] Enemies;
        int currentEnemyIndex = 0;

        Character Player;
        

        //float Heal(Monster healing, float healAmount)
        //{

        //    healAmount = healing.Health + 15;

        //    return healAmount;

        //}
        void Fight(ref Character monster2)
        {
            Player.PrintStats();
            monster2.PrintStats();

            bool isDefending = false;
            string battleChoice = GetInput("Choose an action", "Attack", "Defend", "Run", "Forfeit");

            if (battleChoice == "1")
            {
                monster2.TakeDamage(Player.GetDamage());
                Console.WriteLine("You used " + Player.GetWeapon().Name + " ");

                if (monster2.GetHealth() <= 0)
                {
                    return;
                }
            }
            else if (battleChoice == "2")
            {
                Player.RaiseDefense();
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
            Console.WriteLine(monster2.GetName() + " Strikers " + Player.GetName();
            Player.TakeDamage(monster2.GetDamage());
            Console.ReadKey(true);

            if (isDefending == true)
            {
                Player.ResetDefense();
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
            string characterChoice = GetInput("Choose Your Character", JoePable.GetName(), John_DarkSouls.GetName(), LucyJill.GetName(), Tree_Lobster.GetName());
            
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
            Player.PrintStats();
            Console.ReadKey(true);
            Console.Clear();
            currentScene = 1;
        }
        void BattleScene()
        {
            Fight(ref Enemies[currentEnemyIndex]);
            
            Console.Clear();

            if (Player.GetHealth() <= 0 || Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                currentScene = 2;
            }
        }
        void WinReusultsScene()
        {
            if (Player.GetHealth() > 0 && Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                Console.WriteLine("The Winner is: " + Player.GetName());
                currentScene = 1;
                currentEnemyIndex++;

                if (currentEnemyIndex >= Enemies.Length)
                {
                    gameOver = true;
                }
            }
            else if (Enemies[currentEnemyIndex].GetHealth() > 0 && Player.GetHealth() <= 0)
            {
                Console.WriteLine("The Winner is: " + Enemies[currentEnemyIndex].GetName());
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

            JoePable = new Character("JoePable", 100f, 2f, 3f, 3f, Pitchfork);

            John_DarkSouls = new Character("John Darksouls", 500f, 50f, 15.5f, Solar_Eclipse);

            LucyJill = new Character("Lucy Jill Dirtbag Biden", 52f, 37f, 5f, Cracked_Mirror);

            Tree_Lobster = new Character("Tree Lobster", 1000f, 10f, 40f, Earthen_Claws);
            
            //                              0           1               2           3
            Enemies = new Character[4] { JoePable, John_DarkSouls, LucyJill, Tree_Lobster };

            Player = new Character("", 0f, 0f, 0f, Default);
            
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
