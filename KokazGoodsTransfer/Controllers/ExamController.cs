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
            var question = this.Context.Exams
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
                te.Questions = new List<GetQuestionDto>();
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
            var transacrtion = this.Context.Database.BeginTransaction();
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
                this.Context.SaveChanges();
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
                        Question1 = item.Question,
                        Time = item.Time
                    };
                    this.Context.Add(question);
                    this.Context.SaveChanges();
                }
                transacrtion.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                transacrtion.Rollback();
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
        [HttpGet("GetCurrentExamForStudent")]
        public IActionResult GetCurrentExamForStudent([FromQuery] DateTimeDto dateTimedto)
        {

            var userId = dateTimedto.UserId;
            var dateTime = new DateTime(dateTimedto.Year, dateTimedto.Month, dateTimedto.Day, dateTimedto.Hour, dateTimedto.Minit, 0);
            var exams = this.Context.Exams
                .Include(c => c.Questions)
                    .ThenInclude(c => c.StudentAnswers)
                .ToList();
            var exam = exams
                .Where(c => c.Date.Year == dateTime.Year && c.Date.Month == dateTime.Month && c.Date.Day == dateTime.Day).OrderBy(c => c.Date)
                .FirstOrDefault();
            if (exam == null)
                return Ok(false);
            if (exam.Questions.Any(c => c.StudentAnswers.Any(c => c.StudentId == userId)))
            {
                return Conflict();
            }
            ExamStudentDto examStudentDto = new ExamStudentDto()
            {
                Id = exam.Id,
                Title = exam.Title,
                Date = exam.Date,
                Question = new List<GetQuestionStudnetDto>()

            };
            foreach (var item in exam.Questions)
            {
                examStudentDto.Question.Add(new GetQuestionStudnetDto()
                {
                    Id = item.Id,
                    Choise1 = item.Choise1,
                    Choise2 = item.Choise2,
                    Choise3 = item.Choise3,
                    Choise4 = item.Choise4,
                    Question = item.Question1,
                    Time = item.Time
                });
            }
            var questions = examStudentDto.Question;
            return Ok(new { examStudentDto, questions });
        }
        [HttpPost("Answer")]
        public IActionResult Answer([FromBody]List<AnswerQuestion> answerQuestion)
        {
            //var studnetId = AuthoticateUserId();
            foreach (var item in answerQuestion)
            {
                StudentAnswer sa = new StudentAnswer()
                {
                    Answer = item.Answer,
                    QuestionId = item.Id,
                    StudentId = item.UserId
                };
                this.Context.Add(sa);
            }
            this.Context.SaveChanges();
            return Ok();
        }

        [HttpGet("GetAnswers/{id}")]
        public IActionResult GetAnswers(int id)
        {
            var studnetAns = this.Context.StudentAnswers
                .Include(c => c.Question)
                    .ThenInclude(c => c.Exam)
                .Include(c => c.Student)
                .Where(c => c.Question.ExamId == id)
                .ToList();
            studnetAns = studnetAns.OrderBy(c => c.StudentId).ToList();
            List<ShowAsnser> showAsnsers = new List<ShowAsnser>();
            foreach (var item in studnetAns)
            {
                showAsnsers.Add(new ShowAsnser()
                {
                    Answer = item.Answer,
                    StudnetName = item.Student.Name,
                    Question = item.Question.Question1,
                    Valid= item.Answer== item.Question.Correct
                }); ;
            }
            return Ok(showAsnsers);
        }

    }
}