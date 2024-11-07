namespace TextBasedAdventureGame
{
    public class Chamber
    {
        public string Description { get; }
        public Riddle Riddle { get; }

        public Chamber(string description, Riddle riddle)
        {
            Description = description;
            Riddle = riddle;
        }
    }
}

