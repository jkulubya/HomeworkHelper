using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeworkHelper.Api.Data;
using Microsoft.AspNetCore.Mvc;
using HomeworkHelper.Api.Models;



//
//
//TODO: Protect against overposting attack
//
//



namespace HomeworkHelper.Api.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET api/questions
        [HttpGet]
        public IActionResult Get()
        {
            var questions = (from q in _context.Questions
                            join u in _context.Users
                            on q.AuthorId equals u.Id
                            select new {
                                Id = q.Id,
                                AuthorId = q.AuthorId,
                                Title = q.Title,
                                Text = q.Text,
                                Author = u.UserName
                            }).Take(30);

            return Json(questions);
        }

        // GET api/questions/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var question = (from q in _context.Questions
                            join u in _context.Users
                            on q.AuthorId equals u.Id
                            where q.Id == id
                            select new {
                                Id = q.Id,
                                AuthorId = q.AuthorId,
                                Title = q.Title,
                                Text = q.Text,
                                Author = u.UserName
                            }).SingleOrDefault();
            
            if (question == null) return NotFound();

            return Json(question);
        }

        // POST api/questions
        [HttpPost]
        public IActionResult Post([FromBody]Question question)
        {
            if (!ModelState.IsValid) return BadRequest();

            _context.Questions.Add(question);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/questions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/questions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/questions/5/answers
        [HttpGet("{id}/answers")]
        public IActionResult GetAnswers(int id)
        {
            var answers = from a in _context.Answers
                            join u in _context.Users
                            on a.AuthorId equals u.Id
                            where a.QuestionId == id
                            select new {
                                id = a.Id,
                                text = a.Text,
                                questionId = a.QuestionId,
                                authorId = a.AuthorId,
                                author = u.UserName
                            };

            return Json(answers);
        }

        // GET api/questions/5/answers
        [HttpPost("{id}/answers")]
        public IActionResult PostAnswer(int id, [FromBody] Answer answer)
        {
            if (!ModelState.IsValid) return BadRequest();

            _context.Answers.Add(answer);
            _context.SaveChanges();

            return Ok();
        }
    }
}
