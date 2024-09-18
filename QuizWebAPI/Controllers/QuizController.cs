using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizTest;

// Необходимо по этому образцу создать контроллеры         !вроде да, кроме изменения!
// Заново подключить пакеты                                   !какие пакеты блять?!
// в Програм кс подключить в зависимость контекс для базы     ! что то не понимаю!

namespace QuizWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase                                //Контроллер для опросников
    {
        QuizContext db;
               

        [HttpGet]
        public async Task<JsonResult> GetQuizzesList(QuizContext context)       // Получаем список опросников          
        {
            return new JsonResult(await context.Quizzes.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<JsonResult> GetQuizById(QuizContext context, int id)
        {
            Quiz? result = await context.Quizzes.FindAsync(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteQuiz(QuizContext context, int id)   // Удаляем опросник
        {
            try
            {
                Quiz result = new Quiz() { QuizId = id };
                context.Quizzes.Attach(result);
                context.Quizzes.Remove(result);
                await context.SaveChangesAsync();
                return new JsonResult(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(500));
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddQuiz(QuizContext context, Quiz item)
        {
            try
            {
                context.Quizzes.Add(item);
                await context.SaveChangesAsync();
                return new JsonResult(Ok());

            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(500), ex);
            }
        }

        [HttpPost("{id}")]
        public async Task<JsonResult> UpdateQuiz(QuizContext context, Quiz item)
        {
            try
            {
                Quiz? result = await context.Quizzes.FindAsync(item.QuizId);
                if (result != null)
                {
                    result.QuizName = item.QuizName;
                    result.QuizDescription = item.QuizDescription;
                    result.QuizDateTime = item.QuizDateTime;
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




        //Контроллеры делают для каждого класса   !есть!
        //Нужен метод который возвращает по ИД.содаёт, удаляет и изменяет в опросниках реализуется в контроллере вопросников (в этом) !почти!
        //Нужен метод который удалит все ответы, все вопросы и затем опросник тоже в этом методе !вроде есть!



    }
}



       