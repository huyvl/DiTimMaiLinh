using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
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
    [HideInInspector]
    public bool isInPlay = false;
    #region Game Variable
    private int coinScore = 0;
    private int gameScore = 0;
    private int playTime;

    #endregion

    [Header("HUD")] 
    public TextMeshProUGUI charNameText;
    public TextMeshProUGUI mapNameText;
    public TextMeshProUGUI playTimeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    
    [Header("Level List")]
    public GameObject[] levelList;
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

    public LevelManager GetCurrentActiveLevel() {
        return currentActiveLevel;
    }
    public void PlayLevel(int level) {
        // SoundManager.instance.Play(TypeSFX.SFX,"Click");
        levelSelectPanel.SetActive(false);
        levelList[level].gameObject.SetActive(true);
        currentActiveLevel = levelList[level].GetComponent<LevelManager>();
    }
    public void StartGame() {
        mainMenuPanel.gameObject.SetActive(false);
        mainMenuCamera.gameObject.SetActive(false);
        levelSelectPanel.SetActive(true);
        SoundManager.instance.Play(TypeSFX.SFX,"Click");
    }

    public void SetupHUD() {
        hudPanel.gameObject.SetActive(true);
        charNameText.text = currentActiveLevel.charName.ToString().Trim();
        mapNameText.text = currentActiveLevel.mapName.ToString().Trim();
        playTimeText.text = currentActiveLevel.playTime.ToString();
        playTime = currentActiveLevel.playTime;

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
        levelList[currentLevel].gameObject.SetActive(false);
        currentLevel++;
        PlayLevel(currentLevel);
    }
}
