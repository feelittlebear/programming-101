namespace TextBasedAdventureGame
{
    public class Player
    {
        public string Name { get; set; } = string.Empty;
        public int Health { get; private set; }

        public Player()
        {
            Health = 100; // Player starts with 100 health
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0; // Ensure health does not go below zero
        }
    }
}
