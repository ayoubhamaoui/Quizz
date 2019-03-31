using System;
using System.Collections.Generic;

namespace quizz.Models
{
    public partial class Questions
    {
        public string Idquestion { get; set; }
        public string IdQuizz { get; set; }
        public string Question { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string Answer { get; set; }
        public int? Poid { get; set; }

        public virtual Quizz IdQuizzNavigation { get; set; }
    }
}
