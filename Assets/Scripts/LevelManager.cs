using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public StoryData storyData;
    public StoryData vietnameseStoryData;
    public QuestionData QuestionData;
    [Header("Map Time")]
    public int playTime;
    [Header("Map Name")] 
    public string mapName;
    [Header("Character Name")] public string charName;

    public void OnEnable()
    {
        GameManager.Instance.storyTellerPanel.gameObject.SetActive(true);

        string selectedLanguage = PlayerPrefs.GetString("SelectedLanguage", "English");

        if (selectedLanguage == "English")
        {
            GameManager.Instance.storyTellerPanel.GetComponent<StoryTeller>().UpdateStoryTeller(storyData);
        }
        else if (selectedLanguage == "Vietnamese")
        {
            GameManager.Instance.storyTellerPanel.GetComponent<StoryTeller>().UpdateStoryTeller(vietnameseStoryData);
        }
        else
        {
            Debug.LogWarning("Unsupported language selected: " + selectedLanguage);
        }
    }

}
