using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [Header("Gauge")]
    [SerializeField] float curStamina;
    [SerializeField] float curDamage;

    private void Start()
    {
        curStamina = PublicDefinitions.MaxStamina;
        curDamage = 0f;
    }

    private void FixedUpdate()
    {
        PassiveStamina();
    }

    private void PassiveStamina()
    {
        curStamina += 0.3f;
        if(curStamina > PublicDefinitions.MaxStamina)
        {
            curStamina = PublicDefinitions.MaxStamina;
        }
        UIManager.Instance.gaugeUI.SetStamina(curStamina);
    }

    public void UseStamina()
    {
        curStamina -= 1f;
        if (curStamina <= 0f)
        {
            curStamina = 0f;
            // TODO : °ÔÀÌÁö¹Ù ±ôºýÀÌ±â
        }

        UIManager.Instance.gaugeUI.SetStamina(curStamina);
    }

    public void AddDamage(float damage)
    {
        curDamage += damage;
        if (curDamage > PublicDefinitions.MaxDamage)
        {
            curDamage = PublicDefinitions.MaxDamage;
        }
        UIManager.Instance.gaugeUI.SetDamage(curDamage);
    }
}
