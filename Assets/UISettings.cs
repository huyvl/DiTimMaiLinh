using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    public Toggle muteToggle;
    public Toggle unmuteToggle;
    public Toggle englishToggle;
    public Toggle vietnameseToggle;

    private const string MUTE_PREF_KEY = "IsMuted";
    private const string LANGUAGE_PREF_KEY = "SelectedLanguage";

    void Start()
    {
        bool isMuted = PlayerPrefs.GetInt(MUTE_PREF_KEY, 0) == 1;
        muteToggle.isOn = isMuted;
        unmuteToggle.isOn = !isMuted;

        muteToggle.onValueChanged.AddListener(OnMuteToggleChanged);
        unmuteToggle.onValueChanged.AddListener(OnUnmuteToggleChanged);
        
        string selectedLanguage = PlayerPrefs.GetString(LANGUAGE_PREF_KEY, "English");
        englishToggle.isOn = selectedLanguage == "English";
        vietnameseToggle.isOn = selectedLanguage == "Vietnamese";
        
        englishToggle.onValueChanged.AddListener(isOn => OnLanguageToggleChanged(isOn));
        vietnameseToggle.onValueChanged.AddListener(isOn => OnLanguageToggleChanged(!isOn));
    }
    void OnLanguageToggleChanged(bool isEnglishToggle)
    {
        if (isEnglishToggle)
        {
            SetLanguage("English");
            vietnameseToggle.isOn = false;
        }
        else
        {
            SetLanguage("Vietnamese");
            englishToggle.isOn = false;
        }
    }
    
    void SetLanguage(string language)
    {
        PlayerPrefs.SetString(LANGUAGE_PREF_KEY, language);
        PlayerPrefs.Save();
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
