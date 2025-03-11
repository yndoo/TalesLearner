using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [Header("Gauge")]
    [SerializeField] float curStamina;
    [SerializeField] float curDamage;

    public bool IsAnger = false;

    private void Start()
    {
        curStamina = PublicDefinitions.MaxStamina;
        curDamage = 0f;
    }

    private void FixedUpdate()
    {
        PassiveStamina();
    }

    public bool CanUseStamina()
    {
        return curStamina >= 1;
    }

    private void PassiveStamina()
    {
        curStamina += 0.3f;
        if(curStamina > PublicDefinitions.MaxStamina)
        {
            curStamina = PublicDefinitions.MaxStamina;
        }
        UIManager.Instance.GaugeUI.SetStamina(curStamina);
    }

    public void UseStamina()
    {
        curStamina -= 1f;
        if (curStamina <= 0f)
        {
            curStamina = 0f;
            // TODO : °ÔÀÌÁö¹Ù ±ôºýÀÌ±â
        }

        UIManager.Instance.GaugeUI.SetStamina(curStamina);
    }

    public void AddDamage(float damage)
    {
        curDamage += damage;
        if (curDamage > PublicDefinitions.MaxDamage)
        {
            curDamage = PublicDefinitions.MaxDamage;
        }
        UIManager.Instance.GaugeUI.SetDamage(curDamage);
        SoundManager.Instance.PlaySFX(ESFXType.Damaged);
    }

    public void AddStamina(float amount)
    {
        curStamina += amount;
        if (curStamina > PublicDefinitions.MaxStamina)
        {
            curStamina = PublicDefinitions.MaxStamina;
        }
        UIManager.Instance.GaugeUI.SetStamina(curStamina);
    }
}
