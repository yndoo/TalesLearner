using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGauge : MonoBehaviour
{
    public Image Stamina;
    public Image Damage;
    public GameObject SysInfoUI;

    /// <summary>
    /// ���׹̳��� ������ ������ ��� ������Ʈ ���ִ� �Լ�
    /// </summary>
    /// <param name="statminaP">���׹̳�</param>
    /// <param name="damageP">������</param>
    public void UpdateGauge(float statmina, float damage)
    {
        Stamina.fillAmount = (statmina / PublicDefinitions.MaxStamina) / 2;
        Damage.fillAmount = (damage / PublicDefinitions.MaxDamage) / 2;
    }
    public void SetStamina(float totalAmount)
    {
        Stamina.fillAmount = (totalAmount / PublicDefinitions.MaxStamina) / 2;
    }
    public void SetDamage(float totalAmount)
    {
        Damage.fillAmount = (totalAmount / PublicDefinitions.MaxDamage) / 2;
    }
}
