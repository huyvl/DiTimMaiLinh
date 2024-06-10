using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

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
    public GameObject mainmenu;
    public GameObject levelselect;
    public GameObject mainmenuCamera;
    public GameObject questionMgr;
    public GameObject storyTeller;
    public GameObject[] levelList;
    public int currentLevel = 0;
    [HideInInspector]
    public bool isInPlay = false;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SoundManager.instance.Play(TypeSFX.BGM,"BGM");
    }
    
    public void PlayLevel(int level) {
        SoundManager.instance.Play(TypeSFX.SFX,"Click");
        levelselect.SetActive(false);
        levelList[level].gameObject.SetActive(true);      
    }
    public void StartGame() {
        mainmenu.gameObject.SetActive(false);
        mainmenuCamera.gameObject.SetActive(false);
        levelselect.SetActive(true);
        SoundManager.instance.Play(TypeSFX.SFX,"Click");
    }

    public void QuizTime() {
        isInPlay = false;
        questionMgr.SetActive(true);
    }

    public void EndQuiz() {
        isInPlay = true;
        questionMgr.SetActive(false);
    }
}
