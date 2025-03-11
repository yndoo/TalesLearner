using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IFallable, IDamagable
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
        UIManager.Instance.SysInfoUI.SetActive(true);
        UIManager.Instance.SysInfoUI.GetComponent<UISystemInfo>().SetUIFor5Seconds("장애물에 부딪혀 텔레포트 되었습니다.");
        // TODO : 텔레포트 애니메이션 등
    }

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
    }

    private void Start()
    {
        //Cursor.visible = false;
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

    public void Damage(float damage)
    {
        condition.AddDamage(damage);
    }
}
