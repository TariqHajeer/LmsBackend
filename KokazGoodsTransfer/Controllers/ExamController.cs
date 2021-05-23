using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LMSbackend.Dtos.ExamDto;
using LMSbackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
    
namespace LMSbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : AbstractController
    {
        public ExamController(LmsContext context, IMapper mapper) : base(context, mapper)
        {
        }
        [HttpGet]   
        public IActionResult Get()
        {
            var question= this.Context.Exams
                .Include(c => c.Questions);

            List<GetExamDto> getExamDtos = new List<GetExamDto>();
            foreach (var item in question)
            {
                var te = new GetExamDto()
                {
                    Title = item.Title,
                    Date = item.Date,
                    Id = item.Id,
                };
                foreach (var q in item.Questions)
                {
                    te.Questions.Add(new GetQuestionDto()
                    {
                        Id = q.Id,
                        Choise1 = q.Choise1,
                        Choise2 = q.Choise2,
                        Choise3 = q.Choise3,
                        Choise4 = q.Choise4,
                        Correct = q.Correct,
                        Question = q.Question1
                    });
                }
                getExamDtos.Add(te);
            }
            return Ok(getExamDtos);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateExamDto createExamDto)
        {
            try
            {
                DateTime d;
                if (createExamDto.Date == null)
                    d = DateTime.Now;
                else
                    d = (DateTime)createExamDto.Date;
                Exam exam = new Exam()
                {
                    Date = d,
                    Title = createExamDto.Title,
                    Pwassowrd = ""
                };
                this.Context.Add(exam);
                foreach (var item in createExamDto.Quetions)
                {
                    Question question = new Question()
                    {
                        ExamId = exam.Id,
                        Choise1 = item.Choise1,
                        Choise2 = item.Choise2,
                        Choise3 = item.Choise3,
                        Choise4 = item.Choise4,
                        Correct = item.Correct,
                        Question1 = item.Question
                    };
                    this.Context.Add(question);
                }
                this.Context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var exam = this.Context.Exams.Find(id);
            this.Context.Remove(exam);
            this.Context.SaveChanges();
            return Ok();
        }
        [HttpPut("Answer")]
        public IActionResult Answer([FromBody]AnswerQuestion answerQuestion)
        {
            StudentAnswer sa = new StudentAnswer()
            {
                Answer = answerQuestion.Answer,
                QuestionId = answerQuestion.Id,
                //StudentId =User.
            };
            //this.Context.
            return Ok();
        }

    }
}