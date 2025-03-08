using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsable
{
    void OnUse();
}

public class ItemObject : MonoBehaviour, IUsable
{
    public ItemData data;

    public void OnUse()
    {
        Debug.Log("사용됨");
        switch (data.type)
        {
            case ItemType.SpeedItem:
                StartCoroutine(BoostOffCoroutine(PublicDefinitions.MaxSpeed));
                PublicDefinitions.MaxSpeed = 50f;
                CharacterManager.Instance.Player.controller.CurMoveSpeed = PublicDefinitions.MaxSpeed;
                break;
            case ItemType.Shield:
                // TODO : 쉴드 장착
                break;
            case ItemType.AddDash:
                CharacterManager.Instance.Player.condition.AddStamina(data.abilityValue);
                ItemPool.Instance.Return(this);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 아이템 먹으면 현재 사용 가능한 아이템이 됨 (인벤토리 없이 1개만 가능, 새로운 아이템을 먹으면 이전에 있던 것이 사라짐)
        if(other.CompareTag("Player"))
        {
            if(CharacterManager.Instance.Player.curUsableItem != null)
            {
                ItemPool.Instance.Return(this);
                //Destroy(CharacterManager.Instance.Player.curUsableItem.gameObject);
            }
            CharacterManager.Instance.Player.curUsableItem = this;
            transform.parent = CharacterManager.Instance.Player.transform;
            transform.localPosition = new Vector3(0, 3, 0);
        }
    }

    IEnumerator BoostOffCoroutine(float prevMaxSpeed)
    {
        yield return new WaitForSeconds(data.abilityValue);

        // 원래 상태로 돌려놓기
        PublicDefinitions.MaxSpeed = prevMaxSpeed;
        CharacterManager.Instance.Player.controller.CurMoveSpeed = prevMaxSpeed;
        ItemPool.Instance.Return(this);
    }
    IEnumerator ShieldOffCoroutine()
    {
        yield return new WaitForSeconds(data.abilityValue);

        // TODO : 쉴드 없애기

        Destroy(gameObject);
    }
}
