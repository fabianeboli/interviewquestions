using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HtmlAgilityPack;
using InterviewQuestions.enums;

namespace InterviewQuestions.Module
{
    public class CSharp : IQuestionSet
    {
        public Language Language { get; init; } = Language.Csharp;
        private const string Url = "https://github.com/sudheerj/javascript-interview-questions";
        private HtmlDocument document { get; set; }


        public CSharp()
        {
            LoadWebFrameWork();
        }

        private async Task LoadWebFrameWork()
        {
            var web = new HtmlWeb();
            document = await web.LoadFromWebAsync(Url);
        }

        public IEnumerable<string> GetQuestions()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetAnswers()
        {
            throw new System.NotImplementedException();
        }
    }
}