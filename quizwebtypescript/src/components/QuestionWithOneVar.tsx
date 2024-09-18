import React from "react"

export function QuestionWithOneVar(){
    return(<div className='radio_buttons'>
      <h2> Вопрос №1 Можно выбрать только один вариант ответа </h2>
      <input type="radio" name="answerVariant" /> <text> Вариант ответа 1 </text> <br/>
      <input type="radio" name="answerVariant" /> <text> Вариант ответа 2 </text> <br/>
      <input type="radio" name="answerVariant" /> <text> Вариант ответа 3 </text> <br/>
      <input type="radio" name="answerVariant" /> <text> Вариант ответа 4 </text> <br/>
    </div>
    )
}