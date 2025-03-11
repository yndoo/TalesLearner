using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIRecord : MonoBehaviour
{
    public TextMeshProUGUI curRec;
    public TextMeshProUGUI bestRec;

    float curTime;
    bool isRunning = false;
    readonly string recordKey = "BestRecord";

    void Start()
    {
        curTime = 0;
        bestRec.text = PlayerPrefs.GetFloat(recordKey).ToString("N2");
    }

    void Update()
    {
        if (!isRunning) return;
        curTime += Time.deltaTime;
        curRec.text = curTime.ToString("N2");
    }
    public void StartRecord()
    {
        isRunning = true;
    }
    public string StopRecord()
    {
        isRunning = false;

        float savedRec = PlayerPrefs.GetFloat(recordKey, float.MaxValue);
        if(curTime < savedRec)
        {
            PlayerPrefs.SetFloat(recordKey, curTime);
            PlayerPrefs.Save();
            bestRec.text = curTime.ToString("N2");
        }

        curRec.text = curTime.ToString("N2");
        return curRec.text;
    }
}
