using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region enum
public enum ItemType
{
    SpeedItem,
    AddDash,
    Shield,
    End,
}

public enum DescUIType
{
    Tutorial_Item,
    Tutorial_Dash,
    Tutorial_Superjump,
    Item_Booster,
    Item_AddDash,
}
#endregion

public static class PublicDefinitions
{
    #region »ó¼ö
    public static float MaxStamina = 200f;
    public static float MaxDamage = 100f;
    public static float MaxSpeed = 22f;
    public readonly static float DefaultMaxSpeed = 22f;
    #endregion
}
