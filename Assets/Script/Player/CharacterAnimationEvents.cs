using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    public void OnFootStep()
    {
        SoundManager.Instance.PlayFootStep();
    }
}
