using System;
using System.Collections.Generic;

namespace quizz.Models
{
    public partial class Passer
    {
        public string IdQuizz { get; set; }
        public string Codeelev { get; set; }
        public DateTimeOffset DatePass { get; set; }
        public float? Note { get; set; }

        public virtual Eleves CodeelevNavigation { get; set; }
        public virtual Quizz IdQuizzNavigation { get; set; }
    }
}
