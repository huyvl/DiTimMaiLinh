using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    public Sprite[] spriteList;
    private int currentFrame;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        while (true)
        {
            this.GetComponent<SpriteRenderer>().sprite = spriteList[currentFrame];
            yield return new WaitForSeconds(0.1f);
            currentFrame += 1;
            if (currentFrame >= 77) currentFrame = 0;
        }

    }
}
