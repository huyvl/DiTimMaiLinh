using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    [Header("UI Panel")]
    public GameObject mainMenuPanel;
    public GameObject levelSelectPanel;
    public GameObject mainMenuCamera;
    public GameObject questionMgrPanel;
    public GameObject storyTellerPanel;
    public GameObject hudPanel;
    public GameObject howToPlayPanel;
    public GameObject settingPanel;
    
    [HideInInspector]
    public bool isInPlay = false;
    #region Game Variable
    private int coinScore = 0;
    private int gameScore = 0;
    private int playTime = 0;
    private int health = 6;

    #endregion

    [Header("HUD")] 
    public TextMeshProUGUI mapNameText;
    public TextMeshProUGUI playTimeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    public List<GameObject> heartList;
    [Header("Level List")]
    public GameObject[] levelList;
    [HideInInspector]
    public int currentLevel = 0;
    private LevelManager currentActiveLevel;

    public void UpdateScore(int value) {
        coinScore += value;
        coinText.text = "X" + coinScore.ToString();
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SoundManager.instance.Play(TypeSFX.BGM,"BGM");
       
    }

    private IEnumerator UpdateTimer()
    {
        while (true)
        {
            playTime += 1;
            playTimeText.text = playTime.ToString();
            yield return new WaitForSeconds(1f);
        }
    }

    public LevelManager GetCurrentActiveLevel() {
        return currentActiveLevel;
    }
    public void PlayLevel(int level) {
        // SoundManager.instance.Play(TypeSFX.SFX,"Click");
        levelSelectPanel.SetActive(false);
        currentActiveLevel = Instantiate(levelList[level], new Vector3(0, 0, 0), quaternion.identity).GetComponent<LevelManager>();
        // levelList[level].gameObject.SetActive(true);
        // currentActiveLevel = levelList[level].GetComponent<LevelManager>();
        playTime = 0;   
    }

    public void ResetLevel() {
        hudPanel.gameObject.SetActive(false);
        Destroy(currentActiveLevel.gameObject);
        currentActiveLevel = Instantiate(levelList[currentLevel], new Vector3(0, 0, 0), quaternion.identity).GetComponent<LevelManager>();
        playTime = 0;
        foreach (GameObject heart in heartList) {
            heart.SetActive(true);
        }
        health = 6;
        coinScore = 0;
        StopAllCoroutines();
    }
    
    public void StartGame() {
        mainMenuPanel.gameObject.SetActive(false);
        mainMenuCamera.gameObject.SetActive(false);
        levelSelectPanel.SetActive(true);
        SoundManager.instance.Play(TypeSFX.SFX,"Click");
    }

    public void SetupHUD() {
        hudPanel.gameObject.SetActive(true);
        mapNameText.text = currentActiveLevel.mapName.ToString().Trim();
        coinText.text = "X" + coinScore.ToString();
        // playTimeText.text = currentActiveLevel.playTime.ToString();
        // playTime = currentActiveLevel.playTime;
        StartCoroutine(UpdateTimer());
    }
    public void QuizTime() {
        isInPlay = false;
        hudPanel.gameObject.SetActive(false);
        questionMgrPanel.SetActive(true);
    }

    public void EndQuiz() {
        isInPlay = true;
        questionMgrPanel.SetActive(false);
        NextLevel();
    }

    public void NextLevel() {
        Destroy(currentActiveLevel.gameObject);
        // levelList[currentLevel].gameObject.SetActive(false);
        currentLevel++;
        PlayLevel(currentLevel);
    }

    public void UpdateHeartStatus() {
        if (health > 0) {
            heartList[health - 1].gameObject.SetActive(false);
            health--;
            if (health == 0) {
                ResetLevel();
            }
        }
    }
}
