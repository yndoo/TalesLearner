using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public interface IDamagable
{
    public void Damage(float damage);
}
public class DamageObject : MonoBehaviour
{
    public float SpringPower;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out IDamagable target))
        {
            StartCoroutine(DamageModeCoroutine());
            collision.rigidbody.AddForce((-collision.contacts[0].normal * 10 + collision.transform.up) * SpringPower, ForceMode.Acceleration); // contacts는 충돌 발생한 접촉점들의 배열
            target.Damage(20);
        }
    }

    private IEnumerator DamageModeCoroutine()
    {
        CharacterManager.Instance.Player.controller.DamageModeActive();

        yield return new WaitForSeconds(1.25f);

        CharacterManager.Instance.Player.controller.isDamaged = false;
    }
}
