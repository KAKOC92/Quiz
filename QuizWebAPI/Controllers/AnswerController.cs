using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizTest;

namespace QuizWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class AnswerController : ControllerBase                             //Контроллер для ответов
    {
        QuizContext db;

        [HttpGet("{id}")]

        public async Task<JsonResult> GetAnswersList(QuizContext context)       // Получаем список ответов          
        {
            return new JsonResult(await context.Quizzes.ToListAsync());
        }

        [HttpGet]
        public async Task<JsonResult> GetAnswer(QuizContext context, int id)
        {
            Answer? result = await context.Answers.FindAsync(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(result);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetAnswerList(QuizContext context, int id)  // на вход ид вопроса-на выход варианты ответа
        {
            var result = context.Answers.Where(x => x.QuestionId == id); ;
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(result);
        }
        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteAnswer(QuizContext context, int id)   // Удаляем ответ
        {
            try
            {
                Answer result = new Answer() { AnswerId = id };
                context.Answers.Attach(result);                                    //Посмотри комент в контексте
                context.Answers.Remove(result);
                await context.SaveChangesAsync();
                return new JsonResult(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(500));
            }

        }

        [HttpPost]
        public async Task<JsonResult> AddAnswer(QuizContext context, Answer item)
        {
            try
            {
                context.Answers.Add(item);
                await context.SaveChangesAsync();
                return new JsonResult(Ok());

            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(500), ex);
            }
        }

        [HttpPost("{id}")]
        public async Task<JsonResult> UpdateAnswers(QuizContext context, Answer item)
        {
            try
            {
                Answer? result = await context.Answers.FindAsync(item.AnswerId);
                if (result != null)
                {
                    result.AnswerDescription = item.AnswerDescription;
                    result.QuestionId = item.QuestionId;
                    await context.SaveChangesAsync();
                    return new JsonResult(Ok());
                }
                else
                    return new JsonResult(NotFound());
            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(500), ex);
            }
        }

    }
}
