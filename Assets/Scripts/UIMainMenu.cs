using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour {
    public void PlayButton() {
        GameManager.Instance.StartGame();
        this.gameObject.SetActive(false);
    }

    public void HowToPlayButton() {
        GameManager.Instance.howToPlayPanel.SetActive(true);
        SoundManager.instance.Play(TypeSFX.SFX,"Click");
    }

}
