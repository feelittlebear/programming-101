namespace TextBasedAdventureGame
{
    public class Enemy
    {
        public string Name { get; }
        public Riddle Riddle { get; }

        public Enemy(string name, Riddle riddle)
        {
            Name = name;
            Riddle = riddle;
        }
    }
}

