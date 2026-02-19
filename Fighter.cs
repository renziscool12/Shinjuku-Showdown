using System.Threading;
using System;
namespace Practice;

class Fighter
{
    //fields
    private string Name { get; }
    //encapsulation
    public int Health { get; private set; }
    // Single shared Random instance for generating random numbers throughout the class.
    // 'static' ensures all objects share the same Random (prevents duplicate seeds),
    // 'readonly' means it can only be assigned once and not changed later.
    private static readonly Random Rnd = new Random();
    
    //rct uses
    private int rctUse = 3;
    private bool hasWarnedRCT = false;
    private int MaxHealth;
    //constructor
    public Fighter(int health, string name, int maxhealth)
    {
        Name = name;
        Health = health;
        MaxHealth = maxhealth;
    }

    //Hand-to-hand Combat method
    public void HandToHand(Fighter target)
    {
        //deals some random damage between 9-19
        int damage = Rnd.Next(9, 19);
        target.Health -= damage;
        //prevents negative health
        if (target.Health < 0)
        {
            target.Health = 0;
        }
        //Displays damage dealt to target from hand-to-hand attack
        Console.WriteLine($"{Name} has been hit for {damage} damage!");
    }

    /*---BLACK FLASH---*/
    public void BlackFlash(Fighter target)
    {   
        //5% to trigger a black flash
        //massive damage
        if (Rnd.Next(0, 101) <= 5)
        {
            int damage = 37;
            target.Health -= damage;
            Console.WriteLine($"{Name} unleashed BLACK FLASH for {damage} damage! CRITICAL HIT!");
            BlackFlashCutscene();
            Thread.Sleep(2000);
        }
        else
        {
            //if black flash didn't occur
            int damage = Rnd.Next(9, 18);
            target.Health -= damage;
            //Displays damage dealt to target from cursed energy attack
            Console.WriteLine($"{Name} landed a cursed energy attack {damage} damage!");
        }

        //prevents negative health
        if (target.Health <= 0)
        {
            target.Health = 0;
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
        
        //call the method
        NoMoreRct();

    }
    
    //Sukuna moveset
    //damage (15-23)
    public void Cleave(Fighter target)
    {
        int damage = Rnd.Next(15, 23);
        target.Health -= damage;
        
        if (target.Health <= 0)
        {
            target.Health = 0;
        }
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
    
    //added Dismantle for sukuna
    //damage -> 24
    public void Dismantle(Fighter target)
    {
        int damage = 24;
        target.Health -= damage;
        if (target.Health <= 0)
        {
            target.Health = 0;
        }
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
    }
    
    //added red for gojo
    //damage -> 23
    public void Red(Fighter target)
    {
        int damage = 23;
        target.Health -= damage;
        if (target.Health <= 0)
        {
           target.Health = 0;
        }
        Console.WriteLine($"{Name} fires red at Sukuna {damage} damage!");
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
