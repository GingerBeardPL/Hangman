using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew", "kiwi", "lemon" };

            Random random = new Random();
            int randomIndex = random.Next(words.Length);
            string word = words[randomIndex];
            char[] hiddenWord = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                hiddenWord[i] = '_';
            }

            int attempts = 10;

            while (attempts > 0)
            {
                Console.WriteLine("Guess a letter:");
                char letter = Console.ReadLine()[0];
                bool correctGuess = false;

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter)
                    {
                        hiddenWord[i] = letter;
                        correctGuess = true;
                    }
                }

                if (correctGuess)
                {
                    Console.WriteLine("Correct guess!");
                }
                else
                {
                    attempts--;
                    Console.WriteLine("Wrong guess! Attempts left: " + attempts);
                }

                Console.WriteLine("Current word: " + new string(hiddenWord));

                if (new string(hiddenWord) == word)
                {
                    Console.WriteLine("Congratulations, you guessed the word!");
                    break;
                }
            }

            if (attempts == 0)
            {
                Console.WriteLine("You lost! The word was " + word);
            }
        }
    }
}
