using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_API.API.Deserializer
{
    public class FAQ
    {
        public List<QuestionsAnswer> questionsAnswers { get; set; }
        public string sectionNameEnglish { get; set; }
        public string sectionNameFrench { get; set; }
    }

    public class QuestionsAnswer
    {
        public string questionEnglish { get; set; }
        public string questionFrench { get; set; }
        public string answerEnglish { get; set; }
        public string answerFrench { get; set; }
    }
}
