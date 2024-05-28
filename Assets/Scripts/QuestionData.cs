using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Answer {
    [TextArea(50,50)]
    public string answer;
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
        foreach (Question ques in questionList) {
            if (ques.answerList.Length >= 4) {
                Debug.LogError("The number of answers must be less than 4");
            }
        }
    }
}
