using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IFallable
{
    public PlayerController controller;
    public PlayerCondition condition;

    public void TakeFallDamage(float amount)
    {
        condition.AddDamage(amount);
    }

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
    }
}
