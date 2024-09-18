using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTest
{
    internal class QuizContext:DbContext                         //Этот класс для взаимодействия с БД

    {
      public DbSet<Quiz> Quizzes => Set<Quiz>();                 // Quizzes хранит объекты Quiz

        public string connectionString;
        public QuizContext(string connectionString)
        {
            this.connectionString = connectionString;            // получаем извне строку подключения
            
        }
        public QuizContext()
        {
            
            Database.EnsureCreated();                           // Создаём БД с новой схемой
                                                                // возможно нужен репозиторий для удаления опросов

        }
                                                                // Тут нужен конекшен стринг
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
         var connection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
         optionsBuilder.UseNpgsql(connection);                   // Npgsql наверно нужно испоьзовать
        }
    }
}
