namespace Trivia
{
    class TriviaItem
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string[]? Options { get; set; }

        public TriviaItem(string question, string correctAnswer)
        {
            Question = question;
            CorrectAnswer = correctAnswer;
        }

        public void SetOptions(string[] options)
        {
            Options = options;
        }
    }
}