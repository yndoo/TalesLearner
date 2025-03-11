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
        Debug.Log("����");
        switch (data.type)
        {
            case EItemType.SpeedItem:
                StartCoroutine(BoostCoroutine());
                break;
            case EItemType.Shield:
                // TODO : ���� ����
                break;
            case EItemType.AddDash:
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
                ItemPool.Instance.Return(CharacterManager.Instance.Player.curUsableItem);
            }
            CharacterManager.Instance.Player.curUsableItem = this;
            transform.parent = CharacterManager.Instance.Player.transform;
            transform.localPosition = new Vector3(0, 3, 0);

            if(!other.gameObject.TryGetComponent<TutorialPlayer>(out TutorialPlayer t))
            {
                UIManager.Instance.SysInfoUI.SetActive(true);
                UIManager.Instance.SysInfoUI.GetComponent<UISystemInfo>().SetUIFor5Seconds($"{data.itemName} Shift ���� ��� ����");
            }
        }
    }

    IEnumerator BoostCoroutine()
    {
        PublicDefinitions.MaxSpeed = 50f;
        CharacterManager.Instance.Player.controller.CurMoveSpeed = PublicDefinitions.MaxSpeed;

        yield return new WaitForSeconds(data.abilityValue);

        // ���� ���·� ��������
        CharacterManager.Instance.Player.controller.CurMoveSpeed = PublicDefinitions.MaxSpeed = PublicDefinitions.DefaultMaxSpeed;
        ItemPool.Instance.Return(this);
    }
}
