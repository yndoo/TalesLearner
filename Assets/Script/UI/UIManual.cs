using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManual : MonoBehaviour
{
    public GameObject EntireManual;

    public void ManualToggle()
    {
        EntireManual.SetActive(!EntireManual.activeSelf);
    }
}
