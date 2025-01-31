using System;
using System.Collections.Generic;

namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var wordFinder = new WordFinder(new List<string> { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" });
            var topWords = wordFinder.Find(new List<string> { "cold", "wind", "snow", "chill"});

            Console.WriteLine("Top 10 words:");

            foreach (var word in topWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}