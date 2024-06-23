using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    public Toggle muteToggle;
    public Toggle unmuteToggle;

    private const string MUTE_PREF_KEY = "IsMuted";

    void Start()
    {
        bool isMuted = PlayerPrefs.GetInt(MUTE_PREF_KEY, 0) == 1;
        muteToggle.isOn = isMuted;
        unmuteToggle.isOn = !isMuted;

        muteToggle.onValueChanged.AddListener(OnMuteToggleChanged);
        unmuteToggle.onValueChanged.AddListener(OnUnmuteToggleChanged);
    }

    void OnMuteToggleChanged(bool isOn)
    {
        if (isOn)
        {
            SoundManager.instance.MuteAll();
            PlayerPrefs.SetInt(MUTE_PREF_KEY, 1);
            PlayerPrefs.Save();

            unmuteToggle.isOn = false;
        }
    }

    void OnUnmuteToggleChanged(bool isOn)
    {
        if (isOn)
        {
            SoundManager.instance.UnMuteAll();
            PlayerPrefs.SetInt(MUTE_PREF_KEY, 0);
            PlayerPrefs.Save();

            muteToggle.isOn = false;
        }
    }
}
