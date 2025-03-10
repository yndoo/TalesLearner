using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CurveDetect : MonoBehaviour
{
    public CurveZone zone;
    public Vector3 vec;
    public bool isCorrectDir; // ������ �ݸ����� true��

    private void OnTriggerEnter(Collider other)
    {
        if (zone.prev == Vector3.zero) zone.prev = vec;
        else
        {
            zone.next = vec;

            // prev~next ȸ��
            zone.RotateStart(isCorrectDir);
        }
    }


}
