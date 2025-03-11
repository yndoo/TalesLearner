using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveZone : MonoBehaviour
{    
    [HideInInspector]public Vector3 prev = Vector3.zero;
    [HideInInspector]public Vector3 next = Vector3.zero;
    
    [HideInInspector] public Coroutine coroutine;
    [HideInInspector] public float rotationSpeed = 6;


    public void RotateStart(bool isCorrectDir)
    {
        if(coroutine != null) StopCoroutine(coroutine);

        float dotProduct = Vector3.Dot(prev, next);
        float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg; // 사이각을 각도로 구함
        if(!isCorrectDir) angle = -angle;
        coroutine = StartCoroutine(RotateCoroutine(angle));

        prev = next = Vector3.zero;
    }

    IEnumerator RotateCoroutine(float angle)
    {
        Transform t = CharacterManager.Instance.Player.transform;
        Quaternion startRotation = t.rotation;
        Quaternion targetRotation = Quaternion.Euler(t.eulerAngles.x, t.eulerAngles.y + angle, t.eulerAngles.z);

        float passTime = 0f;
        while (passTime < 1.5f)
        {
            t.rotation = Quaternion.Lerp(startRotation, targetRotation, passTime);
            passTime += Time.deltaTime * rotationSpeed;
            yield return null;
        }

        t.rotation = targetRotation; 
    }
}
