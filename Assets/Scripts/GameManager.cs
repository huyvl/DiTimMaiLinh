using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject storyTeller;
    public GameObject[] levelList;
    private int currentLevel = 0;
    [HideInInspector]
    public bool isInPlay = false;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame() {
        mainmenu.gameObject.SetActive(false);
        levelList[currentLevel].gameObject.SetActive(true);        
    }
}
