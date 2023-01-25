namespace RandomGreetingGenerator
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    public class RandomGreetingGenerator
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\copyMe.png";

            Console.WriteLine("Please enter date, name and occasion in this format: \"[dd.mm] [-] [name/All] [ND/BD/NY/Christmas]\"");
            Console.WriteLine("(BD = Birthday, ND = Name day, NY = New year)");
            Console.WriteLine("Example: \"12.01 - Peter BD\" or \"31.12 - All NY\"");

            GenerateGreetings(inputFilePath);
        }
        private static void GenerateGreetings(string inputFilePath)
        {
            Dictionary<string, List<string>> dates;
            List<string> names;
            InputData(out dates, out names);

            string[] greetingsForBD = { "Cheers to another year! Hope your day is filled with love (and lots of birthday cake).",
            "Wishing you a very happy birthday and a year filled with love, adventure and prosperity. Here’s to you!",
            "Today, we celebrate you and the beautiful life you have. May your birthday be as wonderful as you are.",
            "Happy birthday—may this year be filled with adventures, blessings and lots of laughs." };

            string[] greetingsForND = { "May God heap His amazing blessings on you today and always.",
            "I wish you all the happiness in the world. Best wishes to you on your name day.",
            "May this day bestow you with happiness beyond your wildest imagination.",
            "May you be blessed with all the things in this world that make you happy and bring peace into your life. Now, let the party begin!" };

            string[] greetingsForNY = { "May you discover everything you are looking for in the new year right inside yourself!",
            "A new year is like starting a new chapter in your life. It’s your chance to write an incredible story for yourself.",
            "With the new year on the horizon, I wish that you embrace it with an open heart and go forward with faith, hope, and courage.",
            "May this coming year lead you on a new exciting adventure, complete with life-changing experiences and deeper friendships." };

            string[] greetingsForChristmas = { "I hope your holiday is full of love, peace and joy!",
            "Wishing you peace and joy all season long. Happy Holidays!",
            "I hope your Christmas is filled with laughter and prosperity.",
            "Have I been naughty or nice? Only Santa knows." };

            Console.ResetColor();

            while (true)
            {
                Console.WriteLine("Enter a day and month, in this format \"dd.mm\":");
                string currentDate = Console.ReadLine();
                if (dates.ContainsKey(currentDate))
                {
                    string currentHolidays = string.Join(" ", dates[currentDate]);
                    string[] arrayHolidaus = currentHolidays
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string name = string.Empty;
                    string occasion = string.Empty;

                    for (int i = 0; i < arrayHolidaus.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            name = arrayHolidaus[i];
                        }
                        else
                        {
                            occasion = arrayHolidaus[i];
                            string randomGreeting;

                            if (occasion == "BD")
                            {
                                randomGreeting = GetRandomSentence(greetingsForBD);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Happy birthday, {name}! {randomGreeting}");
                                Console.ResetColor();
                            }
                            else if (occasion == "ND")
                            {
                                randomGreeting = GetRandomSentence(greetingsForND);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Happy name day, {name}! {randomGreeting}");
                                Console.ResetColor();
                            }
                            else
                            {
                                for (int j = 0; j < names.Count; j++)
                                {
                                    if (occasion == "Christmas")
                                    {
                                        randomGreeting = GetRandomSentence(greetingsForChristmas);
                                        Console.WriteLine($"Merry Christmas, {names[j]}! {randomGreeting}");
                                    }
                                    else if (occasion == "NY")
                                    {
                                        randomGreeting = GetRandomSentence(greetingsForNY);
                                        Console.WriteLine($"Happy New year, {names[j]}! {randomGreeting}");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no occasion in this date.");
                    Console.ResetColor();
                }
            }
        }

        private static void InputData(out Dictionary<string, List<string>> dates, out List<string> names)
        {
            dates = new Dictionary<string, List<string>>();

            string inputData;

            names = new List<string>();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            while ((inputData = Console.ReadLine()) != "End")
            {
                string[] strings = inputData
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string[] findeName = inputData
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = findeName[2];

                if (!names.Contains(name) && name != "All")
                {
                    names.Add(name);
                }

                string date = strings[0];
                string holiday = strings[1];

                if (!dates.ContainsKey(date))
                {
                    dates.Add(date, new List<string>());
                    dates[date].Add(holiday);
                }
                else
                {
                    if (dates[date].Contains(holiday))
                    {
                        continue;
                    }
                    else
                    {
                        dates[date].Add(holiday);
                    }
                }
            }
        }

        private static string GetRandomSentence(string[] sentences)
        {
            Random random = new Random();
            int ranndomIndex = random.Next(sentences.Length);
            string sentence = sentences[ranndomIndex];
            return sentence;
        }
    }
}