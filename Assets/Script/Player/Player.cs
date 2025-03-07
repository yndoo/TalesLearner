using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IFallable
{
    public PlayerController controller;
    public PlayerCondition condition;
    public ItemObject curUsableItem;

    public void TakeFallDamage(float amount)
    {
        condition.AddDamage(amount);
    }

    public void Teleport(Vector3 pos)
    {
        transform.position = pos;
        // TODO : 텔레포트 애니메이션 등
    }

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            if (curUsableItem != null)
            {
                curUsableItem.OnUse();
                curUsableItem = null;
            }
        }
    }
}
