using QuizTest;

QuizContext db = new QuizContext();           //Тут создан контекст

    

    // Тут созданы опросники, потом должны быть созданы вопросы и ответы

    Quiz Quiz1 = new Quiz { QuizName = "Нравится ли вам ваша зарплата?", QuizDescription = "Простой и анонимный опрос" };
    Quiz Опрос2 = new Quiz { QuizName = "Готовы ли вы перерабатывать?", QuizDescription = "Простой и анонимный опрос" };
    
    // Одобавляем опросы в БД

    db.Quizzes.Add(Quiz1);                            //Сохранение по имени переменной!
    db.Quizzes.Add(Опрос2);
    db.SaveChanges();
    Console.WriteLine("Опросы сохранены");


    // Тут нужно получить опросы из БД и вывести на консоль
     
    var quizzes = db.Quizzes.ToList();
    Console.WriteLine("Список опросов:");
    foreach (Quiz u in quizzes)
    {
        Console.WriteLine($"{u.QuizDateTime}.{u.QuizId}.{u.QuizName}");
    }
    