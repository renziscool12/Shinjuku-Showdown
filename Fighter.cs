    using System.Threading;
    using System;
    namespace Practice;

    class Fighter
    {
        //fields
        private string Name { get; }
        public int Health { get; private set; }
        private int MaxHealth;
   
        private static readonly Random Rnd = new Random();
        
        //Resources
        private int rctUse = 3;
        private int maxWcsUse = 3;
        private int maxRed = 7;
        private int infinityLeft = 3;
        private bool hasWarnedRCT = false;
        public bool hasWarnedWCS = false;
        public bool CanUseRct => rctUse > 0;
            
        
        //gojo infinity
        private bool isInfinityActive = false;
        public bool HasInfinity => isInfinityActive && infinityLeft > 0;
        public int InfinityLeft => infinityLeft;
        private int movesSinceLastInfinity;
        
        
        //constructor
        public Fighter(int health, string name, int maxhealth)
        {
            Name = name;
            Health = health;
            MaxHealth = maxhealth;
        }

        public void TakeDamage(int damage, bool bypssInfinity = false)
        {
            if (isInfinityActive && !bypssInfinity)
            {
                Console.WriteLine($"{Name}'s Infinity blocks any incoming attack");
                isInfinityActive = false;
                return;
            }

            Health -= damage;
            
            if (Health <= 0)
            {
                Health = 0;
            }
        }

        public void IncrementGojo()
        {
            movesSinceLastInfinity++;
            if (movesSinceLastInfinity >= 3 && infinityLeft > 0)
            {
                isInfinityActive = true;
                movesSinceLastInfinity = 0;
                infinityLeft--;
                Console.WriteLine($"Gojo turned on his Infinity!");
            }
        }

        public void CheckInfinity()
        {
            if (isInfinityActive)
            {
                Console.WriteLine("Your Infinity is active!");
            }
            else if (infinityLeft > 0)
            {
                Console.WriteLine("Your infinity is inactive!");
            }
            else
            {
                Console.WriteLine("Your Infinity can no longer be activated!");
            }
            
        }

        //Hand-to-hand Combat method
        public void HandToHand(Fighter target)
        {
            //deals some random damage between 9-19
            int damage = Rnd.Next(9, 19);
            target.TakeDamage(damage);
            //Displays damage dealt to target from hand-to-hand attack
            Console.WriteLine($"{Name} has been hit for {damage} damage!");
            IncrementGojo();
        }

        /*---BLACK FLASH---*/
        public void BlackFlash(Fighter target)
        {   
            //5% to trigger a black flash
            //massive damage
            if (Rnd.Next(0, 101) <= 5)
            {
                int damage = 37;
                target.TakeDamage(damage);
                Console.WriteLine($"{Name} unleashed BLACK FLASH for {damage} damage! CRITICAL HIT!");
                BlackFlashCutscene();
                Thread.Sleep(2000);
            }
            else
            {
                //if black flash didn't occur
                int damage = Rnd.Next(9, 18);
                target.TakeDamage(damage);
                //Displays damage dealt to target from cursed energy attack
                Console.WriteLine($"{Name} landed a cursed energy attack {damage} damage!");
            }
        }

        //AI so it can choose what skill it uses
        public void SukunaAi(Fighter target)
        {
            int choice = Rnd.Next(1, 4);
            switch (choice)
            {
                case 1:
                    HandToHand(target);
                    break;
                case 2:
                    BlackFlash(target);
                    break;
                case 3:
                    Cleave(target);
                    break;
                case 4:
                    Dismantle(target);
                    break;
            }
            //if below 30 it heals
            if (Health <= 30 && rctUse > 0)
            {
               SukunaReverseCursedTechnique();
            }
            
            //if below 30 it automatically use dismantle
            if (target.Health <= 30)
            {
                Dismantle(target);
            }
            
            //if gojo/plauer ran out rct it automatically use wcs
            if (!target.CanUseRct)
            {
                WorldCuttingSlash(target);
            }
            //call method if sukuna ran out of wcs
            NoMoreWcsUse();
            
            //call the method if ran out of rct
            NoMoreRct();

        }
        
        //Sukuna moveset
        //damage (15-23)
        public void Cleave(Fighter target)
        {
            int damage = Rnd.Next(15, 23);
            target.TakeDamage(damage);
            Console.WriteLine($"{Name} uses cleave for {damage} damage!");
        }
        
        /*---RCT Healing---*/
        public void SukunaReverseCursedTechnique()
        {
            int healthAmount = 50;
            Health += healthAmount;

            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            Console.WriteLine($"{Name} heals using RCT!");
            rctUse--;
        }

        //sukuna speical attack
        public void WorldCuttingSlash(Fighter target)
        {
            int damage = 65;
            target.TakeDamage(damage, bypssInfinity:true);
            CutsceneWcs();
            Console.WriteLine($"{Name} uses his World Cutting Slash and deals massive {damage} damage!");
            maxWcsUse--;
        }
        
        //added Dismantle for sukuna
        public void Dismantle(Fighter target)
        {
            int damage = 24;
           target.TakeDamage(damage);
            Console.WriteLine($"{Name} uses Dismantle towards Gojo! {damage} damage!");
        }
        
        //if rctuse is 0 it prints this
        public void NoMoreRct()
        {
            if (rctUse <= 0 && !hasWarnedRCT)
            {
                rctUse = 0;
                hasWarnedRCT = true;
                Console.WriteLine($"{Name} can't use RCT due to overuse!");
            }
        }

        //if wcsuse is 0 it do this
        public void NoMoreWcsUse()
        {
            if (maxWcsUse <= 0 && !hasWarnedWCS)
            {
                maxWcsUse = 0;
                hasWarnedRCT = true;
                Console.WriteLine($"{Name} can't chant WCS!");
            }
        }

        /*---GOJO'S RCT---*/
        public void GojoReverseCursedTechnique()
        {
            int healthAmount = 50;
            Health += healthAmount;

            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            Console.WriteLine($"{Name} heals using RCT!");
            rctUse--;
            NoMoreRct();
            IncrementGojo();
        }
        
        //added red for gojo
        public void Red(Fighter target)
        {
            int damage = 23;
            target.TakeDamage(damage);
            
            if (maxRed <= 0)
            {
                
                Console.WriteLine("You can't use Red anymore!");
            }
            Console.WriteLine($"{Name} has {maxRed} Red remaining!");
            maxRed--;
            Console.WriteLine($"{Name} fires red at Sukuna {damage} damage!");
            IncrementGojo();
        }

        //cutscene for wcs
        public void CutsceneWcs()
        {
            Console.Clear();
            Console.WriteLine("(Sukuna chants)");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Scale of the Dragon");
            Thread.Sleep(2000);
            Console.WriteLine("Recoil. . .");
            for (int cycle = 0; cycle < 3; cycle++)
            {
                for (int dot = 1; dot <= 3; dot++)
                {
                    Console.Clear();
                    Console.WriteLine($"{new string('.',dot)}");
                    Thread.Sleep(500);
                }
            }
            Console.Clear();
            Console.WriteLine("Twin Meteors");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("Dodge this if you can. . .");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("(A slash capable of cleaving space itself descends. . . and it’s coming for you.)");
            Thread.Sleep(2500);
            Console.Clear();
        }
        
        //Cutscene for hitting Black Flash
        public void BlackFlashCutscene()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Time slows down...");
            Thread.Sleep(1000);

            Console.WriteLine("Black streak outlined in white, crackling violently.");
            Thread.Sleep(1200);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("…BLACK FLASH!");
            Console.WriteLine("Strike hits within the 0.000001s alignment window for Black Flash!");
            Thread.Sleep(800);

            Console.ResetColor();
            Console.WriteLine($"\n{Name} feels the space distort around them...");
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{Name} is hit with unimaginable speed and force!");
            Thread.Sleep(1200);

            Console.ResetColor();
            Console.WriteLine("\nThe moment passes… everything returns to normal.");
            Thread.Sleep(1000);
        }

        //checks if the fighter is still alive
        public bool IsAlive()
        {
            return Health > 0;
        }
    }
