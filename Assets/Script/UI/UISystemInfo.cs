using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISystemInfo : MonoBehaviour
{
    public TextMeshProUGUI message;
    private Coroutine coroutine;
    bool canClear = true;
    public void SetUI(string _msg)
    {
        message.text = _msg;
    }

    public void SetUIFor5Seconds(string _msg)
    {
        if(coroutine != null)
        {
            if(message.text != "" && !canClear)
                _msg = $"{message.text}\n{_msg}"; 
            StopCoroutine(coroutine);
        }
        message.text = _msg;
        coroutine = StartCoroutine(MessageCoroutine());
    }

    IEnumerator MessageCoroutine()
    {
        canClear = false;
        this.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.5f);
        canClear = true;
        yield return new WaitForSeconds(2.5f);

        this.gameObject.SetActive(false);
        message.text = "";
    }
}
