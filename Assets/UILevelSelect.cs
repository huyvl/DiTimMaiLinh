using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelSelect : MonoBehaviour {
    public Button[] levelList;
    private void Awake() {
        int count = GameManager.Instance.currentLevel;
        for (int i = 0; i <= count; i++) {
            levelList[i].interactable = true;
        }
    }
}
