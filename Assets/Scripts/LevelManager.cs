using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public StoryData storyData;
    public QuestionData QuestionData;
    [Header("Map Time")]
    public int playTime;
    [Header("Map Name")] 
    public string mapName;
    [Header("Character Name")] public string charName;

    public void OnEnable() {
        GameManager.Instance.storyTellerPanel.gameObject.SetActive(true);
        GameManager.Instance.storyTellerPanel.GetComponent<StoryTeller>().UpdateStoryTeller(storyData);
    }
}
