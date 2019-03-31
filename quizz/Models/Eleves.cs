using System;
using System.Collections.Generic;

namespace quizz.Models
{
    public partial class Eleves
    {
        public Eleves()
        {
            Passer = new HashSet<Passer>();
        }

        public string Codeelev { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int? Niveau { get; set; }
        public DateTime? Dateinsc { get; set; }
        public string Elevscol { get; set; }
        public DateTime? Anneediplom { get; set; }
        public string CodeFil { get; set; }

        public virtual ICollection<Passer> Passer { get; set; }
    }
}
