using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HangMan2
{
    class Program
    {
        // global list for animals used in HangMan
        
        static string[] Animals = { "Fox", "Wolf", "Bear","Otter", "Ocelot", "SnowLeopard", "Lion", "Hyena", "Squirrel", "Skunk", "Zebra", "Panther", "Cheetah", "Snake", "Chameleon", "Dragon" };
        static string chosenWord;
        static string playerName = "";
        static int guessesStart= 10;
        static int guessesCurrent = guessesStart;
        static List<string> lettersGuessed = new List<string>();
        static bool playing = true;
        static void Main(string[] args)
        {
            HangMan();
            Console.ReadKey();

        }
        static void MaskWord()//This will display word
        {
            Text("Here is the word currently: ");
            Console.WriteLine();
            Thread.Sleep(500);
            string returnString = "";
            int i = 0;
            while (i < chosenWord.Length)
            {
                char current = chosenWord[i];
                if (lettersGuessed.Where(x => x == current.ToString()).Count() == 0)
                {

                    returnString += " _";
                    i++;
                }
                else
                {
                    returnString += (" " + current);
                    i++;
                }
            }
            Console.WriteLine();
            Text(returnString);
            Console.WriteLine();
            Console.WriteLine();
            Text("Guessed Letters: " + string.Join(" ",lettersGuessed));
            Console.WriteLine();
            Text("Guesses Remaining: " + guessesCurrent);
            Console.WriteLine();
            Console.WriteLine();
            Text("Ok! What letter would you like to guess next?");
            Console.WriteLine();
        }
        static void HangMan()
        {
            Intro();
            CPUChoose();
            Text("Lets get a starter letter... Whats your 1st guess?");
            GuessLet(Console.ReadLine());
            do
            {               
                Console.WriteLine();
                
                game();
            }
            while (playing == true);
            
               
            
        }
        static void game()
        {
            MaskWord();
            GuessLet(Console.ReadLine());
        }
        static void GuessLet(string input)
        {
            Console.Clear();
            var guess = input.ToUpper();
            lettersGuessed.Add(guess);
            bool correct = false;
            for (int i = 0; i < chosenWord.Length; i++)
            {
                char y = chosenWord[i];
                if (guess.Where(x => x == y).Any())
                {
                    correct = true;
                }
            }
            if (guess.Length == 0)
            {
                Text("There was no input! Stop hitting enter that much!");
                Thread.Sleep(1000);
                Text("(press any key)");
            }
            else if (correct == true)
            {
                Text("That letter is within the hidden word! I'll switch that out now!");
            }
            else
            {
                Text("That letter is not within the hidden word... Try again. (attempts -1)");
                guessesCurrent -= 1;
            }
                Console.WriteLine();
                Text("I'll add that letter to the guessed list, dont guess it again!");
                Console.WriteLine();
                Thread.Sleep(500);
                Text("(press any key)");
                Console.ReadKey();
                Console.Clear();
            

        }
        static void CPUChoose()
        {
            Random random = new Random();
            int Index = random.Next(0, Animals.Length);
            chosenWord = Animals[Index].ToUpper();
            Text("OK! A word has now been chosen! One moment while I set the game up!");
            Thread.Sleep(5000);
            Console.WriteLine();
            Text("(press any key)");
            Console.ReadKey();
            Console.Clear();
        }
        static void Intro()
        {
            Text("Welcome to Hangman!");
            Console.WriteLine();
            Thread.Sleep(700);
            Text("This Hangman game theme will be about animals!");
            Console.WriteLine();
            Thread.Sleep(700);
            Text("To start, what is your name?");
            Console.WriteLine();
            playerName = Console.ReadLine();
            Console.Clear();
            Text("Welcome to the Animal Hangman game, " + playerName + "!");
            Thread.Sleep(700);
            Console.WriteLine();
            Text("Shall we get started?");
            Text("(press any key)");
            Thread.Sleep(1200);
            Console.ReadKey();
            Console.Clear();
        }
        static void Text(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
                Thread.Sleep(5);
            }
        }

    }
}
