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
        Debug.Log("����");
        switch (data.type)
        {
            case ItemType.SpeedItem:
                StartCoroutine(BoostOffCoroutine(PublicDefinitions.MaxSpeed));
                PublicDefinitions.MaxSpeed = 50f;
                CharacterManager.Instance.Player.controller.CurMoveSpeed = PublicDefinitions.MaxSpeed;
                break;
            case ItemType.Shield:
                // TODO : ���� ����
                break;
            case ItemType.AddDash:
                CharacterManager.Instance.Player.condition.AddStamina(data.abilityValue);
                ItemPool.Instance.Return(this);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ������ ������ ���� ��� ������ �������� �� (�κ��丮 ���� 1���� ����, ���ο� �������� ������ ������ �ִ� ���� �����)
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

        // ���� ���·� ��������
        PublicDefinitions.MaxSpeed = prevMaxSpeed;
        CharacterManager.Instance.Player.controller.CurMoveSpeed = prevMaxSpeed;
        ItemPool.Instance.Return(this);
    }
    IEnumerator ShieldOffCoroutine()
    {
        yield return new WaitForSeconds(data.abilityValue);

        // TODO : ���� ���ֱ�

        Destroy(gameObject);
    }
}
