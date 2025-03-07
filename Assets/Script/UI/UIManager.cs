using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("UIManager").AddComponent<UIManager>();
            }
            return _instance;
        }
    }   

    public UIGauge gaugeUI;
    public GameObject DescriptionUI;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            UIInitialize();
            DontDestroyOnLoad(gameObject);
        }
    }

    private void UIInitialize()
    {
        if(gaugeUI == null)
        {
            gaugeUI = Instantiate(Resources.Load("UIs/GameHUD")).GetComponentInChildren<UIGauge>();
        }
        if(DescriptionUI == null)
        {
            DescriptionUI = Instantiate(Resources.Load("UIs/UIDescription") as GameObject);
        }
    }
}
