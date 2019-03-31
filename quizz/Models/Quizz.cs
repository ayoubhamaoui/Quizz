using System;
using System.Collections.Generic;

namespace quizz.Models
{
    public partial class Quizz
    {
        public Quizz()
        {
            Matiere = new HashSet<Matiere>();
            Passer = new HashSet<Passer>();
            Questions = new HashSet<Questions>();
        }

        public string IdQuizz { get; set; }
        public string Codeens { get; set; }
        public string Sujet { get; set; }

        public virtual Enseignant CodeensNavigation { get; set; }
        public virtual ICollection<Matiere> Matiere { get; set; }
        public virtual ICollection<Passer> Passer { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
