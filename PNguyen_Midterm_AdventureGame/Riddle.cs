using System.Collections.Generic;

namespace TextBasedAdventureGame
{
    public class Riddle
    {
        public string Question { get; }
        public List<string> Answers { get; }

        public Riddle(string question, params string[] answers)
        {
            Question = question;
            Answers = new List<string>(answers);
        }

        public bool CheckAnswer(string playerAnswer)
        {
            foreach (var answer in Answers)
            {
                if (playerAnswer.Trim().ToLower() == answer.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
