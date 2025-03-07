using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObject : MonoBehaviour
{
    public TutorialData data;

    public void SetTutorialUI()
    {
        UIManager.Instance.DescriptionUI.GetComponent<UIDescription>().SetUI(data.title, data.description, data.uiImage);
        UIManager.Instance.DescriptionUI.SetActive(true);
    }
}
