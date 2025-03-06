using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFallable
{
    public void TakeFallDamage(float amount);
    public void Teleport(Vector3 pos);
}

public class TeleportZone : MonoBehaviour
{
    public Vector3 TeleportPosition;

    private float fallDamage = 40f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IFallable fallable))
        {
            fallable.TakeFallDamage(fallDamage);
            fallable.Teleport(TeleportPosition);
        }
    }
}
