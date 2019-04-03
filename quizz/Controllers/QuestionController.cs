using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quizz.Models;

namespace quizz.Controllers
{
    public class QuestionController : Controller
    {
        QuestionsDataAccessLayer objQuestions = new QuestionsDataAccessLayer();

        // GET: api/<controller>
        [HttpGet]
        [Route("api/questions/index")]
        public IEnumerable<Questions> Index()
        {
            return objQuestions.GetAllQuestions().ToList();
        }

        [HttpGet]
        [Route("api/questions/details/{IdQuizz}")]
        public IEnumerable<Questions> Details(string IdQuizz)
        {
            return objQuestions.GetQuestions(IdQuizz).ToList();
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/question/create")]
        public int Create(Questions qt)
        {
            return objQuestions.AddQuestion(qt);
        }

        // get quizz list
        [HttpGet]
        [Route("api/question/getQuizzList")]
        public IEnumerable<Quizz> Details()
        {
            return objQuestions.GetQuizzs();
        }
    }
}