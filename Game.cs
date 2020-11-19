using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyApp2._0Alex
{
    class Game
    {
        Random rnd = new Random();
        Player player = new Player();

        public Game()
        {
            Console.Title = "Study and Review by Alex Sperry";
            Console.WriteLine("Welcome to the Programming 101 study quiz\nPlease enter your name: ");
            player.name = Console.ReadLine();
            Console.WriteLine("Hello " + player.name + "!");
            Console.WriteLine("Press any key to continue\n---------------------------------------------------------");

            string[] question = File.ReadAllLines("words.txt");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Here are your words:\n----------------------");

            foreach (string word in question)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("----------------------");
            Console.ResetColor();

            string[] answer = File.ReadAllLines("answers.txt");

            Questions[] qarray = new Questions[15];

            for (int i = 0; i < 15; i++)
            {
                qarray[i] = new Questions();
                qarray[i].term = question[i];
                qarray[i].definition = answer[i];
            }

            for (int i = 0; i < 15; i++)
            {
                int number = rnd.Next(0, 15);

                Console.WriteLine("What term matches this definition?\n" + qarray[number].definition);
                Console.ForegroundColor = ConsoleColor.White;
                string ans = Console.ReadLine();
                Console.ResetColor();
                ans.ToLower();

                if(ans == qarray[number].term)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCongrats you are correct!\n");
                    player.points++;
                    Console.ResetColor();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry, that answer was incorrect.\n");
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Great job! You have completed the game!\nYour score is " + player.points + "/15.");
            Console.ResetColor();
            Console.ReadKey(true);

        }
    }
}
