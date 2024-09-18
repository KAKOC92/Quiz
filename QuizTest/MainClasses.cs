using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QuizTest                                            
                                                                                                                             
{
    [Table("Quizzes")]                                         //Это имя таблицы
    internal class Quiz
    {
        [Key]
        public int QuizId { get; set; }                        //ID опросника
        [Required]
        public string QuizName { get; set; }                   //Название опросника
        [Required]
        public string QuizDescription { get; set; }            //Переменная для описания опроса (опросника)

        public string QuizDateTime { get; set; } = DateTime.Now.ToString();  // Переменная описывает дату создания опроса
                                                                             // SET/GET свойства полей
    }
    
                                                               //В вопросе должа быть ссылка на опросник

    [Table("Questions")]
    class Question
    {
        [Key]
        public int QuestionId { get; set; }                     //ID или № вопроса
        [Required]
        public string? QuestionDescription { get; set; }       //Переменная для написания вопроса

        public int QuizId { get; set; }                        //Это ссылка от вопроса которая ведёт к опроснику

    }

    

    [Table("Answers")]
    class Answer
    {
        [Key]
        public int AnswerId { get; set; }                      //ID или № ответа
        [Required]
        public string? AnswerDescription { get; set; }         //Переменная для написания ответа на вопрос
        public int QuestionId { get; set; }                   // Это ссылка от ответа которая ведёт к вопросу

    }



}
