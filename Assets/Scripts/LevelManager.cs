using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public StoryData storyData;
    public QuestionData QuestionData;

    public void OnEnable() {
        GameManager.Instance.storyTeller.gameObject.SetActive(true);
        GameManager.Instance.storyTeller.GetComponent<StoryTeller>().UpdateStoryTeller(storyData);
    }
}
