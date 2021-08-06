using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace InterviewQuestions.Model
{
    public class Model
    {
        private HtmlDocument Doc { get; set; }

        public Model(HtmlDocument doc)
        {
            doc = Doc;
        }


        private static IEnumerable<string> GetAnswers(HtmlDocument doc)
        {
            var elements =
                doc.DocumentNode.SelectNodes("//*[@id=\"readme\"]/div[3]/article/ol[position() >= 2]/*");
            var elementsList = elements.ToList()
                .Select(e => Regex.Replace(e.InnerText, @"^\s*$\n|\r", string.Empty, RegexOptions.Multiline));
            return elementsList;
        }


        private static IEnumerable<string> GetQuestions(HtmlDocument doc)
        {
            var table = doc.DocumentNode.SelectSingleNode("//table[1]");
            var questions = Regex
                .Replace(table.InnerText, @"^\d+|No.|Questions", string.Empty, RegexOptions.Multiline)
                .Split("\n").ToList();

            questions.RemoveAll(e => e == string.Empty);
            return questions;
        }
    }
}