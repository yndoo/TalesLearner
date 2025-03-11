using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="New Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string description;
    public EItemType type;
    public float abilityValue; // ������ ȿ�� ���� ��ġ
}
