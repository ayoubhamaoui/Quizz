using System;
using System.Collections.Generic;

namespace quizz.Models
{
    public partial class Enseignant
    {
        public Enseignant()
        {
            Matiere = new HashSet<Matiere>();
            Quizz = new HashSet<Quizz>();
        }

        public string Codeens { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public virtual ICollection<Matiere> Matiere { get; set; }
        public virtual ICollection<Quizz> Quizz { get; set; }
    }
}
