namespace AhorcadoMVC.Models
{
    public class Hangman
    {
        public string WordToGuess { get; set; }
        public string CurrentGuess { get; set; }
        public int AttemptsLeft { get; set; }
        public List<char> GuessedLetters { get; set; }

        public Hangman(string word)
        {
            WordToGuess = word;
            CurrentGuess = new string('_', word.Length);
            AttemptsLeft = 6; // Número típico de intentos en el ahorcado
            GuessedLetters = new List<char>();
        }

        public bool Guess(char letter)
        {
            if (GuessedLetters.Contains(letter))
            {
                return false;
            }

            GuessedLetters.Add(letter);

            if (WordToGuess.Contains(letter))
            {
                var updatedGuess = new char[WordToGuess.Length];
                for (int i = 0; i < WordToGuess.Length; i++)
                {
                    if (WordToGuess[i] == letter)
                    {
                        updatedGuess[i] = letter;
                    }
                    else
                    {
                        updatedGuess[i] = CurrentGuess[i];
                    }
                }
                CurrentGuess = new string(updatedGuess);
                return true;
            }
            else
            {
                AttemptsLeft--;
                return false;
            }
        }

        public bool IsGameWon()
        {
            return !CurrentGuess.Contains('_');
        }

        public bool IsGameLost()
        {
            return AttemptsLeft <= 0;
        }
    }

}
