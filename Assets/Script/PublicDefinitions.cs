using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region enum
public enum EItemType
{
    SpeedItem,
    AddDash,
    Shield,
    End,
}

public enum EDescUIType
{
    Tutorial_Item,
    Tutorial_Dash,
    Tutorial_Superjump,
    Item_Booster,
    Item_AddDash,
}

public enum EGameState
{
    GameStart,
    GameEnd,
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
