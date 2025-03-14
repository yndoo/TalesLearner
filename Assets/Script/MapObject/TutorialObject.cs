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
    public void SetInfoUI()
    {
        UIManager.Instance.SysInfoUI.SetActive(true);
        UIManager.Instance.SysInfoUI.GetComponent<UISystemInfo>().SetUI(data.description);
    }

    private void OnTriggerEnter(Collider other)
    {
        SetTutorialUI();
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.Instance.DescriptionUI.SetActive(false);
    }
}
