using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using InterviewQuestions.enums;

namespace InterviewQuestions.Module
{
    public class Javascript : IQuestionSet
    {
        public Language Language { get; init; } = Language.Javascript;
        private const string Url = "https://github.com/sudheerj/javascript-interview-questions";
        private HtmlDocument document { get; set; }

        public Javascript()
        {
            var web = new HtmlWeb();
            document = web.Load(Url);
        }

        public IEnumerable<string> GetQuestions()
        {
            var elements =
                document
                    .DocumentNode
                    .SelectNodes("//*[@id=\"readme\"]/div[3]/article/ol[position() >= 2]/*");

            var elementsList = elements
                .ToList()
                .Select(e =>
                    Regex
                        .Replace(
                            e.InnerText,
                            @"^\s*$\n|\r",
                            string.Empty, RegexOptions.Multiline));

            return elementsList;
        }

        public IEnumerable<string> GetAnswers()
        {
            var elements =
                document
                    .DocumentNode
                    .SelectNodes("//*[@id=\"readme\"]/div[3]/article/ol[position() >= 2]/*");
            
            var elementsList = elements
                .ToList()
                .Select(e => Regex
                    .Replace(
                        e.InnerText, 
                        @"^\s*$\n|\r", 
                        string.Empty, RegexOptions.Multiline));
            
            return elementsList;
        }
    }
}