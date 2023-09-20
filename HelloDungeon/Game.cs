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
        }
    class Game
    {
        bool gameOver;
        
        int currentScene = 0;

        Character JoePable;
        Character John_DarkSouls;
        Character LucyJill;
        Character Tree_Lobster;
        Character Brittle_OldMan;
        
        Character[] Enemies;
        int currentEnemyIndex = 0;

        Player PlayerCharacter;
        

        //float Heal(Monster healing, float healAmount)
        //{

        //    healAmount = healing.Health + 15;

        //    return healAmount;

        //}
        void Fight(ref Character monster2)
        {
            PlayerCharacter.PrintStats();
            monster2.PrintStats();

            bool isDefending = false;
            string battleChoice = PlayerCharacter.GetInput("Choose an action", "Attack", "Defend", "Forfeit");

            if (battleChoice == "1")
            {
                monster2.TakeDamage(PlayerCharacter.GetDamage());
                Console.WriteLine("You used " + PlayerCharacter.GetWeapon().Name + " ");

                if (monster2.GetHealth() <= 0)
                {
                    return;
                }
            }
            else if (battleChoice == "2")
            {
                PlayerCharacter.RaiseDefense();
                Console.WriteLine("You block");
                isDefending = true;
            }
            else if (battleChoice == "3")
            {
                gameOver = true;
            }
            Console.WriteLine(monster2.GetName() + " Strikers " + PlayerCharacter.GetName());
            PlayerCharacter.TakeDamage(monster2.GetDamage());
            Console.ReadKey(true);

            if (isDefending == true)
            {
                PlayerCharacter.ResetDefense();
            }
        }
        
        void CharacterSelectionScene()
        {
            PlayerCharacter = new Player();
            string characterChoice = PlayerCharacter.GetInput("Choose Your Character", JoePable.GetName(), John_DarkSouls.GetName(), LucyJill.GetName(), Tree_Lobster.GetName());
            

                if (characterChoice == "1")
                {
                    PlayerCharacter = new Player(JoePable.GetName(), JoePable.GetHealth(), JoePable.GetDamage(), JoePable.GetDefense(), JoePable.GetWeapon());
                }
                else if (characterChoice == "2")
                {
                    PlayerCharacter = new Player(John_DarkSouls.GetName(), John_DarkSouls.GetHealth(), John_DarkSouls.GetDamage(), John_DarkSouls.GetDefense(), John_DarkSouls.GetWeapon());
            }
                else if (characterChoice == "3")
                {
                    PlayerCharacter = new Player(LucyJill.GetName(), LucyJill.GetHealth(), LucyJill.GetDamage(), LucyJill.GetDefense(), LucyJill.GetWeapon());
            }
                else if (characterChoice == "4")
                {
                    PlayerCharacter = new Player(Tree_Lobster.GetName(), Tree_Lobster.GetHealth(), Tree_Lobster.GetDamage(), Tree_Lobster.GetDefense(), Tree_Lobster.GetWeapon());
            }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Press any ket to continue");
                    Console.ReadKey(true);
                    return;
                }
            PlayerCharacter.PrintStats();
            Console.ReadKey(true);
            Console.Clear();
            currentScene = 1;
        }
        void BattleScene()
        {
            Fight(ref Enemies[currentEnemyIndex]);
            
            Console.Clear();

            if (PlayerCharacter.GetHealth() <= 0 || Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                currentScene = 2;
            }
        }
        void WinReusultsScene()
        {
            if (PlayerCharacter.GetHealth() > 0 && Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                Console.WriteLine("The Winner is: " + PlayerCharacter.GetName());
                currentScene = 1;
                currentEnemyIndex++;

                if (currentEnemyIndex >= Enemies.Length)
                {
                    gameOver = true;
                }
            }
            else if (Enemies[currentEnemyIndex].GetHealth() > 0 && PlayerCharacter.GetHealth() <= 0)
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
            string playerChoice = PlayerCharacter.GetInput("You Died. Play Again?", "Yes", "No");
                
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

            Weapon Solar_Eclipse;
            Solar_Eclipse.Name = "The Solar Eclipse";
            Solar_Eclipse.Damage = 20f;
            Solar_Eclipse.Defense = 2f;

            Weapon Cracked_Mirror;
            Cracked_Mirror.Name = "Cracked Mirror";
            Cracked_Mirror.Damage = 2f;
            Cracked_Mirror.Defense = 3f;

            Weapon Earthen_Claws;
            Earthen_Claws.Name = "Earthen Claws";
            Earthen_Claws.Damage = 8f;
            Earthen_Claws.Defense = 4f;

            Weapon Fragile;
            Fragile.Name = "Fragile Bones";
            Fragile.Damage = 0f;
            Fragile.Defense = -1f;

            Weapon Default;
            Default.Name = "Default";
            Default.Damage = 0f;
            Default.Defense = 0f;

            JoePable = new Character("JoePable", 100f, 2f, 3f, Pitchfork);

            John_DarkSouls = new Character("John Darksouls", 500f, 50f, 15.5f, Solar_Eclipse);

            LucyJill = new Character("Lucy Jill Dirtbag Biden", 52f, 37f, 5f, Cracked_Mirror);

            Tree_Lobster = new Character("Tree Lobster", 500f, 10f, 40f, Earthen_Claws);

            Brittle_OldMan = new Character("Brittle Old Man", 1f, 1f, 1f, Fragile);
            
            //                              0           1               2           3
            Enemies = new Character[5] { JoePable, John_DarkSouls, LucyJill, Tree_Lobster, Brittle_OldMan};

            PlayerCharacter = new Player("", 0f, 0f, 0f, Default);
            
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
