using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour {
    public QuestionData currentQuestionData;

    private int currentQuestionIndex;

    public TextMeshProUGUI questionText;
    public List<Button> answerButtons;
    // Start is called before the first frame update
    private void OnEnable() {
        currentQuestionIndex = 0;
        currentQuestionData = GameManager.Instance.GetCurrentActiveLevel().QuestionData;
    }

    void Start()
    {
        DisplayQuestion(currentQuestionIndex);
    }
    void DisplayQuestion(int questionIndex)
    {
        if (questionIndex >= currentQuestionData.questionList.Count)
        {
            Debug.Log("No more questions available.");
            return;
        }

        Question question = currentQuestionData.questionList[questionIndex];
        questionText.text = question.Questions;

        for (int i = 0; i < answerButtons.Count; i++)
        {
            if (i < question.answerList.Length)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question.answerList[i].answer.Trim();
                answerButtons[i].gameObject.SetActive(true);
                int answerIndex = i;
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => {
                    SoundManager.instance.Play(TypeSFX.SFX,"Click");
                    OnAnswerSelected(answerIndex);
                });
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }
    }
    void OnAnswerSelected(int index)
    {
        Answer selectedAnswer = currentQuestionData.questionList[currentQuestionIndex].answerList[index];
        if (selectedAnswer.isCorrectAnswer)
        {
            Debug.Log("Correct answer!");
            currentQuestionIndex++;
            if (currentQuestionIndex < currentQuestionData.questionList.Count)
            {
                DisplayQuestion(currentQuestionIndex);
            }
            else
            {
                Debug.Log("Quiz completed!");
                GameManager.Instance.EndQuiz();
            }
        }
        else
        {
            Debug.Log("Wrong answer!");
        }
    }
    
}
