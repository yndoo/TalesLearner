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

    private void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    public void OnUse()
    {
        Debug.Log("사용됨");
        switch (data.type)
        {
            case EItemType.SpeedItem:
                StartCoroutine(BoostCoroutine());
                break;
            case EItemType.Shield:
                // TODO : 쉴드 장착
                break;
            case EItemType.AddDash:
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
                ItemPool.Instance.Return(CharacterManager.Instance.Player.curUsableItem);
            }
            CharacterManager.Instance.Player.curUsableItem = this;
            transform.parent = CharacterManager.Instance.Player.transform;
            transform.localPosition = new Vector3(0, 3, 0);

            if(!other.gameObject.TryGetComponent<TutorialPlayer>(out TutorialPlayer t))
            {
                UIManager.Instance.SysInfoUI.SetActive(true);
                UIManager.Instance.SysInfoUI.GetComponent<UISystemInfo>().SetUIFor5Seconds($"{data.itemName} Shift 눌러 사용 가능");
            }
        }
    }

    IEnumerator BoostCoroutine()
    {
        PublicDefinitions.MaxSpeed = 50f;
        CharacterManager.Instance.Player.controller.CurMoveSpeed = PublicDefinitions.MaxSpeed;

        yield return new WaitForSeconds(data.abilityValue);

        // 원래 상태로 돌려놓기
        CharacterManager.Instance.Player.controller.CurMoveSpeed = PublicDefinitions.MaxSpeed = PublicDefinitions.DefaultMaxSpeed;
        ItemPool.Instance.Return(this);
    }
}
