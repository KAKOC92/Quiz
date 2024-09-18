import React from 'react';
import { QuizName } from './components/QuizName';
import { QuizDescription } from './components/QuizDescription';
import { QuestionWithOneVar } from './components/QuestionWithOneVar';
import { QuestionWithManyVar } from './components/QuestionWithManyVar';
import { Button } from './components/Button';

function App() {
  return ( <div>
    <QuizName />
    <QuizDescription />
    <QuestionWithOneVar />
    <QuestionWithManyVar />
    <Button />
    </div> 
  );
}

export default App;
