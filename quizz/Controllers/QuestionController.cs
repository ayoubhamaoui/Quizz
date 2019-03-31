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
        [Route("api/questions/Index")]
        public IEnumerable<Questions> Index()
        {
            return objQuestions.GetAllQuestions().ToList();
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create(Questions qt)
        {
            return objQuestions.AddQuestion(qt);
        }
    }
}