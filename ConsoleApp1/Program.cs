using System;
using System.Collections.Generic;

namespace PirateAdventure
{
    // Karakter sınıfı
    class Character
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public List<string> Inventory { get; set; }

        public Character(string name, int age)
        {
            Name = name;
            Age = age;
            Health = 100;
            AttackPower = 10;
            Inventory = new List<string>();
        }

        public void ShowStats()
        {
            Console.WriteLine($"\nAd: {Name}, Yaş: {Age}, Can: {Health}, Saldırı Gücü: {AttackPower}");
            Console.WriteLine("Envanter: " + string.Join(", ", Inventory));
        }

        public void Rest()
        {
            Console.WriteLine("Dinleniyorsunuz...");
            Health = 100;
        }

        public void Fight(Enemy enemy)
        {
            while (Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine("1. Saldır");
                Console.WriteLine("2. Kaç");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    enemy.Health -= AttackPower;
                    Console.WriteLine($"Düşmanın canı {enemy.Health} kaldı.");

                    if (enemy.Health > 0)
                    {
                        Health -= enemy.AttackPower;
                        Console.WriteLine($"Senin canın {Health} kaldı.");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Kaçıyorsunuz...");
                    break;
                }

                if (Health <= 0)
                {
                    Console.WriteLine("Öldünüz...");
                }
                else if (enemy.Health <= 0)
                {
                    Console.WriteLine("Düşmanı yendiniz!");
                }
            }
        }
    }

    // Düşman sınıfı
    class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public Enemy(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }
    }

    // Oyun sınıfı
    class Game
    {
        Character player;

        public void Start()
        {
            Console.WriteLine("Korsan Macerası'na Hoş Geldiniz!");

            Console.WriteLine("Adınızı girin:");
            string playerName = Console.ReadLine();

            Console.WriteLine("Yaşınızı girin:");
            int playerAge = int.Parse(Console.ReadLine());

            player = new Character(playerName, playerAge);

            Console.WriteLine($"Hoş geldin, {player.Name}. Macerana başlıyorsun!");

            while (player.Health > 0)
            {
                ShowMenu();
            }

            Console.WriteLine("Oyun bitti. Teşekkürler!");
        }

        void ShowMenu()
        {
            Console.WriteLine("\nNe yapmak istersiniz?");
            Console.WriteLine("1. İstatistikleri Göster");
            Console.WriteLine("2. Dinlen");
            Console.WriteLine("3. Maceraya Atıl");
            Console.WriteLine("4. Çıkış");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    player.ShowStats();
                    break;
                case "2":
                    player.Rest();
                    break;
                case "3":
                    StartAdventure();
                    break;
                case "4":
                    player.Health = 0;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }
        }

        void StartAdventure()
        {
            Console.WriteLine("\nHangi yöne gitmek istersiniz?");
            Console.WriteLine("1. Ormana");
            Console.WriteLine("2. Denize");
            Console.WriteLine("3. Mağaraya");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Encounter("Orman");
                    break;
                case "2":
                    Encounter("Deniz");
                    break;
                case "3":
                    Encounter("Mağara");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }
        }

        void Encounter(string location)
        {
            Console.WriteLine($"\n{location}'da bir düşmanla karşılaştınız!");

            Enemy enemy;
            if (location == "Orman")
            {
                enemy = new Enemy("Yabani Hayvan", 30, 5);
            }
            else if (location == "Deniz")
            {
                enemy = new Enemy("Deniz Canavarı", 40, 10);
            }
            else
            {
                enemy = new Enemy("Mağara Trolü", 50, 15);
            }

            player.Fight(enemy);
        }
    }

    // Ana program
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}
