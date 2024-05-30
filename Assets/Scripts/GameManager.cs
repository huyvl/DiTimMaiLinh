using System.Collections;
using System.Collections.Generic;
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
    public GameObject storyTeller;
    public GameObject[] levelList;
    public int currentLevel = 0;
    [HideInInspector]
    public bool isInPlay = false;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayLevel(int level) {
        levelselect.SetActive(false);
        levelList[level].gameObject.SetActive(true);      
    }
    public void StartGame() {
        mainmenu.gameObject.SetActive(false);
        // levelList[currentLevel].gameObject.SetActive(true);        
        levelselect.SetActive(true);
    }
}
