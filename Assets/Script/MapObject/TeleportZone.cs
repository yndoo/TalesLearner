using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface IFallable
{
    public void TakeFallDamage(float amount);
    public void Teleport(Vector3 pos);
}

public class TeleportZone : MonoBehaviour
{
    public Vector3 TeleportPosition;
    public bool isRestart;

    private float fallDamage = 40f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IFallable fallable))
        {
            if(isRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                return;
            }
            fallable.TakeFallDamage(fallDamage);
            fallable.Teleport(TeleportPosition);
        }
    }
}
