using System.Collections;
using System.Collections.Generic;
using InterviewQuestions.enums;

namespace InterviewQuestions
{
    public interface IQuestionSet
    {
        public Language Language { get; init; }
        public IEnumerable<string> GetQuestions();
        public IEnumerable<string> GetAnswers(); 
        
        
    }
}