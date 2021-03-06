using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using InterviewQuestions.enums;
using InterviewQuestions.Module;
using static InterviewQuestions.View.View;
using static System.Math;
using static System.String;

namespace InterviewQuestions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DisplayModules();
            var collectionSets = new List<IQuestionSet>(new IQuestionSet[] {new Javascript(), new CSharp()});
            var chosenModules = ChooseModule(); 
            var questions = new List<string>();
            var answers = new List<string>();


            collectionSets.ForEach(set =>
            {
                if (!chosenModules.Contains(set.Language)) return;
                questions.AddRange(set.GetQuestions());
                answers.AddRange(set.GetAnswers());
            });
            
            var maxAllowedNumber = Min(questions.Count, answers.Count);
            Display(questions, answers, maxAllowedNumber, new Random());
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