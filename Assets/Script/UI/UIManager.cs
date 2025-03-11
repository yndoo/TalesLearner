using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private UIGauge gaugeUI;
    private UIManual manualUI;
    private UIRecord recordUI;
    private GameObject sysInfoUI;
    private GameObject descriptionUI;
    private GameObject speedLineEffect;
    private GameObject gameHUD;

    public UIGauge GaugeUI
    {
        get
        {
            if (gaugeUI == null)
            {
                gaugeUI = GameHUD.GetComponentInChildren<UIGauge>();
                sysInfoUI = gaugeUI.SysInfoUI;
                sysInfoUI.SetActive(false);
            }
            return gaugeUI;
        }
    }
    public UIManual ManualUI
    {
        get
        {
            if (manualUI == null)
            {
                manualUI = Instantiate(Resources.Load("UIs/Manual")).GetComponent<UIManual>();
            }
            return manualUI;
        }
    }

    public GameObject SysInfoUI
    {
        get
        {
            if(sysInfoUI == null)
            {
                sysInfoUI = GaugeUI.SysInfoUI;
            }
            return sysInfoUI;
        }
    }
    public GameObject DescriptionUI
    {
        get
        {
            if (descriptionUI == null)
            {
                descriptionUI = Instantiate(Resources.Load("UIs/UIDescription") as GameObject);
                descriptionUI.SetActive(false);
            }
            return descriptionUI;
        }
    }
    public GameObject SpeedLineEffect
    {
        get
        {
            if (speedLineEffect == null)
            {
                speedLineEffect = Instantiate(Resources.Load("UIs/SpeedLine") as GameObject);
                speedLineEffect.SetActive(false);
            }
            return speedLineEffect;
        }
    }
    public GameObject GameHUD
    {
        get
        {
            if (gameHUD == null)
            {
                gameHUD = Instantiate(Resources.Load("UIs/GameHUD") as GameObject);
            }
            return gameHUD;
        }
    }

    public UIRecord RecordUI
    {
        get
        {
            if (recordUI == null)
            {
                recordUI = GameHUD.GetComponentInChildren<UIRecord>();
            }
            return recordUI;
        }
    }

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
            gaugeUI = GameHUD.GetComponentInChildren<UIGauge>();
            sysInfoUI = gaugeUI.SysInfoUI;
            sysInfoUI.SetActive(false);
        }
        if (manualUI == null)
        {
            manualUI = Instantiate(Resources.Load("UIs/Manual")).GetComponent<UIManual>();
        }
        if(descriptionUI == null)
        {
            descriptionUI = Instantiate(Resources.Load("UIs/UIDescription") as GameObject);
            descriptionUI.SetActive(false);
        }
        if(speedLineEffect == null)
        {
            speedLineEffect = Instantiate(Resources.Load("UIs/SpeedLine") as GameObject);
            speedLineEffect.SetActive(false);
        }
        if (gameHUD == null)
        {
            gameHUD = Instantiate(Resources.Load("UIs/GameHUD") as GameObject);
        }
        if (recordUI == null)
        {
            recordUI = gameHUD.GetComponentInChildren<UIRecord>();
        }
    }
}
