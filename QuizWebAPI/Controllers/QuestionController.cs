using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizTest;

namespace QuizWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class QuestionController : ControllerBase                             //Контроллер для вопросов
    {
        QuizContext db;

        [HttpGet]

        public async Task<JsonResult> GetQuestionsList(QuizContext context)       // Получаем список вопросов          
        {
            return new JsonResult(await context.Quizzes.ToListAsync());
        }

        [HttpGet]
        public async Task<JsonResult> GetQuestionById(QuizContext context, int id)
        {
            Question? result = await context.Questions.FindAsync(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> GetQuestionList(QuizContext context, int id)    //на вход ид опроса-на выход список вопросов к нему
        {
            var result = context.Questions.Where(x => x.QuizId == id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteQuestion(QuizContext context, int id)   // Удаляем вопрос
        {
            try
            {
                Question result = new Question() { QuestionId = id };
                context.Questions.Attach(result);                                    //Посмотри комент в контексте
                context.Questions.Remove(result);
                await context.SaveChangesAsync();
                return new JsonResult(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(500));
            }
        }
        
        [HttpPost]
        public async Task<JsonResult> AddQuestion(QuizContext context, Question item)
        {
            try
            {
                context.Questions.Add(item);
                await context.SaveChangesAsync();
                return new JsonResult(Ok());

            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(500), ex);
            }
        }

        [HttpPost("{id}")]
        public async Task<JsonResult> UpdateQuestion(QuizContext context, Question item)
        {
            try
            {
                Question? result = await context.Questions.FindAsync(item.QuestionId);
                if (result != null)
                {
                    result.QuestionDescription = item.QuestionDescription;
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
