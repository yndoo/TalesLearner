using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIDescription : MonoBehaviour
{
    public TextMeshProUGUI txtTitle;
    public TextMeshProUGUI txtDesc;
    public Image image;

    public void SetUI(string _title, string _desc, Sprite _image)
    {
        txtTitle.text = _title;
        txtDesc.text = _desc;
        image.sprite = _image;
    }

}
