using System;
using System.Collections.Generic;
using System.Linq;
using InterviewQuestions.enums;
using InterviewQuestions.Module;

namespace InterviewQuestions.View
{
    public static class View
    {
        public static void Display(IList<string> questions, IList<string> answers, int maxAllowedNumber,
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

        public static string UserAnswer(IList<string> answers, int questionNumber)
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

        public static void DisplayModules()
        {
            var modules = Enum.GetNames(typeof(Language));
            Console.WriteLine($"Choose language Module" +
                              $"\nFor example type 1,2 to choose javascript and csharp module");

            foreach (var (module, index) in modules.WithIndex())
            {
                Console.WriteLine($"{(index + 1).ToString()}) {module}");
            }
        }

        public static IList<Language> ChooseModule()
        {
            var chosenModules = Array.Empty<string>();

            while (chosenModules is {Length: 0})
            {
                chosenModules = Console.ReadLine()?.Trim().Split(",");
            }

            var languages = chosenModules
                .Select(module => (Language) Enum
                    .GetValues(typeof(Language))
                    .GetValue(Convert.ToInt32(module)) - 1)
                .ToList();

            return languages;
        }

        private static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
            => self.Select((item, index) => (item, index));
    }
}