using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Threading.Tasks;

namespace QuizTest
{
    public class QuizContext:DbContext                           //Этот класс для взаимодействия с БД

    {
      public DbSet<Quiz> Quizzes => Set<Quiz>();                 // Quizzes хранит объекты Quiz
      public DbSet<Question> Questions { get; set; }
      public DbSet<Answer> Answers { get; set; }
     


     



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
                                                                 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            //var connection = System.Configuration.ConfigurationManager.ConnectionStrings["QuizConnectStr"].ConnectionString;
            System.Console.WriteLine("ВСЁ ХОРОШО");
            optionsBuilder.UseNpgsql("Host=169.254.81.186;Port=5432;Database=Quiz;Username=postgres;Password=251992");                   // Npgsql наверно нужно испоьзовать
        }

    }
}
