using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quizz.Models
{
    public class QuestionsDataAccessLayer
    {
        quizzContext db = new quizzContext();

        public IEnumerable<Questions> GetAllQuestions()
        {
            try
            {
                return db.Questions.ToList();
            }
            catch
            {
                throw;
            }
        }

        //add new employee record
        public int AddQuestion(Questions qt)
        {
            try
            {
                db.Questions.Add(qt);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
