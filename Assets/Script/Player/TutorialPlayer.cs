using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 튜토리얼 오브젝트 동적 조사 용이었던 것 -> 동적조사용 오브젝트 따로 만듦
/// </summary>
public class TutorialPlayer : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float laskCheckTime;
    private float maxCheckDistance = 10f;
    public LayerMask checkLayer;

    private Camera playerCamera;
    public Transform myTrans;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        if (Time.time - laskCheckTime > checkRate)
        {
            laskCheckTime = Time.time;

            // Ray 쏴서 튜토리얼 오브젝트 체크
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxCheckDistance, checkLayer))
            {
                hit.collider.gameObject.GetComponent<TutorialObject>().SetInfoUI();
            }
            else
            {
                // 빈 곳을 쏜 경우 
                UIManager.Instance.DescriptionUI.SetActive(false);
            }
        }
    }
}