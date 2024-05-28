using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Story {
    public Sprite background;
    [TextArea(10, 50)] 
    public string storyDialouge;
}
[CreateAssetMenu(menuName = "StoryData")]
public class StoryData : ScriptableObject
{
    public List<Story> storyList;
}
