using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class StoryTeller : MonoBehaviour {
    public TextMeshProUGUI storyTextField;
    public StoryData currentStoryData;
    private int count;
    private bool isRunning;
    private Coroutine currentCoroutine;

    IEnumerator DisplayDialogue(string data) {
        storyTextField.text = "";
        foreach (char letter in data.ToCharArray()) {
            storyTextField.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        isRunning = false;
        count++;
    }

    public void UpdateStoryTeller(StoryData storyTellerData) {
        if (storyTellerData == null || storyTellerData.storyList == null || count >= storyTellerData.storyList.Count) {
            this.gameObject.SetActive(false);
            GameManager.Instance.SetupHUD();
            GameManager.Instance.isInPlay = true;
            count = 0;
            return;
        }

        currentStoryData = storyTellerData;

        if (currentStoryData.storyList[count] != null) {
            this.GetComponent<Image>().sprite = currentStoryData.storyList[count].background;
            currentCoroutine = StartCoroutine(DisplayDialogue(currentStoryData.storyList[count].storyDialouge));
            isRunning = true;
        }
    }

    private void Update() {
        if (Input.anyKeyDown) {
            if (isRunning) {
                StopCoroutine(currentCoroutine);
                storyTextField.text = currentStoryData.storyList[count].storyDialouge;
                count++;
                isRunning = false;
            }
            else {
                UpdateStoryTeller(currentStoryData);
            }
        }
    }
}