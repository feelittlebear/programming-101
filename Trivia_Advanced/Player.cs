namespace Trivia
{
    class Player
    {
        public string Name { get; set; }
        public int Score { get; private set; } = 0;

        public Player(string name)
        {
            Name = name;
        }

        public void UpdateScore(bool isCorrect)
        {
            if (isCorrect)
            {
                Score++;
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"{Name}'s current score: {Score}");
        }
    }
}
