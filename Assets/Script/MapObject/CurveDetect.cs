using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CurveDetect : MonoBehaviour
{
    public CurveZone zone;
    public Vector3 vec;
    public bool isCorrectDir; // ���߿� �ε����� ������Ʈ�� true�� +90��, false�� -90�� ȸ����Ŵ

    Coroutine coroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (zone.prev == Vector3.zero) zone.prev = vec;
        else
        {
            zone.next = vec;

            // prev~next ȸ��
            zone.RotateStart(isCorrectDir);

            if(coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(Refresh());
        }
    }

    IEnumerator Refresh()
    {
        GetComponent<Collider>().enabled = false;   
        yield return new WaitForSeconds(0.5f);
        GetComponent<Collider>().enabled = true;
    }
}
