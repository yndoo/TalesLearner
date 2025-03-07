using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="TutorialData", menuName ="New Tutorial Data")]
public class TutorialData : ScriptableObject
{
    [Header("Info")]
    public string title;
    public string description;

    [Header("UI")]
    public Image uiImage;
}
