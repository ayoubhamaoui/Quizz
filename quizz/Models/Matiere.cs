using System;
using System.Collections.Generic;

namespace quizz.Models
{
    public partial class Matiere
    {
        public string Codemat { get; set; }
        public string IdQuizz { get; set; }
        public string Codeens { get; set; }
        public string Designation { get; set; }
        public float? Poids { get; set; }
        public string Codemodule { get; set; }

        public virtual Enseignant CodeensNavigation { get; set; }
        public virtual Quizz IdQuizzNavigation { get; set; }
    }
}
