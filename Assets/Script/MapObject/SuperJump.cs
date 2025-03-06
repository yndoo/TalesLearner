using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISuperJumpable
{
    public void SuperJump();
}

public class SuperJump : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ISuperJumpable superJump))
        {
            superJump.SuperJump();
        }
    }
}
