using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Answer {
    [TextArea(10,10)]
    public string answer;
    [TextArea(10,10)]
    public bool isCorrectAnswer;
}

[Serializable]
public class Question {
    public string Questions;
    public Answer[] answerList;
}
[CreateAssetMenu(menuName = "QuestionData")]
public class QuestionData : ScriptableObject {
    public List<Question> questionList;

    public void OnValidate() {
        foreach (var question in questionList)
        {
            if (question.answerList.Length != 4)
            {
                Debug.LogError($"Question \"{question.Questions}\" does not have exactly 4 answers.");
                continue;
            }
            int correctAnswerCount = 0;
            foreach (var answer in question.answerList)
            {
                if (answer.isCorrectAnswer)
                {
                    correctAnswerCount++;
                }
            }

            if (correctAnswerCount > 1)
            {
                Debug.LogError($"Question \"{question.Questions}\" has more than one correct answer.");
            }
        }
    }
}
