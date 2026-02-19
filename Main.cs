using System;
using System.Threading;
namespace Practice;

class Program
{
    static void Main(string[] args)
    {
        //Creates fighter with their starting health and names
        Fighter gojo = new Fighter(200, "Gojo", 200);
        Fighter sukuna = new Fighter(200, "Sukuna", 200);
        
        //plays the intro
        Cutscene();
        
        //start the fight loop
        Fight(gojo, sukuna);
        
        /*-------------------CUTSCENE--------------*/
       static void Cutscene()
               {
                   Console.WriteLine("Shinjuku Showdown begins...");
                   Thread.Sleep(1500);
       
                   Console.WriteLine("The city lights flicker as two powerful sorcerers face each other.");
                   Thread.Sleep(2000);
       
                   Console.WriteLine("Satoru Gojo: Just so there's no misunderstanding, let me set you straight.");
                   Thread.Sleep(2000);
       
                   Console.WriteLine("Satoru Gojo: You're the challenger here.");
                   Thread.Sleep(1500);
                   
                   //Simulate a loading animation
                   for (int cycle = 0; cycle < 3; cycle++)
                   {
                       for (int dot = 1; dot <= 3; dot++)
                       {
                           Console.Clear();
                           Console.WriteLine($"Loading{new string('.',dot)}");
                           Thread.Sleep(400);
                       }
                   }
                   Console.Clear();
                   Console.WriteLine("Ryoumen Sukuna: You damn brat.");
                   Thread.Sleep(2000);
                   
                   Console.WriteLine("Ryoumen Sukuna: I'm the challenger?");
                   Thread.Sleep(2000);
                   
                   Console.WriteLine("Ryoumen Sukuna: . . . Go to your head.");
                   Thread.Sleep(2000);
                   
                   Console.WriteLine("Ryoumen Sukuna: You've let catching me off guard. . .");
                   Thread.Sleep(2000);
                   
                   Console.WriteLine("Ryoumen Sukuna: Satoru Gojo . . . You're just a fish on a cutting board.");
                   Thread.Sleep(2000);
                   
                   Console.WriteLine("Ryoumen Sukuna: You may flop around a lot . . . But you're still a nameless fish.");
                   Thread.Sleep(2000);
                   
                   Console.WriteLine("Ryoumen Sukuna: First, I'll strip away your scales!");
                   Thread.Sleep(2000);
                   
                   //another loading animation
                   for(int cycle = 0; cycle < 3; cycle++)
                   {
                       for (int dot = 1; dot <= 3; dot++)
                       {
                           Console.Clear();
                           Console.WriteLine($"Loading{new string('.', dot)}");
                           Thread.Sleep(400);
                       }
                   }
                   Console.Clear();
                   Console.WriteLine("Satoru Gojo: Then why're you wearing that face?");
                   Thread.Sleep(2000);
                   
                   Console.WriteLine("Satoru Gojo: You wanted me to hold back, right?");
                   Thread.Sleep(2000);
                   
                   Console.WriteLine("Satoru Gojo: Too bad for you I've undergone special training.");
                   Thread.Sleep(2000);
                   
                   Console.WriteLine("Satoru Gojo: I can totally whale on Megumi!");
                   Thread.Sleep(2000);
                   
                   Console.WriteLine("Satoru Gojo: Dying once as Yuji was a mistake.");
                   Thread.Sleep(2000);
                   
                   Console.WriteLine("Satoru Gojo: I'll worry about Megumi. . .  After i kill you.");
                   Thread.Sleep(2000);
                   
                   Console.WriteLine("The battle between the strongest sorcerers has begun!");
                   Thread.Sleep(2500);
                    
                   //Final loading before the fight
                   for (int cycle = 0; cycle < 3; cycle++)
                   {
                       for (int dot = 1; dot <= 3; dot++)
                       {
                           Console.Clear();
                           Console.WriteLine($"Loading{new string('.',dot)}");
                           Thread.Sleep(400);
                       }
                   }
                   Console.Clear();
                   Console.WriteLine("The fight has begun. Good luck!");
                   Thread.Sleep(1000);
                   Console.Clear();
               }
                
               /*----------------FIGHT LOOP--------------------*/
               //Handles the turn-based fight until one fighter's health reaches 0  
               static void Fight(Fighter gojo, Fighter sukuna)
               {
                   //Continue fighting while both fighters are alive
                   while (gojo.IsAlive() && sukuna.IsAlive())
                   {
                       Console.WriteLine("Your move!");
                       Console.WriteLine("[1] Hand to Hand (Basic Attack) ");
                       Console.WriteLine("[2] Attack imbued with Cursed Energy (Has chance of 5% to land a Black Flash)");
                       Console.WriteLine("[3] Cursed Technique Reversal: Red");
                       Console.WriteLine("[4] Reverse Cursed Technique");
                       Console.Write("What's your move?: ");
                        
                       //Validate user input
                       string? input = Console.ReadLine();
                       int choice;
                       while (!int.TryParse(input, out choice))
                       {
                           Console.WriteLine("Numbers only!");
                           input = Console.ReadLine();
                       }
                        
                       //Player choice
                       switch (choice)
                       {
                           case 1:
                               gojo.HandToHand(sukuna);
                               break;
                           case 2:
                               gojo.BlackFlash(sukuna);
                               break;
                           case 3:
                               gojo.Red(sukuna);
                               break;
                           case 4:
                               gojo.GojoReverseCursedTechnique();
                               break;
                           default:
                               Console.WriteLine("Not in the Choices!");
                               break;
                       }
                        
                       //Enemy turn
                       if (sukuna.IsAlive())
                       {
                           sukuna.SukunaAi(gojo);
                           Console.WriteLine("Sukuna turn!");
                           Console.WriteLine($"Gojo HP: {gojo.Health} - Sukuna HP: {sukuna.Health} ");
                           Thread.Sleep(2000);
                           Console.Clear();
                       }
                   }
                   
                   //fight is over checks who won or if it's a tie
                   if (!sukuna.IsAlive() && !gojo.IsAlive())
                   {
                       AfterMath("tie");
                   }
                   else if (!sukuna.IsAlive())
                   {
                       AfterMath("gojoWins");
                   }
                   else if (!gojo.IsAlive())
                   {
                       AfterMath("sukunaWins");
                   }
               }
                
               /*--------AFTERMATH CUTSCENE----------*/
               static void AfterMath(string type)
               {
                   switch (type)
                   {
                       case "gojoWins":
                           Console.Clear();
                           Console.WriteLine("Not bad… but you forgot one thing.");
                           Thread.Sleep(2000);
                           for (int cycle = 0; cycle < 3; cycle++)
                           {
                               for (int dot = 1; dot <= 3; dot++)
                               {
                                   Console.Clear();
                                   Console.Write($"{new string('.',dot)}");
                                   Thread.Sleep(400);
                               }
                           }
                           Console.Clear();
                           Console.WriteLine("(Gojo spreads his fingers, Infinity flickering around him)");
                           Thread.Sleep(2000);
                           
                           Console.WriteLine("I'm Satoru Gojo, The strongest sorcerer to ever live.");
                           Thread.Sleep(2000);
                           Console.Clear();
            
                           Console.WriteLine("Gojo emerged victorious from the fight!");
                           Thread.Sleep(1000);
                           break;
                       case "sukunaWins":
                           Console.Clear();
                           Console.WriteLine("You were magnificent, Satoru Gojo.");
                           Thread.Sleep(2000);

                           for (int cycle = 0; cycle < 3; cycle++)
                           {
                               for (int dot = 1; dot <= 3; dot++)
                               {
                                   Console.Clear();
                                   Console.Write($"{new string('.',dot)}");
                                   Thread.Sleep(400);
                               }
                           }
            
                           Console.WriteLine("I will never forget you for as long as I live.");
                           Thread.Sleep(2500);
                           Console.Clear();
                           Console.WriteLine("Sukuna emerges victorious from the fight!");
                           break;
                       case "tie":
                           Console.WriteLine("Both fighters are exhausted from the fight and collapse");
                           Thread.Sleep(2000);
                           Console.WriteLine("It's a tie! Neither has claimed victory!");
                           break;
                   }
               }
    }
}
