using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManger : MonoBehaviour {
    public StoryData storyData;

    public void OnEnable() {
        GameManager.Instance.storyTeller.gameObject.SetActive(true);
        GameManager.Instance.storyTeller.GetComponent<StoryTeller>().UpdateStoryTeller(storyData);
    }
}
