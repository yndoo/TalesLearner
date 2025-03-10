using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISystemInfo : MonoBehaviour
{
    public TextMeshProUGUI message;

    public void SetUI(string _msg)
    {
        message.text = _msg;
    }
}
