using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using static System.Math;
using static System.String;

namespace InterviewQuestions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string url = "https://github.com/sudheerj/javascript-interview-questions";
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(url);

            var questions = GetQuestions(doc).ToList();
            var answers = GetAnswers(doc).ToList();

            var maxAllowedNumber = Min(questions.Count, answers.Count);

            // choose random question
            Console.WriteLine($"Javascript Questions. {maxAllowedNumber.ToString()} Questions.");
            Display(questions, answers, maxAllowedNumber, new Random());
        }

        private static IEnumerable<string> GetAnswers(HtmlDocument doc)
        {
            var elements =
                doc.DocumentNode.SelectNodes("//*[@id=\"readme\"]/div[3]/article/ol[position() >= 2]/*");
            var elementsList = elements.ToList()
                .Select(e => Regex.Replace(e.InnerText, @"^\s*$\n|\r", Empty, RegexOptions.Multiline));
            return elementsList;
        }


        private static IEnumerable<string> GetQuestions(HtmlDocument doc)
        {
            var table = doc.DocumentNode.SelectSingleNode("//table[1]");
            var questions = Regex
                .Replace(table.InnerText, @"^\d+|No.|Questions", Empty, RegexOptions.Multiline)
                .Split("\n").ToList();

            questions.RemoveAll(e => e == Empty);
            return questions;
        }

        private static void Display(IList<string> questions, IList<string> answers, int maxAllowedNumber,
            Random rand)
        {
            var shouldContinue = true;
            var questionNumber = rand.Next(0, maxAllowedNumber);

            while (shouldContinue)
            {
                var info =
                    $"\n{(questionNumber + 1).ToString()}. {questions[questionNumber]}" +
                    $"\nPress q - to quit, a - to show answer, w - to go to the next question, r - to provide your answer";
                Console.WriteLine(info);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Q:
                        shouldContinue = false;
                        break;
                    case ConsoleKey.A:
                        Console.WriteLine($"\n\n--------Answer-------\n{answers[questionNumber]}");
                        questionNumber = rand.Next(0, maxAllowedNumber);
                        break;
                    case ConsoleKey.W:
                        questionNumber = rand.Next(0, maxAllowedNumber);
                        break;
                    case ConsoleKey.R:
                        Console.WriteLine($"\n{UserAnswer(answers, questionNumber)}");
                        break;
                    default:
                        Console.WriteLine($"\nWrong key");
                        continue;
                }
            }
        }

        private static string UserAnswer(IList<string> answers, int questionNumber)
        {
            Console.WriteLine("\nType your answer");
            var answer = Console.ReadLine();
            var checkedAnswer =
                $"\nYour response" +
                $"\n{answer}\n\n" +
                $"\n------Answer------\n" +
                $"{answers[questionNumber]}";
            return checkedAnswer;
        }
    }
}