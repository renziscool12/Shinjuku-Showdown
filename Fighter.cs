namespace Practice;

class Fighter
{
    //fields
    public string Name { get; }
    //encapsulation
    public int Health { get; private set; }
    private static Random rnd = new Random();
    
    //constructor
    public Fighter(int health, string name)
    {
        this.Name = name;
        Health = health;
    }

    //Hand-to-hand Combat method
    public void HandToHand(Fighter target)
    {
        //deals some random damage between 15-30
        int damage = rnd.Next(15, 30);
        target.Health -= damage;
        //prevents negative health
        if (target.Health < 0)
        {
            target.Health = 0;
        }
        Console.WriteLine($"{Name} has been hit for {damage} damage!");
    }

    //checks if the fighter is still alive
    public bool IsAlive()
    {
        return Health > 0;
    }
}
