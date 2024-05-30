using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundAnimation : MonoBehaviour
{
    public Sprite[] spriteList;
    private int currentFrame;

    public Image levelselectbackground;

    private bool isUI;
    // Start is called before the first frame update
    private void Awake() {
        if (levelselectbackground != null) isUI = true;
    }

    void Start()
    {
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        while (true)
        {
            if(isUI) levelselectbackground.sprite = spriteList[currentFrame];
            else this.GetComponent<SpriteRenderer>().sprite = spriteList[currentFrame];
            yield return new WaitForSeconds(0.1f);
            currentFrame += 1;
            if (currentFrame >= spriteList.Length) currentFrame = 0;
        }

    }
}
