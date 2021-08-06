using System.Collections;
using System.Collections.Generic;
using InterviewQuestions.enums;

namespace InterviewQuestions.Module
{
    public class Set : IQuestionSet
    {
        public Language Language { get; init; } 
        private IQuestionSet QuestionSet { get; init; }
        
        public Set(IQuestionSet questionSet)
        {
            QuestionSet = questionSet;
            Language = questionSet.Language;
        }
        
        public IEnumerable<string> GetQuestions()
        {
            return QuestionSet.GetQuestions();
        }

        public IEnumerable<string> GetAnswers()
        {
            return QuestionSet.GetAnswers();
        }
    }
}