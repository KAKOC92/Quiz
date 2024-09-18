import React from "react";

export function QuestionWithManyVar(){
    return(<div className='checkbox_buttons'>
      <h2> Вопрос №2 Можно выбрать несколько вариантов ответа </h2>
      <input type="checkbox" name="answerVariant" /> <text> Вариант ответа 1 </text> <br/>
      <input type="checkbox" name="answerVariant" /> <text> Вариант ответа 2 </text> <br/>
      <input type="checkbox" name="answerVariant" /> <text> Вариант ответа 3 </text> <br/>
      <input type="checkbox" name="answerVariant" /> <text> Вариант ответа 4 </text> <br/> 
    </div>
    )
}